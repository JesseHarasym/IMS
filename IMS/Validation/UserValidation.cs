using System;
using System.Text.RegularExpressions;

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
            Regex reg = new Regex(@"^[a-zA-Z]+$");

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
    }
}
