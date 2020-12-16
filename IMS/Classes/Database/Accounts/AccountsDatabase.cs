using IMS.Classes.MainClasses.Accounts;
using IMS.Database;
using System;
using System.Data.SqlClient;

namespace IMS.Classes.Database.Accounts
{
    class AccountsDatabase
    {
        readonly string connectionString = Connection.ConnectionString;

        //this is function is used for retrieving information from database needed to login to an account
        public Tuple<bool, string, string> GetAccountPassword(string username, string enteredPassword)
        {
            string savedPassword = "";
            string currentUserId = "";
            string accessLevel = "";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand($"SELECT * FROM Accounts WHERE Username = @username", connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@username", username);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            try
                            {
                                savedPassword = reader["Password"].ToString();
                                currentUserId = reader["Id"].ToString();
                                accessLevel = reader["AccessLevel"].ToString();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("There was an issue retrieving the users password to unhash." + ex);
                            }
                        }
                    }
                    connection.Close();
                }
            }
            //check currently stored hash password with the password the user entered, see if it's a match and return the results
            var hp = new HashPasswords();
            bool match = hp.UnHashAccountPassword(enteredPassword, savedPassword);

            //return if it's a match, and relevant account data
            return Tuple.Create(match, currentUserId, accessLevel);
        }

        //get all of the customer information according to their id if needed to be used somewhere (not all info saved locally)
        //but id is always passed on login, so this is used to easily retrieve the rest if needed
        public Tuple<bool, AccountBase> GetAccountInformation(int customerId)
        {
            bool success = false;

            string name = "";
            string username = "";
            string password = "";
            string email = "";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand($"SELECT * FROM Accounts WHERE Id = @customerId", connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@customerId", customerId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            try
                            {
                                name = reader["Name"].ToString();
                                username = reader["Username"].ToString();
                                password = reader["Password"].ToString();
                                email = reader["Email"].ToString();

                                success = true;
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("There was an issue retrieving the user information." + ex);
                            }
                        }
                    }
                    connection.Close();
                }
            }
            //turn information received into accounts object so it can more compacted before returning it
            var retrievedUser = new AccountBase(name, username, password, email);
            return Tuple.Create(success, retrievedUser);
        }

        //used to insert new notifications messages into notification table for admins, so that they can be tracked and dismissed
        public bool InsertAccountsNotifications(Notifications notification)
        {
            bool success = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(
                    $"INSERT INTO Notifications (Message, Dismissed, MessageType, ProductId)" +
                    $"VALUES (@message, @dismissed, @messageType, @productId)", connection))
                {
                    cmd.Parameters.AddWithValue("@message", notification.Message);
                    cmd.Parameters.AddWithValue("@dismissed", false);
                    cmd.Parameters.AddWithValue("@messageType", notification.MessageType);
                    cmd.Parameters.AddWithValue("@productId", notification.ProductId);

                    try
                    {
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();
                        success = true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("There was an issue inserting the new notification information" + ex);
                    }
                }
            }

            return success;
        }

        //update notifications table when a notification is dismissed so that it won't be showed again
        public bool UpdateNotificationsDismissed(string message, bool dismissed)
        {
            bool success = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(
                    $"UPDATE Notifications " +
                    $"SET Dismissed = @dismissed WHERE Message = @message",
                    connection))
                {
                    cmd.Parameters.AddWithValue("@message", message);
                    cmd.Parameters.AddWithValue("@dismissed", dismissed);

                    try
                    {
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();
                        success = true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("There was an issue updating the new notification information " + ex);
                    }
                }
            }

            return success;
        }

    }
}
