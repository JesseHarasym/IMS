using System.Configuration;
using System.Data.SqlClient;

namespace IMS.Classes
{
    public class Users
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Info { get; set; }

        // Constructor for the Users class
        public Users(string _Name, string _Password, string _PhoneNumber, string _Info)
        {
            Name = _Name;
            Password = _Password;
            PhoneNumber = _PhoneNumber;
            Info = _Info;
        }

        // Method to add a user to the Users table in the Database
        public void AddUserToDatabase()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["IMS_DatabaseConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(
                    $"INSERT INTO Users (Name, Password, PhoneNumber, Info, AccessLevel, CurrentUser)" +
                    $"VALUES (@name, @password, @phonenumber, @info, 0, @currentUser)", connection))
                {
                    cmd.Parameters.AddWithValue("@name", Name);
                    cmd.Parameters.AddWithValue("@password", Password);
                    cmd.Parameters.AddWithValue("@phonenumber", PhoneNumber);
                    cmd.Parameters.AddWithValue("@info", Info);
                    cmd.Parameters.AddWithValue("@currentUser", false);
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
