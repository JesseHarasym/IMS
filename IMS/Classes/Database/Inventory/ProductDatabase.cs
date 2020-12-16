using System;
using System.Data.SqlClient;

namespace IMS.Database
{
    class ProductDatabase
    {
        string connectionString = Connection.ConnectionString;

        //used to add new games to our database as supplied by an admin
        public bool InsertGameInfo(string title, int quantityInStock, DateTime releaseDate, string console, double price)
        {
            bool success = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(
                    $"INSERT INTO GameInformation (Title, QuantityInStock, QuantitySold, ReleaseDate, Console, Price, Clearance)" +
                    $"VALUES (@title, @quantityInStock, @quantitySold, @releaseDate, @console, @price, @clearance)", connection))
                {
                    cmd.Parameters.AddWithValue("@title", title);
                    cmd.Parameters.AddWithValue("@quantityInStock", quantityInStock);
                    cmd.Parameters.AddWithValue("@quantitySold", 0);
                    cmd.Parameters.AddWithValue("@releaseDate", releaseDate);
                    cmd.Parameters.AddWithValue("@console", console);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.Parameters.AddWithValue("@clearance", false);

                    try
                    {
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();
                        success = true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("There was an issue inserting the new game information" + ex);
                    }
                }
            }
            return success;
        }

        //used to remove any game from the database as supplied from admins 
        public bool DeleteGameInfo(int gameId)
        {
            bool success = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd =
                    new SqlCommand($"DELETE FROM GameInformation WHERE GameID = @gameId", connection))
                {
                    try
                    {
                        connection.Open();
                        cmd.Parameters.AddWithValue("@gameId", gameId);
                        cmd.ExecuteNonQuery();
                        connection.Close();
                        success = true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("There was an issue deleting this games information " + ex);
                    }
                }
            }

            return success;
        }

        //update game information in the database as supplied by admins
        public bool UpdateGameInfo(string gameId, string title, int quantityInStock, DateTime releaseDate, string console, double price)
        {
            bool success = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(
                    $"UPDATE GameInformation " +
                    $"SET Title = @title, QuantityInStock = @quantityInStock, ReleaseDate = @releaseDate, Console = @console, Price = @price WHERE GameID = @gameId",
                    connection))
                {
                    cmd.Parameters.AddWithValue("@title", title);
                    cmd.Parameters.AddWithValue("@quantityInStock", quantityInStock);
                    cmd.Parameters.AddWithValue("@releaseDate", releaseDate);
                    cmd.Parameters.AddWithValue("@console", console);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.Parameters.AddWithValue("@gameId", gameId);

                    try
                    {
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();
                        success = true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("There was an issue updating the new game information " + ex);
                    }
                }
            }

            return success;
        }

        //update quantity of a particular game as supplied by admins (used when they receive new shipment)
        public bool UpdateGameQuantity(int gameId, int quantity)
        {
            bool success = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(
                    $"UPDATE GameInformation " +
                    $"SET QuantityInStock = @quantity WHERE GameID = @gameId",
                    connection))
                {
                    cmd.Parameters.AddWithValue("@quantity", quantity);
                    cmd.Parameters.AddWithValue("@gameId", gameId);

                    try
                    {
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();
                        success = true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("There was an issue updating the new game quantity " + ex);
                    }
                }
            }

            return success;
        }

        //update our game info with the new quantity after the game was ordered or cancelled
        //AddToSold is true if a game quantity is to be added and false if a game quantity is to be removed
        public bool UpdateGameStockAfterOrder(int gameId, int quantityInStock, int quantitySold, bool addToSold)
        {
            bool successUpdate = false;

            //remove from stock and sold columns according to supplied bool
            if (addToSold)
            {
                quantityInStock = quantityInStock - 1;
                quantitySold = quantitySold + 1;
            }
            else
            {
                quantityInStock = quantityInStock + 1;
                quantitySold = quantitySold - 1;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd =
                    new SqlCommand($"UPDATE GameInformation " +
                                   $"SET QuantityInStock = @quantityInStock, QuantitySold = @quantitySold WHERE GameID = @gameId", connection))
                {
                    try
                    {
                        connection.Open();
                        cmd.Parameters.AddWithValue("@gameId", gameId);
                        cmd.Parameters.AddWithValue("@quantityInStock", quantityInStock);
                        cmd.Parameters.AddWithValue("@quantitySold", quantitySold);
                        cmd.ExecuteNonQuery();
                        connection.Close();
                        successUpdate = true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("There was an issue updating the quantity in the game information." + ex);
                    }
                }
            }
            return successUpdate;
        }

        //update quantity of a particular game as supplied by admins (used when they receive new shipment)
        public bool UpdateGamePrice(int gameId, double price, bool clearance)
        {
            bool success = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(
                    $"UPDATE GameInformation " +
                    $"SET Price = @price, Clearance = @clearance WHERE GameID = @gameId",
                    connection))
                {
                    cmd.Parameters.AddWithValue("@gameId", gameId);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.Parameters.AddWithValue("@clearance", clearance);

                    try
                    {
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();
                        success = true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("There was an issue updating the new game price " + ex);
                    }
                }
            }

            return success;
        }
    }
}
