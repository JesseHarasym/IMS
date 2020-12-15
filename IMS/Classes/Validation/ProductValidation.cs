using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace IMS.Classes.Validation
{
    class ProductValidation
    {
        public bool ValidateTitle(string title)
        {
            bool valid = false;
            Regex reg = new Regex(@"^[a-zA-Z0-9]{3}");  //at least three alphabetic characters for title

            //don't allow # or ~ since they are our separating characters in some functions
            if (reg.IsMatch(title) && !title.Contains("~") && !title.Contains("#"))
            {
                valid = true;
            }

            return valid;
        }

        public bool ValidateConsole(string console)
        {
            bool valid = false;
            Regex reg = new Regex(@"^[a-zA-Z0-9]{3}");  //at least three alphabetic characters for console

            if (reg.IsMatch(console))
            {
                valid = true;
            }

            return valid;
        }

        public bool ValidationMessages(string title, bool validQuantity, bool validDate, string console, bool validPrice)
        {
            if (!ValidateTitle(title))
            {
                MessageBox.Show("This is not a valid title. It must be at least three characters and no # or ~.");
                return false;
            }

            if (!validQuantity)
            {
                MessageBox.Show("This is not a valid quantity. It must be a valid number and not empty");
                return false;
            }

            if (!validDate)
            {
                MessageBox.Show("This is not a valid date. It must be in the format YYYY-MM-DD");
                return false;
            }

            if (!ValidateConsole(console))
            {
                MessageBox.Show("This is not a valid console. It must be at least three characters or digits");
                return false;
            }

            if (!validPrice)
            {
                MessageBox.Show("This is not a valid price. It must be a valid number and not empty");
                return false;
            }

            return true;
        }
    }
}
