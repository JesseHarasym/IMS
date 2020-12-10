using IMS.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using VideoGameInventoryApp;
using VideoGameInventoryApp.Classes;

namespace IMS.CustomControls
{
    public partial class UserControls : UserControl
    {
        private AdminControls AdminControl;
        List<Products> ProductList = new List<Products>();
        List<Orders> OrderList = new List<Orders>();
        public int CustomerId;
        public int AccessLevel;

        public UserControls()
        {
            InitializeComponent();
        }

        public UserControls(int customerId, int accessLevel)
        {
            InitializeComponent();
            CustomerId = customerId;
            AccessLevel = accessLevel;
            UserSetup();
        }

        public UserControls(AdminControls adminControls, int customerId, int accessLevel)
        {
            InitializeComponent();
            AdminControl = adminControls;
            CustomerId = customerId;
            AccessLevel = accessLevel;
            UserSetup();
        }

        private void UserControls_Load(object sender, EventArgs e)
        {
            boxSearch.DropDownStyle = ComboBoxStyle.DropDownList;
            boxSearch.Items.Add("Orders");
            boxSearch.SelectedIndex = 0;
        }

        public void UserSetup()
        {
            if (AccessLevel == 0)
            {
                btnModifyOrders.Visible = false;
                btnDeleteOrders.Visible = false;
                btnAddOrder.Text = "Place Order";
                btnSeeAllPreOrders.Text = "See My Pre-Orders";
                boxSearch.Items.Remove("Inventory");
            }
            else if (AccessLevel == 1)
            {
                btnModifyOrders.Visible = true;
                btnDeleteOrders.Visible = true;
                btnAddOrder.Text = "Add Order";
                btnSeeAllPreOrders.Text = "See All Pre-Orders";
                boxSearch.Items.Add("Inventory");
            }
            ShowUserInfo();
        }

        public void ShowUserInfo()
        {
            var db = new LoadDatabase();
            var inv = new Inventory(db.GetGameInformation(), db.GetOrderInformation(), AccessLevel, CustomerId);

            ProductList = inv.ProductList;
            OrderList = inv.OrderList;

            var orderData = new BindingList<Orders>(inv.OrderList);
            dataGridOrders.DataSource = orderData;
            dataGridOrders.ReadOnly = true;
        }

        public void Search()
        {
            var inv = new Inventory(ProductList, OrderList, AccessLevel, CustomerId);

            switch (boxSearch.Text)
            {
                case "Inventory":
                    var inventorySearch = inv.SearchProducts(txtSearch.Text);
                    AdminControl.SearchInventory(inventorySearch);
                    break;
                case "Orders":
                    var orderSearch = inv.SearchOrders(txtSearch.Text);
                    dataGridOrders.DataSource = orderSearch;
                    break;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void btnSeeAllPreOrders_Click(object sender, EventArgs e)
        {
            var inv = new Inventory(ProductList, OrderList, AccessLevel, CustomerId);
            var searchForPreOrder = inv.CheckIfPreOrderOrders();

            dataGridOrders.DataSource = searchForPreOrder;
        }

        private void btnResetOrders_Click(object sender, EventArgs e)
        {
            dataGridOrders.DataSource = OrderList;
        }
    }
}