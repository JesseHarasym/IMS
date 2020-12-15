using System;

namespace VideoGameInventoryApp.Classes
{
    public class Products
    {
        public int GameID { get; set; }
        public string Title { get; set; }
        public int Quantity { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; }
        public string Console { get; set; }
        public double Price { get; set; }
        public bool Clearance { get; set; }

        public Products(int gameID, string title, int quantity, DateTime releaseDate, string description, string console,
            double price)
        {
            GameID = gameID;
            Title = title;
            Quantity = quantity;
            ReleaseDate = releaseDate;
            Description = description;
            Console = console;
            Price = price;
        }
    }
}
