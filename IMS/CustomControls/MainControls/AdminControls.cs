using IMS.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using VideoGameInventoryApp;
using VideoGameInventoryApp.Classes;

namespace IMS.CustomControls
{
    public partial class AdminControls : UserControl
    {
        List<Products> ProductList = new List<Products>();
        List<Orders> OrderList = new List<Orders>();
        public int CustomerId;
        public int AccessLevel;

        public AdminControls()
        {
            InitializeComponent();
        }

        public AdminControls(int customerId, int accessLevel)
        {
            InitializeComponent();
            CustomerId = customerId;
            AccessLevel = accessLevel;
            AdminSetup();
        }

        public void AdminSetup()
        {
            var db = new LoadDatabase();
            var inv = new Inventory(db.GetGameInformation(), db.GetOrderInformation(), AccessLevel, CustomerId);

            ProductList = inv.ProductList;
            OrderList = inv.OrderList;

            inv.CheckForClearance();
            List<string> alertMessages = inv.AlertLowInventory();
            lbNotifications.DataSource = alertMessages;

            int totalNotifications = alertMessages.Count;
            txtNotification.Text = $"Notification Center: {totalNotifications} new notifications waiting for you as of {DateTime.Now.Date.ToString("D")}";

            var productData = new BindingList<Products>(inv.ProductList);
            dataGridInventory.DataSource = productData;
            dataGridInventory.ReadOnly = true;
        }

        public void SearchInventory(BindingList<Products> inventorySearch)
        {
            dataGridInventory.DataSource = inventorySearch;
        }

        private void btnPreOrderInv_Click(object sender, EventArgs e)
        {
            var inv = new Inventory(ProductList, OrderList, AccessLevel, CustomerId);
            var searchForPreOrder = inv.CheckIfPreOrderInventory();

            dataGridInventory.DataSource = searchForPreOrder;

            dataGridInventory.ClearSelection();
            for (int i = 0; i < dataGridInventory.RowCount; i++)
                dataGridInventory[3, i].Selected = true;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            dataGridInventory.DataSource = ProductList;
        }
    }
}
