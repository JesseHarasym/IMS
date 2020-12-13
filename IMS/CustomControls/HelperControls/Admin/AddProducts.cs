using IMS.Database;
using System;
using System.Data.SqlClient;
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool success;

            string title = txtTitle.Text;
            int quantity = Convert.ToInt32(txtQuantity.Text);

            string connectionString = Connection.ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                success = InsertGameInfo(connection, title, quantity);  //function to insert data
                connection.Close();

                if (success)
                {
                    AdminControls.AdminSetup(); //function that fills admin panel with newly updated data
                    MessageBox.Show($"{quantity} of {title} added to the inventory.");
                    Close();
                }
            }
        }

        public bool InsertGameInfo(SqlConnection connection, string title, int quantity)
        {
            bool success = false;

            DateTime releaseDate = Convert.ToDateTime(txtReleaseDate.Text);
            string description = txtDescription.Text;
            string console = txtConsole.Text;
            double price = Convert.ToDouble(txtPrice.Text);

            //insert new product into the GameInformation database table
            using (SqlCommand cmd = new SqlCommand(
                $"INSERT INTO GameInformation (Title, Quantity, ReleaseDate, Description, Console, Price)" +
                $"VALUES (@title, @quantity, @releaseDate, @description, @console, @price)", connection))
            {
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@quantity", quantity);
                cmd.Parameters.AddWithValue("@releaseDate", releaseDate);
                cmd.Parameters.AddWithValue("@description", description);
                cmd.Parameters.AddWithValue("@console", console);
                cmd.Parameters.AddWithValue("@price", price);

                try
                {
                    cmd.ExecuteNonQuery();
                    success = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("There was an issue inserting the new game information" + ex);
                    MessageBox.Show("There was an issue adding this product."); //show user a message if there's an error.
                }
            }
            return success;
        }

        //handle basic data validation so that quantity can only be numbers
        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!int.TryParse(e.KeyChar.ToString(), out var i) && e.KeyChar != (char)Keys.Back) //also allow backspace
            {
                e.Handled = true;
            }
        }

        //handle basic data validation so that price can only be a number with decimal
        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
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
