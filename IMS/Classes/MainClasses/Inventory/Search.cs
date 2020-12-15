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

        //Basic search function to check if input search value matches lists values
        public BindingList<Products> SearchProductsAll(string searchValue)
        {
            searchValue = searchValue.Trim().ToLower();

            var productSearch = ProductList.Where(p => p.GetType().GetProperties()
                .Any(prop => prop.GetValue(p, null) != null && prop.GetValue(p, null).ToString().ToLower()
                    .Contains(searchValue))).ToList();

            return new BindingList<Products>(productSearch);
        }

        //same as above method except for searching order table
        public BindingList<Orders> SearchOrdersAll(string searchValue)
        {
            searchValue = searchValue.Trim().ToLower();

            var orderSearch = OrderList.Where(o => o.GetType().GetProperties()
                .Any(prop => prop.GetValue(o, null) != null && prop.GetValue(o, null).ToString().ToLower()
                    .Contains(searchValue))).ToList();

            return new BindingList<Orders>(orderSearch);
        }

        //search properties specific by users for the product table
        public BindingList<Products> SearchProductsSpecifyHeader(string searchValue, string searchProperty)
        {
            searchValue = searchValue.Trim().ToLower();
            searchProperty = searchProperty.Trim();

            var productSearch = ProductList.Where(p =>
                p.GetType().GetProperty(searchProperty).GetValue(p, null) != null &&
                p.GetType().GetProperty(searchProperty).GetValue(p, null).ToString().ToLower().Contains(searchValue)).ToList();

            return new BindingList<Products>(productSearch);
        }

        //same as above method except for searching order table
        public BindingList<Orders> SearchOrdersSpecifyHeader(string searchValue, string searchProperty)
        {
            searchValue = searchValue.Trim().ToLower();
            searchProperty = searchProperty.Trim();

            var orderSearch = OrderList.Where(o =>
                o.GetType().GetProperty(searchProperty).GetValue(o, null) != null &&
                o.GetType().GetProperty(searchProperty).GetValue(o, null).ToString().ToLower().Contains(searchValue)).ToList();

            return new BindingList<Orders>(orderSearch);
        }
    }
}
