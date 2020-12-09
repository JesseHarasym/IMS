using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

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
            this.Name = _Name;
            this.Password = _Password;
            this.PhoneNumber = _PhoneNumber;
            this.Info = _Info;
        }

        // Method to add a user to the Users table in the Database
        public void AddUserToDatabase()
        {
            string connectionString =
            @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dk_ab\Dropbox\BVC\SODV 2202 - OoP\Project OOP\IMS\Database\IMS_Database.mdf;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter();

                using (SqlCommand cmd = new SqlCommand(
                    $"INSERT INTO Users (Name, Password, PhoneNumber, Info, AccessLevel) " +
                    $"VALUES (@name, @password, @phonenumber, @info, 0)", connection))
                {
                    cmd.Parameters.AddWithValue("@name", this.Name);
                    cmd.Parameters.AddWithValue("@password", this.Password);
                    cmd.Parameters.AddWithValue("@phonenumber", this.PhoneNumber);
                    cmd.Parameters.AddWithValue("@info", this.Info);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }

            }
        }

        public void Order()
        {

        }

        // Maybe remove this LogIn function, not sure if it will be useful
        // considering we have the log in function on the main form
        public void LogIn()
        {

        }
    }
}
