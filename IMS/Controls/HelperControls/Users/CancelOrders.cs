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
        int QuantityInStock;
        int QuantitySold;

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
            //which order dropdown setup
            boxWhichOrder.DropDownStyle = ComboBoxStyle.DropDownList;
            boxWhichOrder.Items.Add("Chose an order to cancel");
            boxWhichOrder.SelectedIndex = 0;
            boxWhichOrder.DropDownHeight = boxWhichOrder.Font.Height * 10;  //only allow 10 items at a time while viewing

            //find product information for each item in order list and add to dropdown
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

        //if a selection is made then extract that information to use for cancellation
        private void boxWhichOrder_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (boxWhichOrder.SelectedIndex != 0) //if the user selects a valid combobox option
            {
                string[] boxArr = boxWhichOrder.Text.Split('-');
                string[] gameArr = boxArr[1].Split('~');
                int gameId = Convert.ToInt32(gameArr[0].Trim());

                foreach (var p in ProductList)
                {
                    if (p.GameID == gameId)
                    {
                        //track quantity for subtracting from later
                        QuantityInStock = p.QuantityInStock;
                        QuantitySold = p.QuantitySold;
                        //get gameId of selection for updating
                        GameID = p.GameID;
                    }
                }
            }
        }

        //if the order is cancelled by the user then remove the order from the database and update the stock quantities accordingly
        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                string[] boxArr = boxWhichOrder.Text.Split('-');
                string[] orderArr = boxArr[0].Split('#');
                int orderId = Convert.ToInt32(orderArr[1].Trim());
                bool successUpdate = false;
                bool successDelete = false;

                //if a valid option has been selected from the combo box
                if (boxWhichOrder.SelectedIndex != 0)
                {
                    var od = new OrderDatabase();
                    var pd = new ProductDatabase();
                    successDelete = od.DeleteUserOrder(orderId);    //remove the users order
                    successUpdate = pd.UpdateGameStockAfterOrder(GameID, QuantityInStock, QuantitySold, false); //add back to stock and remove from sold
                }
                else
                {
                    MessageBox.Show("You must select an order to cancel it.");
                }

                //if database operations are successful then let the user know and update their data information viewed
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
            catch
            {
                MessageBox.Show("You must choose a product to be cancelled.");
            }
        }
    }
}
