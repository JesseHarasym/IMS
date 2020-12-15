using IMS.Database;
using System.Data.SqlClient;

namespace IMS.Classes
{
    // The Admin class inherits from the Users class
    class Admin : Users
    {
        // Constructor for the Admin class
        public Admin(string _Name, string _Username, string _Password, string _Email) :
            base(_Name, _Username, _Password, _Email)
        {
            Name = _Name;
            Username = _Username;
            Password = _Password;
            Email = _Email;
        }

        /// Method to add an admin to the Users table in the Database
        public void AddAdminToDatabase()
        {
            string connectionString = Connection.ConnectionString;

            //hash password before entering it into the database
            var hp = new HashPasswords();
            string hashedPassword = hp.HashAccountPassword(Password);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(
                    $"INSERT INTO Accounts (Name, Username, Password, Email, AccessLevel) " +
                    $"VALUES (@name, @username, @password, @email, 1)", connection))
                {
                    cmd.Parameters.AddWithValue("@name", Name);
                    cmd.Parameters.AddWithValue("@username", Username);
                    cmd.Parameters.AddWithValue("@password", hashedPassword);
                    cmd.Parameters.AddWithValue("@email", Email);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }

            }
        }
    }
}
