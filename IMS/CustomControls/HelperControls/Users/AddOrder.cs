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
            boxWhichProduct.DropDownStyle = ComboBoxStyle.DropDownList;
            boxWhichProduct.Items.Add("Pick a game");
            boxWhichProduct.SelectedIndex = 0;


            foreach (var p in ProductList)
            {
                int timeSinceRelease = (DateTime.Now.Year - p.ReleaseDate.Year) * 12 + DateTime.Now.Month - p.ReleaseDate.Month;
                //only add to games that can be ordered if there's a quantity greater then 0 or it's a PreOrder game
                if (p.Quantity > 0 || timeSinceRelease < 0)
                {
                    boxWhichProduct.Items.Add($"{p.GameID}: {p.Title}");
                }
            }

            boxWhichLocation.DropDownStyle = ComboBoxStyle.DropDownList;
            boxWhichLocation.Items.Add("Pickup location");
            boxWhichLocation.SelectedIndex = 0;

            boxWhichLocation.Items.Add("415 19th Street SE, Calgary");
            boxWhichLocation.Items.Add("2991 13th Avenue NE, Calgary");
            boxWhichLocation.Items.Add("17-299 2nd Street NW, Calgary");

            txtEmail.Enabled = false;
            txtName.Enabled = false;
            txtPrice.Enabled = false;
            GetCustomerInformation();
        }

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
                txtName.Text = name;
                txtEmail.Text = email;
            }
        }
        private void boxWhichProduct_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (boxWhichProduct.SelectedIndex != 0)
            {
                string[] productArr = boxWhichProduct.Text.Split(':');
                string gameId = productArr[0].Trim();
                string title = productArr[1].Trim();

                foreach (var p in ProductList)
                {
                    if (p.GameID.ToString() == gameId && p.Title == title)
                    {
                        Quantity = p.Quantity;
                        txtPrice.Text = p.Price.ToString();

                        int timeSinceRelease = (DateTime.Now.Year - p.ReleaseDate.Year) * 12 + DateTime.Now.Month - p.ReleaseDate.Month;
                        if (timeSinceRelease < 0)
                        {
                            MessageBox.Show(
                                $"{p.Title} is a pre-order. Please note you will not be able to pickup until after {p.ReleaseDate.ToString("YYYY-MM-DD")}.");

                        }
                    }
                }
            }
            else
            {
                txtPrice.Text = "";
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
                successInsert = InsertIntoOrders(connection, CustomerID, gameId, price);
                successUpdate = UpdateGameInfo(connection, gameId);
                successSelect = SelectOrderID(connection);
                connection.Close();
            }

            if (successInsert && successSelect && successUpdate)
            {
                OrderList.Add(new Orders(Convert.ToInt32(OrderID), CustomerID, Convert.ToInt32(gameId), Convert.ToDouble(price), Convert.ToDateTime(DateTime.Now)));
                UserControls.AddNewOrder(OrderList);

                MessageBox.Show($"{txtName.Text} has ordered {title} for pickup at {boxWhichLocation.Text}. You will get recieve an email at {txtEmail.Text} when it's ready for pickup.");
                Close();
            }
        }

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


