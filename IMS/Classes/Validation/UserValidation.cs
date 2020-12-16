using IMS.Database;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace IMS.Validation
{
    class UserValidation
    {
        //used to validate account emails when a user is registering
        public bool ValidateEmail(string email)
        {
            bool valid = false;
            //ensure the input follows pattern of an email string
            Regex reg = new Regex(@"^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,6}$", RegexOptions.IgnoreCase);

            if (reg.IsMatch(email))
            {
                valid = true;
            }

            return valid;
        }

        //used to validate name when a user is registering
        public bool ValidateName(string name)
        {
            bool valid = false;
            //ensures only upper and low alphabetical characters and a space is used when entering names and minimum three characters
            Regex reg = new Regex(@"^[a-zA-Z]+\s?[a-zA-Z]{2}");

            if (reg.IsMatch(name))
            {
                valid = true;
            }

            return valid;
        }

        //used to validate usernames when a user is registering
        public bool ValidateUsername(string username)
        {
            bool valid = false;
            //ensure only letters and numbers are used as usernames, minimum three characters
            Regex reg = new Regex(@"^[a-zA-Z0-9]{2}");

            if (reg.IsMatch(username))
            {
                valid = true;
            }

            return valid;
        }

        //used to validate passwords when a user is registering
        public Tuple<bool, bool> ValidatePassword(string password, string password2)
        {
            bool validMatch = false;
            bool validLength = false;

            //check if the two entered passwords match
            if (password.Equals(password2))
            {
                validMatch = true;
            }
            //ensure password length is at least 6 characters
            if (password.Length >= 6)
            {
                validLength = true;
            }

            return Tuple.Create(validMatch, validLength);
        }

        //used to check all validation pertaining to registration and supply a user an error message if something went wrong
        //i used this central function because I also wanted to combine it with my registration database validation checks, and return a single bool
        public bool ValidationMessages(string name, string username, string password, string password2, string email)
        {
            //get access to database related functions for checking existing emails/usernames
            var rd = new RegistrationDatabase();
            //get tuple of booleans back so we can check for two booleans: Item1 is password match, Item2 is password at least 6 chars long
            var validatePassword = ValidatePassword(password, password2);

            if (!ValidateName(name))
            {
                MessageBox.Show("This is not a valid name. It must be at least three characters and no digits or symbols.");
                return false;
            }

            if (!ValidateUsername(username))
            {
                MessageBox.Show("This is not a valid username. It must be at least three characters and no symbols.");
                return false;
            }

            if (!rd.CheckForExistingUsername(username))
            {
                MessageBox.Show("This username already exists. Please choose something else.");
                return false;
            }

            if (!validatePassword.Item1)
            {
                MessageBox.Show("Your passwords do not match.");
                return false;
            }

            if (!validatePassword.Item2)
            {
                MessageBox.Show("Password must be at least 6 characters long.");
                return false;
            }

            if (!ValidateEmail(email))
            {
                MessageBox.Show("This is not a valid email. Please check it and try again.");
                return false;
            }

            if (!rd.CheckForExistingEmail(email))
            {
                MessageBox.Show("This email already has an account associated with it.");
                return false;
            }

            return true;
        }
    }
}
