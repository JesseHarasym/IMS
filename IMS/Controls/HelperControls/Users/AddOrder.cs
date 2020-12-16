using IMS.Classes.Database.Accounts;
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
        int QuantityInStock;
        int QuantitySold;
        int GameID;
        string Title;

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
            boxWhichProduct.DropDownHeight = boxWhichProduct.Font.Height * 10;  //only allow 10 items at a time while scrolling

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
                if (p.QuantityInStock > 0 || timeSinceRelease < 0)
                {
                    boxWhichProduct.Items.Add($"{p.GameID} ~ {p.Title}");
                }
            }

            //don't allow user to edit these inputs
            txtEmail.Enabled = false;
            txtName.Enabled = false;
            txtPrice.Enabled = false;

            //auto fill disabled inputs with logged in users information
            var ad = new AccountsDatabase(); ;
            var customerInfo = ad.GetAccountInformation(CustomerID);
            bool success = customerInfo.Item1;
            var user = customerInfo.Item2;

            if (success)
            {
                txtName.Text = user.Name;
                txtEmail.Text = user.Email;
            }

            MessageBox.Show("Please note that any orders not picked up within 30 days will be automatically cancelled.");
        }

        //when the user selects an option from the dropdown
        private void boxWhichProduct_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (boxWhichProduct.SelectedIndex != 0) //if the user selected a valid product
            {
                string[] productArr = boxWhichProduct.Text.Split('~');
                string gameId = productArr[0].Trim();

                foreach (var p in ProductList)
                {
                    if (p.GameID.ToString() == gameId)
                    {
                        //track quantity for subtracting from later
                        QuantityInStock = p.QuantityInStock;
                        QuantitySold = p.QuantitySold;
                        //track gameID and title for use later
                        GameID = p.GameID;
                        Title = p.Title;
                        //add current available price
                        txtPrice.Text = p.Price.ToString();

                        //if the game is a pre order game, then make sure the user is aware the pickup date wont be until n date
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
                txtPrice.Clear(); //reset price if user deselects a game option
            }
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            Double.TryParse(txtPrice.Text.Trim(), out var price);
            string pickupAddress = boxWhichLocation.Text;
            bool successInsert = false;
            bool successUpdate = false;

            //ensure combo box options are valid, if not display error to user
            bool success = CheckUserOrder();

            //if both combobox options have selected a valid option, then try to insert into orders and update game stock
            if (success)
            {
                var od = new OrderDatabase();
                var pd = new ProductDatabase();
                successInsert = od.InsertIntoOrders(CustomerID, GameID, Title, price, pickupAddress);
                successUpdate = pd.UpdateGameStockAfterOrder(GameID, QuantityInStock, QuantitySold, true);
            }

            //if database has been updated successfully then let user know and update their viewed data
            if (successInsert && successUpdate)
            {
                UserControls.ShowUserInfo();

                MessageBox.Show(
                    $"{txtName.Text} has ordered {Title} for pickup at {boxWhichLocation.Text}. You will get receive an email at {txtEmail.Text} when it's ready for pickup.");

                Close();
            }
        }

        //basic order validation to allow customized messages according to issue with input
        public bool CheckUserOrder()
        {
            if (boxWhichProduct.SelectedIndex == 0)
            {
                MessageBox.Show("You must choose a product to place an order.");
                return false;
            }

            if (boxWhichLocation.SelectedIndex == 0)
            {
                MessageBox.Show("You must choose a location to place an order.");
                return false;
            }
            return true;
        }
    }
}


