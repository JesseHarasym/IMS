using IMS.Classes;
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

            //fill loaded dropdown menu with the first index's header info (orders)
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

        private void boxSearchTable_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (boxSearchTable.SelectedIndex == 0)
            {
                //clear previous options added and reset up combo box
                boxSearchHeader.Items.Clear();
                boxSearchHeader.Items.Add("Any");
                boxSearchHeader.SelectedIndex = 0;
                //if the first choice i chosen, fill properties for orders
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

            dataGridOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }

        //basics of search which is queries in our inventory class
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
                        AdminControl.ErrorSearching(dataGridOrders, "Orders");   //check if search was empty for orders and if so give error
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
                        AdminControl.ErrorSearching(dataGridOrders, "Orders");
                        break;
                }
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
            var addOrderForm = new AddOrder(this, ProductList, CustomerId);
            addOrderForm.ShowDialog();
        }

        private void btnCancelOrders_Click(object sender, EventArgs e)
        {
            var cancelOrderForm = new CancelOrders(this, ProductList, OrderList);
            cancelOrderForm.ShowDialog();
        }

        private void btnOrderPickups_Click(object sender, EventArgs e)
        {
            var setOrderPickedUp = new OrderPickup(this, OrderList);
            setOrderPickedUp.ShowDialog();
        }
    }
}