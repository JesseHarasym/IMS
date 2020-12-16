using System;

namespace VideoGameInventoryApp.Classes
{
    //just a basic class setup so that we can store instances of this class in an OrderList
    public class Orders
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public double OrderPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public string PickupAddress { get; set; }
        public bool PickedUp { get; set; }
        public bool PreOrder { get; set; }

        public Orders(int orderID, int customerID, int productId, string productName, double orderPrice, DateTime orderDate, string pickupAddress, bool pickedUp)
        {
            OrderID = orderID;
            CustomerID = customerID;
            ProductID = productId;
            ProductName = productName;
            OrderPrice = orderPrice;
            OrderDate = orderDate;
            PickupAddress = pickupAddress;
            PickedUp = pickedUp;
        }
    }
}