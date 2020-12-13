using IMS.Database;
using System.Data.SqlClient;

namespace IMS.Classes
{
    public class Users
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        // Constructor for the Users class
        public Users(string _Name, string _Username, string _Password, string _Email)
        {
            Name = _Name;
            Username = _Username;
            Password = _Password;
            Email = _Email;
        }

        // Method to add a user to the Users table in the Database
        public void AddUserToDatabase()
        {
            string connectionString = Connection.ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(
                    $"INSERT INTO Accounts (Name, Username, Password, Email, AccessLevel)" +
                    $"VALUES (@name, @username, @password, @email, 0)", connection))
                {
                    cmd.Parameters.AddWithValue("@name", Name);
                    cmd.Parameters.AddWithValue("@username", Username);
                    cmd.Parameters.AddWithValue("@password", Password);
                    cmd.Parameters.AddWithValue("@email", Email);
                    cmd.Parameters.AddWithValue("@AccessLevel", 0);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }

            }
        }

        public void Order()
        {

        }
    }
}
