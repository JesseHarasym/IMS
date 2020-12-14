using IMS.Database;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using VideoGameInventoryApp.Classes;

namespace IMS.CustomControls.HelperControls.Users
{
    public partial class AddOrder : Form
    {
        UserControls UserControls;
        List<Products> ProductList;
        List<Orders> OrderList;
        int CustomerID;
        int OrderID;
        int Quantity;

        public AddOrder(UserControls userControl, List<Products> productList, List<Orders> orderList, int customerId)
        {
            InitializeComponent();
            UserControls = userControl;
            ProductList = productList;
            OrderList = orderList;
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
            GetCustomerInformation();
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
                        int timeSinceRelease = (DateTime.Now.Year - p.ReleaseDate.Year) * 12 + DateTime.Now.Month - p.ReleaseDate.Month;
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
            bool successInsert;
            bool successUpdate;
            bool successSelect;

            string[] productArr = boxWhichProduct.Text.Split(':');
            int gameId = Convert.ToInt32(productArr[0].Trim());
            string title = productArr[1].Trim();
            double price = Convert.ToDouble(txtPrice.Text);

            string connectionString = Connection.ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //database queries broken down into functions so they're easier to look at/edit separately as needed
                successInsert = InsertIntoOrders(connection, CustomerID, gameId, price);
                successUpdate = UpdateGameInfo(connection, gameId);
                successSelect = SelectOrderID(connection);
                connection.Close();
            }

            if (successInsert && successSelect && successUpdate)
            {
                OrderList.Add(new Orders(Convert.ToInt32(OrderID), CustomerID, Convert.ToInt32(gameId), Convert.ToDouble(price), Convert.ToDateTime(DateTime.Now)));
                UserControls.ShowUserInfo(); //get newly entered information for our user

                MessageBox.Show($"{txtName.Text} has ordered {title} for pickup at {boxWhichLocation.Text}. You will get recieve an email at {txtEmail.Text} when it's ready for pickup.");
                Close();
            }
        }

        //get customer information that we dont save locally so that we are able to fill it in our form
        public void GetCustomerInformation()
        {
            bool success = false;

            string name = "";
            string email = "";

            string connectionString = Connection.ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(
                    $"SELECT * FROM Accounts WHERE Id = {CustomerID}", connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            try
                            {
                                name = reader["Name"].ToString();
                                email = reader["Email"].ToString();
                                success = true;
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("There was an issue retrieving the user information." + ex);
                            }
                        }
                    }
                    connection.Close();
                }
            }
            if (success)
            {
                //if you found the user in the db, then add to text boxes
                txtName.Text = name;
                txtEmail.Text = email;
            }
        }

        //insert our new order made by user into the database
        public bool InsertIntoOrders(SqlConnection connection, int customerId, int gameId, double price)
        {
            bool successInsert = false;
            using (SqlCommand cmd = new SqlCommand(
                $"INSERT INTO OrderInformation (CustomerID, ProductID, OrderPrice, OrderDate)" +
                $"VALUES (@customerId, @productId, @orderPrice, @orderDate)", connection))
            {
                cmd.Parameters.AddWithValue("@customerId", customerId);
                cmd.Parameters.AddWithValue("@productId", gameId);
                cmd.Parameters.AddWithValue("@orderPrice", price);
                cmd.Parameters.AddWithValue("@orderDate", DateTime.Now);

                connection.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                    successInsert = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("There was an issue inserting the new order information" + ex);
                    MessageBox.Show("There was an issue with your order..");
                }
            }

            return successInsert;
        }

        //update our game info with the new quantity after the game was ordered
        public bool UpdateGameInfo(SqlConnection connection, int gameId)
        {
            bool successUpdate = false;
            using (SqlCommand cmd =
                new SqlCommand($"UPDATE GameInformation SET Quantity = @quantity WHERE GameID = {gameId}", connection))
            {
                try
                {
                    cmd.Parameters.AddWithValue("@quantity", Quantity - 1);
                    cmd.ExecuteNonQuery();
                    successUpdate = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("There was an issue updating the quantity in the game information." + ex);
                    MessageBox.Show("There was an issue with our stock quantities..");
                }

            }
            return successUpdate;
        }

        //get the orderId so that we ensure we track the id properly (as it's identity(1, 1) in db, so it may not be next number in sequence from last
        public bool SelectOrderID(SqlConnection connection)
        {
            bool successSelect = false;

            using (SqlCommand cmd = new SqlCommand(
                $"SELECT TOP 1 * FROM OrderInformation ORDER BY OrderID DESC ", connection))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        try
                        {
                            string orderId = reader["OrderID"].ToString();
                            OrderID = Convert.ToInt32(orderId);
                            successSelect = true;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("There was an issue selecting the new order id" + ex);
                            MessageBox.Show("There was an issue creating your new order id..");
                        }

                    }
                }

            }
            return successSelect;
        }
    }
}


