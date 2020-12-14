using System;
using System.Data.SqlClient;

namespace IMS.Database
{
    class LoginDatabase
    {
        readonly string connectionString = Connection.ConnectionString;

        public Tuple<string, string, string> GetUsersPassword(string username)
        {
            string hashedPassword = "";
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
                                hashedPassword = reader["Password"].ToString();
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

            return Tuple.Create(hashedPassword, currentUserId, accessLevel);
        }
    }
}
