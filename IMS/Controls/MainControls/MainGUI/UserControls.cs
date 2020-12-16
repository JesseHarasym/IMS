using IMS.Classes;
using IMS.Classes.MainClasses.Accounts;
using IMS.CustomControls.HelperControls.Admin;
using IMS.CustomControls.HelperControls.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
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
        List<Notifications> NotificationList = new List<Notifications>();
        public int CustomerId;
        public int AccessLevel;

        //for creating instance for regular users
        public UserControls(int customerId, int accessLevel)
        {
            InitializeComponent();
            CustomerId = customerId;
            AccessLevel = accessLevel;
            ShowUserInfo();
        }

        //for creating instance for admin users
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
            //setup dropdown menu to search which table
            boxSearchTable.DropDownStyle = ComboBoxStyle.DropDownList;
            boxSearchTable.Items.Add("Orders");
            boxSearchTable.SelectedIndex = 0;

            //setup dropdown menu to search which headers
            boxSearchHeader.DropDownStyle = ComboBoxStyle.DropDownList;
            boxSearchHeader.Items.Add("Any");
            boxSearchHeader.SelectedIndex = 0;

            //add all properties of orders class to be used as 'header search' criteria for orders table
            for (int i = 0; i < dataGridOrders.ColumnCount; i++)
            {
                boxSearchHeader.Items.Add(dataGridOrders.Columns[i].HeaderText);
            }

            //setup for regular users view
            if (AccessLevel == 0)
            {
                btnOrderPickups.Visible = false;
                btnAddOrder.Visible = true;
                btnSeeAlllPreOrders.Text = "See My Pre-Orders";
                boxSearchTable.Items.Remove("Inventory");
            }
            //setup for admins view
            else if (AccessLevel == 1)
            {
                btnOrderPickups.Visible = true;
                btnAddOrder.Visible = false;
                btnCancelOrders.Location = new Point(161, 116);
                btnSeeAlllPreOrders.Text = "See All Pre-Orders";
                boxSearchTable.Items.Add("Inventory");
            }
        }

        public void ShowUserInfo()
        {
            //load database information for the logged in user and apply to our data grid
            var db = new InventoryLoad();
            var inv = new Inventory(db.GetGameInformation(), db.GetOrderInformation(), db.GetNotificationInformation(), AccessLevel, CustomerId);

            ProductList = inv.ProductList;
            OrderList = inv.OrderList;

            var orderData = new BindingList<Orders>(inv.OrderList);
            dataGridOrders.DataSource = orderData;
            dataGridOrders.ReadOnly = true;

            dataGridOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }

        //if a user changed the search table from inventory/orders then refill the options as appropriate
        private void boxSearchTable_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (boxSearchTable.SelectedIndex == 0)
            {
                //clear previous options added and reset up combo box
                boxSearchHeader.Items.Clear();
                boxSearchHeader.Items.Add("Any");
                boxSearchHeader.SelectedIndex = 0;
                //if the first choice is chosen, fill properties for orders
                for (int i = 0; i < dataGridOrders.ColumnCount; i++)
                {
                    boxSearchHeader.Items.Add(dataGridOrders.Columns[i].HeaderText);
                }
            }
            else if (boxSearchTable.SelectedIndex == 1 && AccessLevel == 1)
            {
                //clear previous options added and reset up combo box
                boxSearchHeader.Items.Clear();
                boxSearchHeader.Items.Add("Any");
                boxSearchHeader.SelectedIndex = 0;
                //if second property is chosen, pass to admin panel to get header names and return filled combo box
                boxSearchHeader = AdminControl.AddInventorySearchHeaders(boxSearchHeader);
            }
        }

        //basics of search which is queries in our search class
        //get all search criteria and send it to the search class to be searched and a binding list returned to be displayed
        public void Search()
        {
            var search = new Search(ProductList, OrderList);
            string searchVal = txtSearch.Text;

            //if header index 0 is chosen ('Any' header) then search all available headers in the table
            if (boxSearchHeader.SelectedIndex == 0)
            {
                switch (boxSearchTable.Text)
                {
                    case "Inventory":
                        var inventorySearch = search.SearchProductsAll(searchVal);
                        AdminControl.SearchInventory(inventorySearch);
                        //inventories error checking is supplied directly at SearchInventory() func
                        break;
                    case "Orders":
                        var orderSearch = search.SearchOrdersAll(searchVal);
                        dataGridOrders.DataSource = orderSearch;
                        ErrorSearching();   //check if search was empty for orders and if so give error
                        break;
                }
            }
            //if any other index, assume they chose a header and search as appropriate
            else
            {
                //get text for currently selected item of header combo box
                string headerSelected = boxSearchHeader.GetItemText(boxSearchHeader.SelectedItem);
                switch (boxSearchTable.Text)
                {
                    case "Inventory":
                        var inventorySearch =
                            search.SearchProductsSpecifyHeader(searchVal, headerSelected);
                        AdminControl.SearchInventory(inventorySearch);
                        break;
                    case "Orders":
                        var orderSearch =
                            search.SearchOrdersSpecifyHeader(searchVal, headerSelected);
                        dataGridOrders.DataSource = orderSearch;
                        ErrorSearching();
                        break;
                }
            }
        }

        //if no results are found from a search, let user know
        public void ErrorSearching()
        {
            if (dataGridOrders.Rows.Count == 0)
            {
                MessageBox.Show($"There was nothing found that matches your search criteria in Orders");
            }
        }

        //show all items in DataGrid that are pre orders
        private void btnSeeAllPreOrders_Click(object sender, EventArgs e)
        {
            var inv = new Inventory(ProductList, OrderList, NotificationList, AccessLevel, CustomerId);
            var searchForPreOrder = inv.CheckIfPreOrderOrders();

            dataGridOrders.DataSource = searchForPreOrder;
        }

        //reset list after seeing Pre Orders to default
        private void btnResetOrders_Click(object sender, EventArgs e)
        {
            dataGridOrders.DataSource = OrderList;
        }

        //allow users to create a new order
        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            var addOrderForm = new AddOrder(this, ProductList, CustomerId);
            addOrderForm.ShowDialog();
        }

        //allow user to cancel orders not yet picked up
        private void btnCancelOrders_Click(object sender, EventArgs e)
        {
            var cancelOrderForm = new CancelOrders(this, ProductList, OrderList);
            cancelOrderForm.ShowDialog();
        }

        //allow admins to set orders users come and pay for as picked up
        private void btnOrderPickups_Click(object sender, EventArgs e)
        {
            var setOrderPickedUp = new OrderPickup(this, OrderList);
            setOrderPickedUp.ShowDialog();
        }

        //so search can be used with enter and button click
        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Search();
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }
    }
}