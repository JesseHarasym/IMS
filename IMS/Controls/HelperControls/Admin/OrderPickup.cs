using IMS.Database;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using VideoGameInventoryApp.Classes;

namespace IMS.CustomControls.HelperControls.Admin
{
    public partial class OrderPickup : Form
    {
        UserControls UserControls;
        List<Orders> OrderList;

        public OrderPickup(UserControls userControls, List<Orders> orderList)
        {
            InitializeComponent();
            UserControls = userControls;
            OrderList = orderList;
        }

        private void OrderPickup_Load(object sender, EventArgs e)
        {
            //setup for initial dropdown box
            boxOrderPickups.DropDownStyle = ComboBoxStyle.DropDownList;
            boxOrderPickups.Items.Add("Pick an order");
            boxOrderPickups.SelectedIndex = 0;

            //add each order to dropdown box
            foreach (var o in OrderList)
            {
                if (!o.PickedUp)
                {
                    boxOrderPickups.Items.Add($"{o.OrderID} ~ {o.ProductName}");
                }
            }
        }

        //if admin chooses an order, then update as picked up in database, and reload admins viewed data
        private void btnPickedUp_Click(object sender, EventArgs e)
        {
            try
            {
                string[] orderArr = boxOrderPickups.Text.Split('~');
                Int32.TryParse(orderArr[0].Trim(), out int orderId);
                string title = orderArr[1].Trim();
                bool success = false;

                //if a product was selected then send to database
                if (boxOrderPickups.SelectedIndex != 0)
                {
                    var od = new OrderDatabase();
                    success = od.SetOrderAsPickedUp(orderId);
                }
                else
                {
                    MessageBox.Show("You must choose an order to set it as picked up.");
                }

                //if updated in database successfully, then update admins data and inform him of success
                if (success)
                {
                    UserControls.ShowUserInfo();
                    MessageBox.Show($"#{orderId}: {title} has been picked up successfully.");

                    Close();
                }
            }
            catch
            {
                MessageBox.Show("You must choose a product to be picked up.");
            }

        }
    }
}
