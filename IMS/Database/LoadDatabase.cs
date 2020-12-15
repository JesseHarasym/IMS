using IMS.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using VideoGameInventoryApp.Classes;

namespace IMS.Classes
{
    class LoadDatabase
    {
        string connectionString = Connection.ConnectionString;

        public List<Products> GetGameInformation()
        {
            List<Products> ProductList = new List<Products>();

            DataTable gameRecords = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand(
                    "SELECT * FROM GameInformation", connection);
                adapter.Fill(gameRecords);
                ProductList.Clear();

                for (int i = 0; i < gameRecords.Rows.Count; i++)
                {
                    DataRow drow = gameRecords.Rows[i];
                    string gameID = (drow["GameID"].ToString());
                    string title = (drow["Title"].ToString());
                    string quantity = (drow["Quantity"].ToString());
                    string releaseDate = (drow["ReleaseDate"].ToString());
                    string description = (drow["Description"].ToString());
                    string console = (drow["Console"].ToString());
                    string tempPrice = (drow["Price"].ToString());
                    double price = Convert.ToDouble(tempPrice);
                    price = Math.Round(price, 2);

                    ProductList.Add(new Products(Convert.ToInt32(gameID), title, Convert.ToInt32(quantity), Convert.ToDateTime(releaseDate), description, console, price));
                }
            }
            return ProductList;
        }

        public List<Orders> GetOrderInformation()
        {
            List<Orders> OrderList = new List<Orders>();

            DataTable gameRecords = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand(
                    "SELECT * FROM OrderInformation", connection);
                adapter.Fill(gameRecords);
                OrderList.Clear();

                for (int i = 0; i < gameRecords.Rows.Count; i++)
                {
                    DataRow drow = gameRecords.Rows[i];
                    string orderID = (drow["OrderID"].ToString());
                    string customerID = (drow["CustomerID"].ToString());
                    string productId = (drow["ProductID"].ToString());
                    string productName = (drow["ProductName"].ToString());
                    string tempPrice = (drow["OrderPrice"].ToString());
                    string orderDate = (drow["OrderDate"].ToString());
                    string pickupAddress = (drow["PickupAddress"].ToString());
                    string pickedUp = (drow["PickedUp"].ToString());

                    double purchasePrice = Convert.ToDouble(tempPrice);
                    purchasePrice = Math.Round(purchasePrice, 2);

                    OrderList.Add(new Orders(Convert.ToInt32(orderID), Convert.ToInt32(customerID), Convert.ToInt32(productId), productName, purchasePrice, Convert.ToDateTime(orderDate), pickupAddress, Convert.ToBoolean(pickedUp)));
                }
            }
            return OrderList;
        }
    }
}