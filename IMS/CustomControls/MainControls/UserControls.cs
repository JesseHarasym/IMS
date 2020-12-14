﻿using IMS.Classes;
using IMS.CustomControls.HelperControls.Users;
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
            ShowUserInfo();
        }

        public UserControls(AdminControls adminControls, int customerId, int accessLevel)
        {
            InitializeComponent();
            AdminControl = adminControls;
            CustomerId = customerId;
            AccessLevel = accessLevel;
            ShowUserInfo();
        }

        private void UserControls_Load(object sender, EventArgs e)
        {
            //setup dropdown menu
            boxSearch.DropDownStyle = ComboBoxStyle.DropDownList;
            boxSearch.Items.Add("Orders");
            boxSearch.SelectedIndex = 0;

            if (AccessLevel == 0)
            {
                btnAddOrder.Visible = true;
                btnCancelOrders.Visible = true;
                btnAddOrder.Text = "Place Order";
                btnSeeAlllPreOrders.Text = "See My Pre-Orders";
                boxSearch.Items.Remove("Inventory");
            }
            else if (AccessLevel == 1)
            {
                btnAddOrder.Visible = false;
                btnCancelOrders.Visible = false;
                btnSeeAlllPreOrders.Text = "See All Pre-Orders";
                boxSearch.Items.Add("Inventory");
            }
        }

        public void ShowUserInfo()
        {
            //load database information and apply to our data grid
            var db = new LoadDatabase();
            var inv = new Inventory(db.GetGameInformation(), db.GetOrderInformation(), AccessLevel, CustomerId);

            ProductList = inv.ProductList;
            OrderList = inv.OrderList;

            var orderData = new BindingList<Orders>(inv.OrderList);
            dataGridOrders.DataSource = orderData;
            dataGridOrders.ReadOnly = true;
        }

        //basics of search which is queries in our inventory class
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

        //show all items in datagrid that are pre orders
        private void btnSeeAllPreOrders_Click(object sender, EventArgs e)
        {
            var inv = new Inventory(ProductList, OrderList, AccessLevel, CustomerId);
            var searchForPreOrder = inv.CheckIfPreOrderOrders();

            dataGridOrders.DataSource = searchForPreOrder;
        }

        //reset list after seeing preorders to default
        private void btnResetOrders_Click(object sender, EventArgs e)
        {
            dataGridOrders.DataSource = OrderList;
        }

        //allow users to create a new order
        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            var addOrderForm = new AddOrder(this, ProductList, OrderList, CustomerId);
            addOrderForm.Show();
        }
    }
}