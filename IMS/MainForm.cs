using IMS.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using VideoGameInventoryApp;
using VideoGameInventoryApp.Classes;

namespace IMS
{
    //BASICS:
    //Inventory, Orders, Products and LoadDatabase are classes currently built.

    //Inventory has the majority of the functionalities required on UML, Orders and Products are currently
    //just shells with some members and a constructor to load data and store in lists.

    //Database class and database mdf file are all in the database folder, must load mdf file and change connection string in LoadDatabase class to retrieve data
    //All remaining classes built are currently in classes folder
    public partial class MainForm : Form
    {
        List<Products> ProductList = new List<Products>();
        List<Orders> OrderList = new List<Orders>();
        private bool LoggedIn;

        public MainForm()
        {
            InitializeComponent();
            LoadProductData();
        }

        //Currently loads all data in database -- when login is implemented, will need to load data according to type of user (admin - show all data) (user - show their data only)
        public void LoadProductData()
        {
            //load database and pass to inventory class constructor
            var db = new LoadDatabase();
            var inv = new Inventory(db.GetGameInformation(), db.GetOrderInformation());

            ProductList = inv.ProductList;
            OrderList = inv.OrderList;

            //check for clearance and low inventory and set notification panel alert messages accordingly
            inv.CheckForClearance();
            List<string> alertMessages = inv.AlertLowInventory();
            lbNotifications.DataSource = alertMessages;

            int totalNotifications = alertMessages.Count;
            txtNotification.Text = $"Notification Center: {totalNotifications} new notifications waiting for you as of {DateTime.Now.Date.ToString("D")}";

            //bind the inventory lists and add to their respective tables
            var productData = new BindingList<Products>(inv.ProductList);
            dataGridInventory.DataSource = productData;
            dataGridInventory.ReadOnly = true;

            var orderData = new BindingList<Orders>(inv.OrderList);
            dataGridOrders.DataSource = orderData;
            dataGridOrders.ReadOnly = true;

            //show login or logout button depending on login state
            if (LoggedIn)
            {
                btnLogin.Visible = false;
                btnLogout.Visible = true;
            }
            else
            {
                btnLogin.Visible = true;
                btnLogout.Visible = false;
                pnlAdmin.Visible = false;
            }
        }

        //basic search based on exact match between input and table selected
        public void Search()
        {
            var inv = new Inventory(ProductList, OrderList);

            switch (boxSearch.Text)
            {
                case "Inventory":
                    var inventorySearch = inv.SearchProducts(txtSearch.Text);
                    dataGridInventory.DataSource = inventorySearch;
                    break;
                case "Orders":
                    var orderSearch = inv.SearchOrders(txtSearch.Text);
                    dataGridOrders.DataSource = orderSearch;
                    break;
            }
        }

        //show all pre orders available in product table
        private void btnPreOrderInv_Click(object sender, EventArgs e)
        {
            var inv = new Inventory(ProductList, OrderList);
            var searchForPreOrder = inv.CheckIfPreOrderInventory();

            dataGridInventory.DataSource = searchForPreOrder;

            dataGridInventory.ClearSelection();
            for (int i = 0; i < dataGridInventory.RowCount; i++)
                dataGridInventory[3, i].Selected = true;
        }

        private void btnResetInventory_Click(object sender, EventArgs e)
        {
            dataGridInventory.DataSource = ProductList;
        }

        //show all pre orders available in the orders table
        private void btnSeeAllPreOrders_Click(object sender, EventArgs e)
        {
            var inv = new Inventory(ProductList, OrderList);
            var searchForPreOrder = inv.CheckIfPreOrderOrders();

            dataGridOrders.DataSource = searchForPreOrder;
        }

        private void btnResetOrders_Click(object sender, EventArgs e)
        {
            dataGridOrders.DataSource = OrderList;
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            boxSearch.DropDownStyle = ComboBoxStyle.DropDownList;
            boxSearch.Items.Add("Orders");
            boxSearch.SelectedIndex = 0;
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Search();
            }
        }

        private void btnSearch_Click(object sender, System.EventArgs e)
        {
            Search();
        }

        //Hide button just shows you what would be available if you logged in as an administrator. Right side of window would be all admin controls, tables to view etc
        private void btnHideTest_Click(object sender, EventArgs e)
        {
            //change basic layout/how user sees data, buttons, etc based on admin vs non admin (will need to set up user panel according to specific users)
            if (pnlAdmin.Visible)
            {
                pnlAdmin.Visible = false;
                btnModifyOrders.Visible = false;
                btnDeleteOrders.Visible = false;
                btnAddOrder.Text = "Place Order";
                btnSeeAllPreOrders.Text = "See My Pre-Orders";
                btnHideTest.Text = "Show";
                boxSearch.Items.Remove("Inventory");
            }
            else
            {
                pnlAdmin.Visible = true;
                btnModifyOrders.Visible = true;
                btnDeleteOrders.Visible = true;
                btnAddOrder.Text = "Add Order";
                btnSeeAllPreOrders.Text = "See All Pre-Orders";
                btnHideTest.Text = "Hide";
                boxSearch.Items.Add("Inventory");
            }
        }
    }
}