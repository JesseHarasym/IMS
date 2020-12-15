using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using VideoGameInventoryApp.Classes;

namespace IMS.Classes
{
    public class Search
    {
        public List<Products> ProductList = new List<Products>();
        public List<Orders> OrderList = new List<Orders>();
        public Search(List<Products> productList, List<Orders> orderList)
        {
            ProductList = productList;
            OrderList = orderList;
        }

        //Basic search function to check if input search value matches lists values exactly
        //would be better to change to not affected by capitals and use contains instead of exact match -- product table
        public BindingList<Products> SearchProducts(string searchValue)
        {
            var inventorySearch = new BindingList<Products>(ProductList.Select(p => p).ToList());
            bool parsable = double.TryParse(searchValue, out var numbSearchVal);    //check if the input is a number value
            searchValue = searchValue.Trim();

            //if parsable then search number related inventories
            if (parsable)
            {
                inventorySearch = new BindingList<Products>(ProductList
                    .Where(p =>
                        p.GameID == numbSearchVal || p.Quantity == numbSearchVal || p.Price == numbSearchVal)
                    .ToList());
            }
            else   //if not then ensure no empty string and search string based values
            {
                if (!String.IsNullOrEmpty(searchValue))
                {
                    inventorySearch = new BindingList<Products>(ProductList
                        .Where(p =>
                            p.Title == searchValue || p.ReleaseDate.ToString() == searchValue ||
                            p.Console == searchValue || p.Description == searchValue ||
                            p.Clearance.ToString() == searchValue).ToList());
                }
            }

            return inventorySearch;
        }

        //same as above method except for searching order table
        public BindingList<Orders> SearchOrders(string searchValue)
        {
            var orderSearch = new BindingList<Orders>(OrderList.Select(o => o).ToList());
            bool parsable = double.TryParse(searchValue, out var numbSearchVal);
            searchValue = searchValue.Trim();

            if (parsable)
            {
                orderSearch = new BindingList<Orders>(OrderList
                    .Where(o =>
                        o.OrderID == numbSearchVal || o.CustomerID == numbSearchVal ||
                        o.OrderPrice == numbSearchVal || o.ProductID == numbSearchVal).ToList());
            }
            else
            {
                if (searchValue != "")
                {
                    orderSearch = new BindingList<Orders>(OrderList
                        .Where(o =>
                            o.OrderDate.ToString() == searchValue).ToList());
                }
            }

            return orderSearch;
        }
    }
}
