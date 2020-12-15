using System;
using System.Data.SqlClient;

namespace IMS.Database
{
    class OrderDatabase
    {
        string connectionString = Connection.ConnectionString;

        //get customer information that we dont save locally so that we are able to fill it in our form
        public Tuple<bool, string, string> GetCustomerInformation(int customerId)
        {
            bool success = false;

            string name = "";
            string email = "";

            string connectionString = Connection.ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand($"SELECT * FROM Accounts WHERE Id = @customerId", connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@customerId", customerId);

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

            return Tuple.Create(success, name, email);
        }


        //insert our new order made by user into the database
        public bool InsertIntoOrders(int customerId, int gameId, string title, double price, string pickupAddress)
        {
            bool successInsert = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(
                    $"INSERT INTO OrderInformation (CustomerID, ProductID, ProductName, OrderPrice, OrderDate, PickupAddress, PickedUp)" +
                    $"VALUES (@customerId, @productId, @productName, @orderPrice, @orderDate, @pickupAddress, @pickedUp)", connection))
                {
                    cmd.Parameters.AddWithValue("@customerId", customerId);
                    cmd.Parameters.AddWithValue("@productId", gameId);
                    cmd.Parameters.AddWithValue("@productName", title);
                    cmd.Parameters.AddWithValue("@orderPrice", price);
                    cmd.Parameters.AddWithValue("@orderDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@pickupAddress", pickupAddress);
                    cmd.Parameters.AddWithValue("@pickedUp", false);

                    try
                    {
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();
                        successInsert = true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("There was an issue inserting the new order information" + ex);
                    }
                }
            }
            return successInsert;
        }

        //update our game info with the new quantity after the game was ordered or cancelled
        public bool UpdateGameInfo(int gameId, int quantity, string addOrSubtract)
        {
            bool successUpdate = false;

            if (addOrSubtract == "-")
            {
                quantity = quantity - 1;
            }
            else if (addOrSubtract == "+")
            {
                quantity = quantity + 1;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd =
                    new SqlCommand($"UPDATE GameInformation SET Quantity = @quantity WHERE GameID = @gameId", connection))
                {
                    try
                    {
                        connection.Open();
                        cmd.Parameters.AddWithValue("@quantity", quantity);
                        cmd.Parameters.AddWithValue("@gameId", gameId);
                        cmd.ExecuteNonQuery();
                        connection.Close();
                        successUpdate = true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("There was an issue updating the quantity in the game information." + ex);
                    }
                }
            }
            return successUpdate;
        }

        public bool DeleteUserOrder(int orderId)
        {
            bool success = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //delete data from GameInformation database table
                using (SqlCommand cmd =
                    new SqlCommand($"DELETE FROM OrderInformation WHERE OrderID = @orderId", connection))
                {
                    try
                    {
                        connection.Open();
                        cmd.Parameters.AddWithValue("@orderId", orderId);
                        cmd.ExecuteNonQuery();
                        connection.Close();
                        success = true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("There was an issue deleting this order. " + ex);
                    }
                }
            }

            return success;
        }

        public bool SetOrderAsPickedUp(int orderId)
        {
            bool successUpdate = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd =
                    new SqlCommand($"UPDATE OrderInformation SET PickedUp = @pickedUp WHERE OrderID = @orderId", connection))
                {
                    try
                    {
                        connection.Open();
                        cmd.Parameters.AddWithValue("@pickedUp", true);
                        cmd.Parameters.AddWithValue("@orderId", orderId);
                        cmd.ExecuteNonQuery();
                        connection.Close();
                        successUpdate = true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("There was an issue updating the order to picked up." + ex);
                    }
                }
            }

            return successUpdate;
        }
    }
}
