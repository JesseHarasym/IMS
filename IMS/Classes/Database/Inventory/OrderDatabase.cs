using System;
using System.Data.SqlClient;

namespace IMS.Database
{
    class OrderDatabase
    {
        string connectionString = Connection.ConnectionString;

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

        //delete the order from the database according to user supplied information
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

        //so admins can set any order as picked up when a user has came and paid/picked up the game
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
