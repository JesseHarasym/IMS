using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using VideoGameInventoryApp.Classes;

namespace VideoGameInventoryApp
{
    public class Inventory
    {
        public List<Products> ProductList = new List<Products>();
        public List<Orders> OrderList = new List<Orders>();
        public List<string> AlertMessages = new List<string>();

        public Inventory(List<Products> productList, List<Orders> orderList, int accessLevel, int customerId)
        {
            GetData(productList, orderList, accessLevel, customerId);
        }

        //only apply data needed for a specific user, if admin give access to everything, otherwise give according to their customerId
        public void GetData(List<Products> productList, List<Orders> orderList, int accessLevel, int customerId)
        {
            if (accessLevel == 1)
            {
                ProductList = productList;
                OrderList = orderList;
            }
            else
            {
                ProductList = productList;
                OrderList = orderList
                    .Where(o => o.CustomerID == customerId)
                    .ToList();
            }
            AddPreOrderToOrderList();   //load pre order state in orders list when class is created (do this way so today's date can be checked against release date)
        }

        //put a game on clearance if it is greater then 9 months old and less then 5 remaining(needs better formula for determining clearance)
        public List<Products> CheckForClearance()
        {
            foreach (var p in ProductList)
            {
                int months = MonthsSinceRelease(p.ReleaseDate);

                if (months > 9 & p.Quantity < 15)
                {
                    //slash price and add alert message for admin panel (may want to consider keeping original price in database as well as write clearance price when changed)
                    double originalPrice = p.Price;
                    p.Price = Math.Round(p.Price / 1.8, 2);
                    p.Clearance = true;

                    AlertMessages.Add($"ALERT: On Clearance - {p.GameID}: {p.Title} has been put on clearance. Price slashed to {p.Price} from {originalPrice}.");
                }
            }
            return ProductList;
        }

        //check inventory level and send an alert to notification center if below a threshold
        public List<string> AlertLowInventory()
        {
            int minQuantity = 10;

            foreach (var p in ProductList)
            {
                int months = MonthsSinceRelease(p.ReleaseDate);

                if (p.Quantity < minQuantity && months > 0)    //if quantity lower then 10 and not a pre order
                {
                    AlertMessages.Add($"ALERT: Low Stock - {p.GameID}: {p.Title} is low on inventory. Currently has {p.Quantity} remaining in stock.");
                }
            }
            return AlertMessages;
        }

        //if release date is after today's date then show as a pre order game - product table
        public BindingList<Products> CheckIfPreOrderInventory()
        {
            var preOrderSearch = new BindingList<Products>(ProductList
                .Where(p =>
                    MonthsSinceRelease(p.ReleaseDate) < 0)
                .ToList());

            return preOrderSearch;
        }

        //if pre order has been set and if so, return those results - order table
        public BindingList<Orders> CheckIfPreOrderOrders()
        {
            var preOrderSearch = new BindingList<Orders>(OrderList
                .Where(o => o.PreOrder)
                .ToList());

            return preOrderSearch;

        }

        //function to add comes to pre order list of CheckIfPreOrderInventory() has already determined it as such
        public List<Orders> AddPreOrderToOrderList()
        {
            var productSearch = CheckIfPreOrderInventory();

            foreach (var o in OrderList)
            {
                foreach (var p in productSearch)
                {
                    if (p.GameID == o.ProductID)
                    {
                        o.PreOrder = true;
                    }
                }
            }

            return OrderList;
        }

        //basic method to check the number of months between today's date and the release date of the game
        public int MonthsSinceRelease(DateTime releaseDate)
        {
            return (DateTime.Now.Year - releaseDate.Year) * 12 + DateTime.Now.Month - releaseDate.Month;
        }
    }
}
