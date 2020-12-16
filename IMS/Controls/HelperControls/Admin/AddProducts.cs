using IMS.Classes.Validation;
using IMS.Database;
using System;
using System.Windows.Forms;

namespace IMS.CustomControls.HelperControls
{
    public partial class AddProducts : Form
    {
        public AdminControls AdminControls;

        public AddProducts(AdminControls adminControl)
        {
            InitializeComponent();
            AdminControls = adminControl;
        }

        //if admin clicks add then get text box information, validate it and add it to the database
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text;
            bool validQuantity = Int32.TryParse(txtQuantity.Text, out var quantity);
            bool validDate = DateTime.TryParse(txtReleaseDate.Text, out var releaseDate);
            string console = txtConsole.Text;
            bool validPrice = Double.TryParse(txtPrice.Text, out var price);
            bool success = false;

            //validate product input and get any error messages that may be relevant
            var pv = new ProductValidation();
            bool validateInput = pv.ValidationMessages(title, validQuantity, validDate, console, validPrice);

            //only insert into database if all data has been validated
            if (validateInput)
            {
                var pd = new ProductDatabase();
                success = pd.InsertGameInfo(title, quantity, releaseDate, console, price);
            }

            //if successfully inserted into the database, then let user know and reload data
            if (success)
            {
                AdminControls.AdminSetup(); //function that fills admin panel with newly updated data
                MessageBox.Show($"{quantity} of {title} added to the inventory.");
                Close();
            }
            else if (!success && validateInput)
            {
                MessageBox.Show("There was an issue adding this product."); //show user a message if there's an error.
            }
        }

        //handle basic data validation so that quantity can only be entered as numbers
        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!int.TryParse(e.KeyChar.ToString(), out var i) && e.KeyChar != (char)Keys.Back && e.KeyChar != '-') //also allow backspace
            {
                e.Handled = true;
            }
            else if (e.KeyChar == '-' && ((sender as MaskedTextBox).Text.IndexOf('-') > -1))    //only allow a single negative
            {
                e.Handled = true;
            }
            else if ((e.KeyChar == '-') && ((sender as MaskedTextBox).Text.Length == 1))    //only allow negative as first digit
            {
                e.Handled = true;
            }
        }

        //handle basic data validation so that price can only be entered as a number with decimal
        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            //also alow's negatives to handle use case where PreOrder starts at 0 and goes into negatives for each PreOrder until stock arrives
            if (!int.TryParse(e.KeyChar.ToString(), out var i) && e.KeyChar != '.' && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
            else if ((e.KeyChar == '.') && ((sender as MaskedTextBox).Text.IndexOf('.') > -1))  //only allow a single decimal
            {
                e.Handled = true;
            }
            else if ((e.KeyChar == '.') && ((sender as MaskedTextBox).Text.Length == 0))    //don't allow first char input to be a decimal
            {
                e.Handled = true;
            }
        }
    }
}
