using System;
using System.Data.SqlClient;

namespace IMS.Database
{
    class ProductDatabase
    {
        string connectionString = Connection.ConnectionString;

        public bool InsertGameInfo(string title, int quantity, DateTime releaseDate, string description, string console, double price)
        {
            bool success = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //insert new product into the GameInformation database table
                using (SqlCommand cmd = new SqlCommand(
                    $"INSERT INTO GameInformation (Title, Quantity, ReleaseDate, Description, Console, Price)" +
                    $"VALUES (@title, @quantity, @releaseDate, @description, @console, @price)", connection))
                {
                    cmd.Parameters.AddWithValue("@title", title);
                    cmd.Parameters.AddWithValue("@quantity", quantity);
                    cmd.Parameters.AddWithValue("@releaseDate", releaseDate);
                    cmd.Parameters.AddWithValue("@description", description);
                    cmd.Parameters.AddWithValue("@console", console);
                    cmd.Parameters.AddWithValue("@price", price);

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

        public bool DeleteGameInfo(int gameId)
        {
            bool success = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //delete data from GameInformation database table
                using (SqlCommand cmd =
                    new SqlCommand($"DELETE FROM GameInformation WHERE GameID = {gameId}", connection))
                {
                    try
                    {
                        connection.Open();
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

        public bool UpdateGameInfo(string gameId, string title, int quantity, DateTime releaseDate, string description, string console, double price)
        {
            bool success = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(
                    $"UPDATE GameInformation " +
                    $"SET Title = @title, Quantity = @quantity, ReleaseDate = @releaseDate, Description = @description, Console = @console, Price = @price WHERE GameID = {gameId}",
                    connection))
                {
                    cmd.Parameters.AddWithValue("@title", title);
                    cmd.Parameters.AddWithValue("@quantity", quantity);
                    cmd.Parameters.AddWithValue("@releaseDate", releaseDate);
                    cmd.Parameters.AddWithValue("@description", description);
                    cmd.Parameters.AddWithValue("@console", console);
                    cmd.Parameters.AddWithValue("@price", price);

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
    }
}
