using IMS.Classes;
using IMS.Classes.MainClasses.Accounts;
using System;
using System.Data.SqlClient;

namespace IMS.Database
{
    class RegistrationDatabase
    {
        readonly string connectionString = Connection.ConnectionString;

        //used to register an account and add it to the database, used generics so that any type of user can be passed to the function
        public bool AddAccount<T>(T account) where T : AccountBase
        {
            bool success = false;
            //hash password before entering it into the database
            var hp = new HashPasswords();
            string hashedPassword = hp.HashAccountPassword(account.Password);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(
                    $"INSERT INTO Accounts (Name, Username, Password, Email, AccessLevel) " +
                    $"VALUES (@name, @username, @password, @email, @accessLevel)", connection))
                {
                    try
                    {
                        cmd.Parameters.AddWithValue("@name", account.Name);
                        cmd.Parameters.AddWithValue("@username", account.Username);
                        cmd.Parameters.AddWithValue("@password", hashedPassword);
                        cmd.Parameters.AddWithValue("@email", account.Email);
                        cmd.Parameters.AddWithValue("@accessLevel", account.AccessLevel);
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();
                        success = true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("There was an issue while creating this user " + ex);
                    }
                }
            }

            return success;
        }

        //used to check if an email has already been used to make an account to avoid duplicates, used for validation
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

                        if (userCount == 0) //if count is greater then 0, then it already exists    
                        {
                            success = true;  //if 0 then we can use this email
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

        //used to check if an username has already been used to make an account to avoid duplicates, used for validation
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
                            success = true; //if 0 then we can use this username
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
