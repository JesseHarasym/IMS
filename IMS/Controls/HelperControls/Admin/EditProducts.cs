using IMS.Classes.Validation;
using IMS.Database;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using VideoGameInventoryApp.Classes;

namespace IMS.CustomControls.HelperControls
{
    public partial class EditProducts : Form
    {
        AdminControls AdminControls;
        List<Products> ProductList;
        public EditProducts(AdminControls adminControls, List<Products> productList)
        {
            InitializeComponent();
            AdminControls = adminControls;
            ProductList = productList;
        }

        private void EditProducts_Load(object sender, EventArgs e)
        {
            //set all input controls to disabled until user picks a product to edit
            foreach (Control c in Controls)
            {
                if (c is MaskedTextBox)
                {
                    c.Enabled = false;
                }
            }

            //initial settings for dropdown box
            boxWhichProduct.DropDownStyle = ComboBoxStyle.DropDownList;
            boxWhichProduct.Items.Add("Pick a product");
            boxWhichProduct.SelectedIndex = 0;
            boxWhichProduct.DropDownHeight = boxWhichProduct.Font.Height * 10;  //only allow 10 items at a time while viewing

            //fill each product to dropdown box
            foreach (var p in ProductList)
            {
                boxWhichProduct.Items.Add($"{p.GameID} ~ {p.Title}");
            }
        }

        //if a product selection was made, then fill the text boxes information with info of the product chosen, to be edited
        private void boxWhichProduct_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (boxWhichProduct.SelectedIndex != 0) //if a product is selected
            {
                string[] productArr = boxWhichProduct.Text.Split('~');
                string gameId = productArr[0].Trim();

                foreach (var p in ProductList)
                {
                    if (p.GameID.ToString() == gameId)
                    {
                        //fill all textboxes with the product information chosen by the user
                        txtTitle.Text = p.Title;
                        txtQuantity.Text = p.QuantityInStock.ToString();
                        txtReleaseDate.Text = p.ReleaseDate.ToString();
                        txtPrice.Text = p.Price.ToString();
                        txtConsole.Text = p.Console;

                        //make all textboxes so they can now be edited
                        foreach (Control c in Controls)
                        {
                            if (c is MaskedTextBox)
                            {
                                c.Enabled = true;
                            }
                        }

                        //take away the ability to edit the price of any clearance games.
                        if (p.Clearance)
                        {
                            txtPrice.Enabled = false;
                            MessageBox.Show("Please note you cannot edit the price of a game on clearance");
                        }
                    }
                }
            }
            else
            {
                //if the user goes back to index 0 of dropdown (no choice) then take away all the filled data
                txtTitle.Clear();
                txtQuantity.Clear();
                txtReleaseDate.Clear();
                txtPrice.Clear();
                txtConsole.Clear();

                //disable editing to textboxes if no choice selected
                foreach (Control c in Controls)
                {
                    if (c is MaskedTextBox)
                    {
                        c.Enabled = false;
                    }
                }
            }
        }

        //if admin decides to edit, then validate the inputs, update in database and update data seen by admin
        private void bttEdit_Click(object sender, EventArgs e)
        {
            string[] productArr = boxWhichProduct.Text.Split('~');
            string gameId = productArr[0].Trim();
            string title = txtTitle.Text;
            bool validQuantity = Int32.TryParse(txtQuantity.Text, out var quantity);
            bool validDate = DateTime.TryParse(txtReleaseDate.Text, out var releaseDate);
            string console = txtConsole.Text;
            bool validPrice = Double.TryParse(txtPrice.Text, out var price);
            bool success = false;

            //validate product input and get any error messages that may be relevant
            var pv = new ProductValidation();
            bool validateInput = pv.ValidationMessages(title, validQuantity, validDate, console, validPrice);

            //if inputs are valid then update the database
            if (validateInput)
            {
                var pd = new ProductDatabase();
                success = pd.UpdateGameInfo(gameId, title, quantity, releaseDate, console, price);
            }

            //if the database has successfully updated then update admins data
            if (success)
            {
                AdminControls.AdminSetup();
                MessageBox.Show($"{gameId} ~ {title} was edited successfully.");
                Close();
            }
            else if (!success && validateInput)
            {
                MessageBox.Show("We are not able to update this product at this time.");
            }
        }

        //only allow numbers and backspace 
        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!int.TryParse(e.KeyChar.ToString(), out var i) && e.KeyChar != (char)Keys.Back)
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
            else if ((e.KeyChar == '.') && ((sender as MaskedTextBox).Text.Length == 0)) //don't allow first char input to be a decimal
            {
                e.Handled = true;
            }
        }
    }
}
