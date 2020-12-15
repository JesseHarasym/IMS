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

            //at each product to dropdown box
            foreach (var p in ProductList)
            {
                boxWhichProduct.Items.Add($"{p.GameID} ~ {p.Title}");
            }
        }

        private void boxWhichProduct_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (boxWhichProduct.SelectedIndex != 0) //if a product is selected
            {
                string[] productArr = boxWhichProduct.Text.Split('~');
                string gameId = productArr[0].Trim();
                string title = productArr[1].Trim();

                foreach (var p in ProductList)
                {
                    if (p.GameID.ToString() == gameId && p.Title == title)
                    {
                        //fill all textboxes with the product information chosen by the user
                        txtTitle.Text = p.Title;
                        txtQuantity.Text = p.Quantity.ToString();
                        txtDescription.Text = p.Description;
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
                    }
                }
            }
            else
            {
                //if the user goes back to index 0 of dropdown (no choice) then take away all the filled data
                txtTitle.Clear();
                txtQuantity.Clear();
                txtDescription.Clear();
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

        private void bttEdit_Click(object sender, EventArgs e)
        {
            string[] productArr = boxWhichProduct.Text.Split('~');
            string gameId = productArr[0].Trim();
            string title = txtTitle.Text;
            int quantity = Convert.ToInt32(txtQuantity.Text);
            DateTime releaseDate = Convert.ToDateTime(txtReleaseDate.Text);
            string description = txtDescription.Text;
            string console = txtConsole.Text;
            double price = Convert.ToDouble(txtPrice.Text);
            bool success = false;

            var pd = new ProductDatabase();
            if (boxWhichProduct.SelectedIndex != 0)
            {
                success = pd.UpdateGameInfo(gameId, title, quantity, releaseDate, description, console, price);
            }
            else
            {
                MessageBox.Show("You must select a product to edit.");
            }

            if (success)
            {
                AdminControls.AdminSetup();
                MessageBox.Show($"{gameId} ~ {title} was edited successfully.");
                Close();
            }
            else
            {
                MessageBox.Show("We are not able to update this product at this time.");
            }
        }

        //handle basic data validation so that quantity can only be numbers
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
