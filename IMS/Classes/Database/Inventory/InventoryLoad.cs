using IMS.Classes.MainClasses.Accounts;
using IMS.Database;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using VideoGameInventoryApp.Classes;

namespace IMS.Classes
{
    //this class is used for loading the initial data when an account logs into the application
    class InventoryLoad
    {
        string connectionString = Connection.ConnectionString;

        //retrieve all stored product information in the database to display to user
        public List<Products> GetGameInformation()
        {
            List<Products> ProductList = new List<Products>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand($"SELECT * FROM GameInformation", connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            try
                            {
                                string gameID = reader["GameID"].ToString();
                                string title = reader["Title"].ToString();
                                string quantityInStock = reader["QuantityInStock"].ToString();
                                string quantitySold = reader["QuantitySold"].ToString();
                                string releaseDate = reader["ReleaseDate"].ToString();
                                string console = reader["Console"].ToString();
                                string tempPrice = reader["Price"].ToString();
                                string clearance = reader["Clearance"].ToString();

                                double price = Convert.ToDouble(tempPrice);
                                price = Math.Round(price, 2);

                                ProductList.Add(new Products(Convert.ToInt32(gameID), title, Convert.ToInt32(quantityInStock), Convert.ToInt32(quantitySold), Convert.ToDateTime(releaseDate), console, price, Convert.ToBoolean(clearance)));
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("There was an issue retrieving the game information." + ex);
                            }
                        }
                    }
                    connection.Close();
                }
            }
            return ProductList;
        }

        //retrieve all stored order information in the database to display to user
        public List<Orders> GetOrderInformation()
        {
            List<Orders> OrderList = new List<Orders>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand($"SELECT * FROM OrderInformation", connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            try
                            {
                                string orderID = reader["OrderID"].ToString();
                                string customerID = reader["CustomerID"].ToString();
                                string productId = reader["ProductID"].ToString();
                                string productName = reader["ProductName"].ToString();
                                string tempPrice = reader["OrderPrice"].ToString();
                                string orderDate = reader["OrderDate"].ToString();
                                string pickupAddress = reader["PickupAddress"].ToString();
                                string pickedUp = reader["PickedUp"].ToString();

                                double purchasePrice = Convert.ToDouble(tempPrice);
                                purchasePrice = Math.Round(purchasePrice, 2);

                                OrderList.Add(new Orders(Convert.ToInt32(orderID), Convert.ToInt32(customerID), Convert.ToInt32(productId), productName, purchasePrice, Convert.ToDateTime(orderDate), pickupAddress, Convert.ToBoolean(pickedUp)));
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("There was an issue retrieving the orders information." + ex);
                            }
                        }
                    }
                    connection.Close();
                }
            }
            return OrderList;
        }

        //get all notifications saved so that we can determine if they're duplicates and allow them to be dismissed
        public List<Notifications> GetNotificationInformation()
        {
            List<Notifications> notifications = new List<Notifications>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand($"SELECT * FROM Notifications", connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            try
                            {
                                string message = reader["Message"].ToString();
                                string dismissed = reader["Dismissed"].ToString();
                                string messageType = reader["MessageType"].ToString();
                                string productid = reader["ProductId"].ToString();

                                notifications.Add(new Notifications(message, Convert.ToBoolean(dismissed), messageType, Convert.ToInt32(productid)));
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("There was an issue retrieving the notification information." + ex);
                            }
                        }
                    }
                    connection.Close();
                }
            }
            return notifications;
        }
    }
}