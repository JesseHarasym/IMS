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
        public bool InsertIntoOrders(int customerId, int gameId, double price)
        {
            bool successInsert = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(
                    $"INSERT INTO OrderInformation (CustomerID, ProductID, OrderPrice, OrderDate)" +
                    $"VALUES (@customerId, @productId, @orderPrice, @orderDate)", connection))
                {
                    cmd.Parameters.AddWithValue("@customerId", customerId);
                    cmd.Parameters.AddWithValue("@productId", gameId);
                    cmd.Parameters.AddWithValue("@orderPrice", price);
                    cmd.Parameters.AddWithValue("@orderDate", DateTime.Now);

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

        //update our game info with the new quantity after the game was ordered
        public bool UpdateGameInfo(int gameId, int quantity)
        {
            bool successUpdate = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd =
                    new SqlCommand($"UPDATE GameInformation SET Quantity = @quantity WHERE GameID = {gameId}", connection))
                {
                    try
                    {
                        connection.Open();
                        cmd.Parameters.AddWithValue("@quantity", quantity - 1);
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
    }
}
