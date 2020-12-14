using IMS.Database;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using VideoGameInventoryApp.Classes;

namespace IMS.CustomControls.HelperControls.Users
{
    public partial class AddOrder : Form
    {
        UserControls UserControls;
        List<Products> ProductList;
        int CustomerID;
        int Quantity;

        public AddOrder(UserControls userControl, List<Products> productList, int customerId)
        {
            InitializeComponent();
            UserControls = userControl;
            ProductList = productList;
            CustomerID = customerId;
        }

        private void AddOrder_Load(object sender, System.EventArgs e)
        {
            //which product dropdown setup
            boxWhichProduct.DropDownStyle = ComboBoxStyle.DropDownList;
            boxWhichProduct.Items.Add("Pick a game");
            boxWhichProduct.SelectedIndex = 0;

            //which location dropdown setup
            boxWhichLocation.DropDownStyle = ComboBoxStyle.DropDownList;
            boxWhichLocation.Items.Add("Pickup location");
            boxWhichLocation.SelectedIndex = 0;

            //fake locations for pickup for ordering purposes
            boxWhichLocation.Items.Add("415 19th Street SE, Calgary");
            boxWhichLocation.Items.Add("2991 13th Avenue NE, Calgary");
            boxWhichLocation.Items.Add("17-299 2nd Street NW, Calgary");

            //find product in order list and add to dropdown
            foreach (var p in ProductList)
            {
                int timeSinceRelease = (DateTime.Now.Year - p.ReleaseDate.Year) * 12 + DateTime.Now.Month - p.ReleaseDate.Month;
                //only add to games that can be ordered if there's a quantity greater then 0 or it's a PreOrder game
                if (p.Quantity > 0 || timeSinceRelease < 0)
                {
                    boxWhichProduct.Items.Add($"{p.GameID}: {p.Title}");
                }
            }

            //don't allow user to edit these inputs
            txtEmail.Enabled = false;
            txtName.Enabled = false;
            txtPrice.Enabled = false;

            //auto fill disabled inputs with users information
            var od = new OrderDatabase();
            var customerInfo = od.GetCustomerInformation(CustomerID);
            bool success = customerInfo.Item1;
            string name = customerInfo.Item2;
            string email = customerInfo.Item3;

            if (success)
            {
                txtName.Text = name;
                txtEmail.Text = email;
            }
        }

        //when the user selects an option from the dropdown
        private void boxWhichProduct_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (boxWhichProduct.SelectedIndex != 0) //if the user selects an option
            {
                string[] productArr = boxWhichProduct.Text.Split(':');
                string gameId = productArr[0].Trim();
                string title = productArr[1].Trim();

                foreach (var p in ProductList)
                {
                    if (p.GameID.ToString() == gameId && p.Title == title)
                    {
                        //track quantity for subtracting from later
                        Quantity = p.Quantity;
                        //add current available price
                        txtPrice.Text = p.Price.ToString();

                        //if the game is a preorder game, then make sure the user is aware the pickup time wont be until n date
                        int timeSinceRelease = (DateTime.Now.Year - p.ReleaseDate.Year) * 12 + DateTime.Now.Month -
                                               p.ReleaseDate.Month;
                        if (timeSinceRelease < 0)
                        {
                            MessageBox.Show(
                                $"{p.Title} is a pre-order. Please note you will not be able to pickup until after {p.ReleaseDate.Date}.");
                        }
                    }
                }
            }
            else
            {
                txtPrice.Text = ""; //reset price if user deselects a game option
            }
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            string[] productArr = boxWhichProduct.Text.Split(':');
            int gameId = Convert.ToInt32(productArr[0].Trim());
            string title = productArr[1].Trim();
            double price = Convert.ToDouble(txtPrice.Text);

            var od = new OrderDatabase();
            bool successInsert = od.InsertIntoOrders(CustomerID, gameId, price);
            bool successUpdate = od.UpdateGameInfo(gameId, Quantity);

            bool success = CheckUserOrder(successInsert, successUpdate);

            //removed select for order id.. see if it will update fine with new setup?
            if (success)
            {
                UserControls.ShowUserInfo(); //get newly entered information for our user

                MessageBox.Show(
                    $"{txtName.Text} has ordered {title} for pickup at {boxWhichLocation.Text}. You will get recieve an email at {txtEmail.Text} when it's ready for pickup.");

                Close();
            }
        }

        public bool CheckUserOrder(bool successInsert, bool successUpdate)
        {
            if (!successInsert)
            {
                MessageBox.Show("There was an issue with your order.");
                return false;
            }

            if (!successUpdate)
            {
                MessageBox.Show("There was an issue with our stock quantities.");
                return false;
            }

            return true;
        }
    }
}


