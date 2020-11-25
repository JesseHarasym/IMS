using System;

namespace VideoGameInventoryApp.Classes
{
    public class Orders
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }

        public int ProductIDPurchased { get; set; }
        public double PurchasePrice { get; set; }
        public DateTime PurchaseDate { get; set; }
        public bool PreOrder { get; set; }

        public Orders(int orderID, int customerID, int productIDPurchased, double purchasePrice, DateTime purchaseDate)
        {
            OrderID = orderID;
            CustomerID = customerID;
            ProductIDPurchased = productIDPurchased;
            PurchasePrice = purchasePrice;
            PurchaseDate = purchaseDate;
        }
    }
}