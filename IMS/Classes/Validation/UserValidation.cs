using IMS.Database;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace IMS.Validation
{
    class UserValidation
    {
        //ensure input is valid email
        public bool ValidateEmail(string email)
        {
            bool valid = false;
            Regex reg = new Regex(@"^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,6}$", RegexOptions.IgnoreCase);

            if (reg.IsMatch(email))
            {
                valid = true;
            }

            return valid;
        }

        //ensure input is a valid name
        public bool ValidateName(string name)
        {
            bool valid = false;
            Regex reg = new Regex(@"^[a-zA-Z]+\s?[a-zA-Z]+$");

            if (reg.IsMatch(name) && name.Length >= 3)
            {
                valid = true;
            }

            return valid;
        }

        //ensure input is a valid password
        public Tuple<bool, bool> ValidatePassword(string password, string password2)
        {
            bool validMatch = false;
            bool validLength = false;

            if (password.Equals(password2))
            {
                validMatch = true;
            }
            if (password.Length >= 6)
            {
                validLength = true;
            }

            return Tuple.Create(validMatch, validLength);
        }

        //ensure input is a valid name
        public bool ValidateUsername(string username)
        {
            bool valid = false;
            Regex reg = new Regex(@"^[a-zA-Z0-9]+$");

            if (reg.IsMatch(username) && username.Length >= 3)
            {
                valid = true;
            }

            return valid;
        }

        public bool ValidationMessages(string name, string username, string password, string password2, string email)
        {
            //get access to database related functions for checking existing emails/usernames
            var rd = new RegistrationDatabase();
            //get tuple of bools back so we can check for two bools: Item1 is password match, Item2 is password at least 6 chars long
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
