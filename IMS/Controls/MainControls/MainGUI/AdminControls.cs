using IMS.Classes;
using IMS.Classes.Database.Accounts;
using IMS.Classes.MainClasses.Accounts;
using IMS.Controls.HelperControls.Admin;
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
        List<Notifications> NotificationList = new List<Notifications>();
        public int CustomerId;
        public int AccessLevel;

        public AdminControls(int customerId, int accessLevel)
        {
            InitializeComponent();
            CustomerId = customerId;
            AccessLevel = accessLevel;
            AdminSetup();
        }

        //load database and get all relevant admin information for gui
        public void AdminSetup()
        {
            var db = new InventoryLoad();
            var inv = new Inventory(db.GetGameInformation(), db.GetOrderInformation(), db.GetNotificationInformation(), AccessLevel, CustomerId);

            ProductList = inv.ProductList;
            OrderList = inv.OrderList;
            NotificationList = inv.NotificationList;

            //setup admins notification table
            foreach (var n in NotificationList)
            {
                if (!n.Dismissed)   //if an admin has not yet dismissed notification, then display it
                {
                    lbNotifications.Items.Add(n.Message);
                }
            }

            int totalNotifications = lbNotifications.Items.Count;
            txtNotification.Text = $"Notification Center: {totalNotifications} new notifications waiting for you as of {DateTime.Now.Date.ToString("D")}";

            //show products on admins inventory table
            var productData = new BindingList<Products>(inv.ProductList);
            dataGridInventory.DataSource = productData;
            dataGridInventory.ReadOnly = true;
            dataGridInventory.ScrollBars = ScrollBars.Vertical;
        }

        //so that an admin is able to choose a notification and dismiss it
        private void btnDismissNotification_Click(object sender, EventArgs e)
        {
            string message = lbNotifications.Text;

            //try to update dismissed value in notifications table, if successful then remove from list
            var ad = new AccountsDatabase();
            bool success = ad.UpdateNotificationsDismissed(message, true);

            if (success)
            {
                lbNotifications.Items.Remove(message);
                MessageBox.Show("Notification has been dismissed.");
            }
            else
            {
                MessageBox.Show("There was an issue while trying to dismiss this notification.");
            }
        }

        //apply search to data grid inventory that you receive from the user control 
        public void SearchInventory(BindingList<Products> inventorySearch)
        {
            dataGridInventory.DataSource = inventorySearch;
            ErrorSearching();
        }

        //error message if nothing was found from search criteria
        public void ErrorSearching()
        {
            if (dataGridInventory.Rows.Count == 0)
            {
                MessageBox.Show($"There was nothing found that matches your search criteria in Inventory");
            }
        }

        //add all properties of inventory class to be used as 'header search' criteria for inventory table
        public ComboBox AddInventorySearchHeaders(ComboBox boxSearchHeader)
        {
            for (int i = 0; i < dataGridInventory.ColumnCount; i++)
            {
                boxSearchHeader.Items.Add(dataGridInventory.Columns[i].HeaderText);
            }
            return boxSearchHeader;
        }

        //highlight the pre ordered game when clicking button 
        private void btnPreOrderInv_Click(object sender, EventArgs e)
        {
            var inv = new Inventory(ProductList, OrderList, NotificationList, AccessLevel, CustomerId);
            var searchForPreOrder = inv.CheckIfPreOrderInventory();

            dataGridInventory.DataSource = searchForPreOrder;

            dataGridInventory.ClearSelection();
            for (int i = 0; i < dataGridInventory.RowCount; i++)
            {
                dataGridInventory[3, i].Selected = true;
            }
        }

        //reset data grid from viewing pre orders or searching
        private void btnReset_Click(object sender, EventArgs e)
        {
            dataGridInventory.DataSource = ProductList;
        }

        //add a new product through form
        private void btnAddProducts_Click(object sender, EventArgs e)
        {
            var addProductForm = new AddProducts(this);
            addProductForm.ShowDialog();
        }

        //edit a product through form
        private void btnEditProducts_Click(object sender, EventArgs e)
        {
            var editProductForm = new EditProducts(this, ProductList);
            editProductForm.ShowDialog();
        }

        //delete a product through form
        private void btnDeleteProducts_Click(object sender, EventArgs e)
        {
            var deleteProductForm = new DeleteProducts(this, ProductList);
            deleteProductForm.ShowDialog();
        }

        //allow admins to add quantity of product when new stock arrives
        private void btnQuantity_Click(object sender, EventArgs e)
        {
            var addProductQuantity = new AddQuantity(this, ProductList);
            addProductQuantity.ShowDialog();
        }
    }
}
