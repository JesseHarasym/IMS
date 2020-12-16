using System;

namespace VideoGameInventoryApp.Classes
{
    //just a basic class setup so that we can store instances of this class in a ProductList
    public class Products
    {
        public int GameID { get; set; }
        public string Title { get; set; }
        public int QuantityInStock { get; set; }
        public int QuantitySold { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Console { get; set; }
        public double Price { get; set; }
        public bool Clearance { get; set; }

        public Products(int gameID, string title, int quantityInStock, int quantitySold, DateTime releaseDate, string console, double price, bool clearance)
        {
            GameID = gameID;
            Title = title;
            QuantityInStock = quantityInStock;
            QuantitySold = quantitySold;
            ReleaseDate = releaseDate;
            Console = console;
            Price = price;
            Clearance = clearance;
        }
    }
}
