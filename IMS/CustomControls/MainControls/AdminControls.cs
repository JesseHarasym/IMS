using IMS.Classes;
using IMS.CustomControls.HelperControls;
using IMS.CustomControls.HelperControls.Admin;
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

        //load database and get all relavent admin information for gui
        public void AdminSetup()
        {
            var db = new LoadDatabase();
            var inv = new Inventory(db.GetGameInformation(), db.GetOrderInformation(), AccessLevel, CustomerId);

            ProductList = inv.ProductList;
            OrderList = inv.OrderList;

            //setup admins notification table
            inv.CheckForClearance();
            List<string> alertMessages = inv.AlertLowInventory();
            lbNotifications.DataSource = alertMessages;

            int totalNotifications = alertMessages.Count;
            txtNotification.Text = $"Notification Center: {totalNotifications} new notifications waiting for you as of {DateTime.Now.Date.ToString("D")}";

            //show products on admins inventory table
            var productData = new BindingList<Products>(inv.ProductList);
            dataGridInventory.DataSource = productData;
            dataGridInventory.ReadOnly = true;
        }

        //apply search to data grid inventory that you receive from the user control and inventory class
        public void SearchInventory(BindingList<Products> inventorySearch)
        {
            dataGridInventory.DataSource = inventorySearch;
        }

        //highlight the pre ordered game when clicking button
        private void btnPreOrderInv_Click(object sender, EventArgs e)
        {
            var inv = new Inventory(ProductList, OrderList, AccessLevel, CustomerId);
            var searchForPreOrder = inv.CheckIfPreOrderInventory();

            dataGridInventory.DataSource = searchForPreOrder;

            dataGridInventory.ClearSelection();
            for (int i = 0; i < dataGridInventory.RowCount; i++)
                dataGridInventory[3, i].Selected = true;
        }

        //reset data grid from viewing pre orders
        private void btnReset_Click(object sender, EventArgs e)
        {
            dataGridInventory.DataSource = ProductList;
        }

        //add a new product through form
        private void btnAddProducts_Click(object sender, EventArgs e)
        {
            var addProductForm = new AddProducts(this);
            addProductForm.Show();
        }

        //edit new product through form
        private void btnEditProducts_Click(object sender, EventArgs e)
        {
            var editProductForm = new EditProducts(this, ProductList);
            editProductForm.Show();
        }

        //delete new product through form
        private void btnDeleteProducts_Click(object sender, EventArgs e)
        {
            var deleteProductForm = new DeleteProducts(this, ProductList);
            deleteProductForm.Show();
        }
    }
}
