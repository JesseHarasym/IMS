using System;
using System.Data.SqlClient;

namespace IMS.Database
{
    class RegistrationDatabase
    {
        readonly string connectionString = Connection.ConnectionString;
        public bool CheckForExistingEmail(string email)
        {
            bool success = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(
                    $"SELECT COUNT(*) from Accounts WHERE Email = @email", connection))
                {
                    connection.Open();

                    try
                    {
                        cmd.Parameters.AddWithValue("@email", email);
                        int userCount = (int)cmd.ExecuteScalar();

                        if (userCount == 0)
                        {
                            success = true;
                        }

                        connection.Close();

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("There was an issue looking for this email" + ex);
                    }
                }


            }

            return success;
        }

        public bool CheckForExistingUsername(string username)
        {
            bool success = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(
                    $"SELECT COUNT(*) FROM Accounts WHERE Username = @username", connection))
                {
                    try
                    {
                        connection.Open();
                        cmd.Parameters.AddWithValue("@username", username);
                        int userCount = (int)cmd.ExecuteScalar();

                        if (userCount == 0)
                        {
                            success = true;
                        }

                        connection.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("There was an issue looking for this username" + ex);
                    }
                }
            }

            return success;
        }
    }
}
