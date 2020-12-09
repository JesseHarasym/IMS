using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace IMS.Classes
{
    // The Admin class inherits from the Users class
    class Admin : Users
    {
        // Constructor for the Admin class
        public Admin(string _Name, string _Password, string _PhoneNumber, string _Info) :
            base(_Name, _Password, _PhoneNumber, _Info)
        {
            Name = _Name;
            Password = _Password;
            PhoneNumber = _PhoneNumber;
            Info = _Info;
        }

        /// Method to add an admin to the Users table in the Database
        public void AddAdminToDatabase()
        {
            string connectionString =
            @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dk_ab\Dropbox\BVC\SODV 2202 - OoP\Project OOP\IMS\Database\IMS_Database.mdf;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter();

                using (SqlCommand cmd = new SqlCommand(
                    $"INSERT INTO Users (Name, Password, PhoneNumber, Info, AccessLevel) " +
                    $"VALUES (@name, @password, @phonenumber, @info, 1)", connection))
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

        public void AddProduct()
        {

        }
        public void DeleteProduct()
        {

        }
        public void EditProduct()
        {

        }
    }
}
