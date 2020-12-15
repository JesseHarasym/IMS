using IMS.Database;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using VideoGameInventoryApp.Classes;

namespace IMS.CustomControls.HelperControls.Users
{
    public partial class CancelOrders : Form
    {
        UserControls UserControls;
        List<Products> ProductList;
        List<Orders> OrderList;
        int GameID;
        int Quantity;

        public CancelOrders()
        {
            InitializeComponent();
        }

        public CancelOrders(UserControls userControls, List<Products> productList, List<Orders> orderList)
        {
            InitializeComponent();
            UserControls = userControls;
            ProductList = productList;
            OrderList = orderList;
        }

        private void CancelOrders_Load(object sender, EventArgs e)
        {
            //which product dropdown setup
            boxWhichOrder.DropDownStyle = ComboBoxStyle.DropDownList;
            boxWhichOrder.Items.Add("Chose an order to cancel");
            boxWhichOrder.SelectedIndex = 0;

            //find product in order list and add to dropdown
            foreach (var o in OrderList)
            {
                foreach (var p in ProductList)
                {
                    if (o.ProductID == p.GameID && !o.PickedUp)
                    {
                        boxWhichOrder.Items.Add($"OrderID #{o.OrderID} - {p.GameID} ~ {p.Title}");
                    }
                }
            }
        }

        private void boxWhichOrder_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (boxWhichOrder.SelectedIndex != 0) //if the user selects an option
            {
                string[] boxArr = boxWhichOrder.Text.Split('-');
                string[] gameArr = boxArr[1].Split('~');
                int gameId = Convert.ToInt32(gameArr[0].Trim());
                string title = gameArr[1].Trim();

                foreach (var p in ProductList)
                {
                    if (p.GameID == gameId && p.Title == title)
                    {
                        //track quantity for subtracting from later
                        Quantity = p.Quantity;
                        GameID = p.GameID;
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var od = new OrderDatabase();

            string[] boxArr = boxWhichOrder.Text.Split('-');
            string[] orderArr = boxArr[0].Split('#');
            int orderId = Convert.ToInt32(orderArr[1].Trim());
            bool successUpdate = false;
            bool successDelete = false;

            if (boxWhichOrder.SelectedIndex != 0)
            {
                successUpdate = od.UpdateGameInfo(GameID, Quantity, "+");
                successDelete = od.DeleteUserOrder(orderId);
            }
            else
            {
                MessageBox.Show("You must select an order to cancel it.");
            }

            if (successUpdate && successDelete)
            {
                UserControls.ShowUserInfo();

                MessageBox.Show(
                    $"Order #{orderId} has been cancelled for pickup.");

                Close();
            }
            else
            {
                MessageBox.Show("There was an issue while attempting to cancel this order.");
            }
        }


    }
}
