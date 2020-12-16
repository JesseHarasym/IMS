using IMS.Classes.Database.Accounts;
using IMS.Classes.MainClasses.Accounts;
using IMS.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using VideoGameInventoryApp.Classes;

namespace VideoGameInventoryApp
{
    public class Inventory
    {
        public List<Products> ProductList = new List<Products>();
        public List<Orders> OrderList = new List<Orders>();
        public List<Notifications> NotificationList = new List<Notifications>();

        public Inventory(List<Products> productList, List<Orders> orderList, List<Notifications> notificationList, int accessLevel, int customerId)
        {
            GetData(productList, orderList, notificationList, accessLevel, customerId);
        }

        //only apply data needed for a specific user, if admin give access to everything, otherwise give according to their customerId
        public void GetData(List<Products> productList, List<Orders> orderList, List<Notifications> notificationList, int accessLevel, int customerId)
        {
            if (accessLevel == 1)
            {
                ProductList = productList;
                OrderList = orderList;
                NotificationList = notificationList;

                //check for any relevant admin notification information
                CheckForClearance();
                AlertLowInventory();
            }
            else
            {
                ProductList = productList;
                OrderList = orderList
                    .Where(o => o.CustomerID == customerId)
                    .ToList();
            }

            AddPreOrderToOrderList();   //load pre order state in orders list when class is created (do this way so today's date can be checked against release date)
            CancelOrdersOver30Days(); //if an order is 30 days old with no pickup, automatically cancel it
        }

        //take the current product list and check for clearance items to inform admin notification panel
        public void CheckForClearance()
        {
            string type = "Clearance";
            foreach (var p in ProductList)
            {
                if (!p.Clearance)   //if item has not already been put on clearance
                {
                    int months = MonthsSinceDate(p.ReleaseDate);

                    //if a game is older then 4 years, has more then 30 left in stock, and has sold less then 80 in that time then put on clearance
                    //if a game is older then 8 years, has less then 25 left in stock, and hasn't sold more then 300 during that time, then put on clearance
                    if (months > 48 && p.QuantityInStock > 30 && p.QuantitySold < 80 || months > 96 && p.QuantityInStock < 25 && p.QuantitySold < 300)
                    {
                        //slash price, make clearance true and add alert message for admin panel 
                        double clearancePrice = Math.Round(p.Price / 1.8, 2);
                        string message = $"On Clearance - {p.GameID}: {p.Title} has been put on clearance. Price slashed to {clearancePrice} from {p.Price}.";

                        //func to check if message is new and if so then add it
                        bool success = AddNewNotification(message, type, p.GameID);

                        //if it was added as a new notification successfully, then we will change the price of the product
                        if (success)
                        {
                            var pd = new ProductDatabase();
                            pd.UpdateGamePrice(p.GameID, clearancePrice, true);
                        }
                    }
                }
            }
        }

        //check inventory level and send an alert to notification center if below a threshold
        public void AlertLowInventory()
        {
            string type = "Alert";
            int minQuantity = 15;   //min threshold

            foreach (var p in ProductList)
            {
                int months = MonthsSinceDate(p.ReleaseDate);

                //if quantity lower then set #, not a pre order, and not on clearance(implying they would plan on ordering more stock)
                if (p.QuantityInStock < minQuantity && months > 0 && !p.Clearance)
                {
                    string message = $"Low Stock - {p.GameID}: {p.Title} is low on inventory. Currently has {p.QuantityInStock} remaining in stock.";

                    //func to check if message is new and if so then add it
                    AddNewNotification(message, type, p.GameID);
                }
            }
        }

        //add new notifications if they don't yet exist in our notifications table
        public bool AddNewNotification(string message, string messageType, int productId)
        {
            bool success = false;
            //add to list and update database if the message is new
            if (!NotificationList.Any(m => m.MessageType.Contains(messageType) && m.ProductId.ToString().Contains(productId.ToString())))
            {
                var notification = new Notifications(message, false, messageType, productId);
                //add message to notifications database table so it can be dismissed
                var ad = new AccountsDatabase();
                success = ad.InsertAccountsNotifications(notification);

                //add to list if notifications have been successfully added to database
                if (success)
                {
                    NotificationList.Add(notification);
                }
            }

            return success;
        }

        //if release date is after today's date then show as a pre order game - product table
        public BindingList<Products> CheckIfPreOrderInventory()
        {
            var preOrderSearch = new BindingList<Products>(ProductList
                .Where(p =>
                    MonthsSinceDate(p.ReleaseDate) < 0)
                .ToList());

            return preOrderSearch;
        }

        //function to add games to pre order = true if CheckIfPreOrderInventory() has already determined it as such
        public List<Orders> AddPreOrderToOrderList()
        {
            var checkPreOrder = CheckIfPreOrderInventory();

            foreach (var o in OrderList)
            {
                foreach (var p in checkPreOrder)
                {
                    if (p.GameID == o.ProductID)
                    {
                        o.PreOrder = true;
                    }
                }
            }
            return OrderList;
        }

        //if pre order has been set and if so, return those results - order table
        public BindingList<Orders> CheckIfPreOrderOrders()
        {
            var checkPreOrder = new BindingList<Orders>(OrderList
                .Where(o => o.PreOrder)
                .ToList());

            return checkPreOrder;

        }

        //if an order is older then 30 days from today's date, and has not been picked up, then cancel the order 
        public void CancelOrdersOver30Days()
        {
            string type = "Cancellation";
            foreach (var o in OrderList)
            {
                if (MonthsSinceDate(o.OrderDate) >= 1)
                {
                    //find quantity of in stock and sold stock
                    int productQuantityInStock = ProductList.Where(p => p.GameID == o.ProductID)
                        .Select(p => p.QuantityInStock).First();

                    int productQuantitySold = ProductList.Where(p => p.GameID == o.ProductID)
                        .Select(p => p.QuantitySold).First();

                    try
                    {
                        var od = new OrderDatabase();
                        var pd = new ProductDatabase();
                        bool successDelete = od.DeleteUserOrder(o.OrderID);
                        bool successUpdate = pd.UpdateGameStockAfterOrder(o.ProductID, productQuantityInStock, productQuantitySold, false);

                        string message = $"Order Cancelled - Order #{o.OrderID} has been automatically cancelled due to 30 days no pickup.";

                        //if updated stock and deleted order successfully, add to admin notifications
                        if (successDelete && successUpdate)
                        {
                            //func to check if message is new and if so then add it
                            //use orderId instead of productId here so its a unique value for no pickup checks
                            AddNewNotification(message, type, o.OrderID);
                        }

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"There was an issue while trying to remove {o.OrderID} that's over 30 days old" + ex);
                    }

                }
            }
        }

        //basic method to check the number of months between today's date and the given date
        public int MonthsSinceDate(DateTime date)
        {
            return (DateTime.Now.Year - date.Year) * 12 + DateTime.Now.Month - date.Month;
        }
    }
}
