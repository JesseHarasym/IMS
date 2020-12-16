using IMS.CustomControls;
using IMS.Database;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using VideoGameInventoryApp.Classes;

namespace IMS.Controls.HelperControls.Admin
{
    public partial class AddQuantity : Form
    {
        private AdminControls AdminControls;
        List<Products> ProductList = new List<Products>();

        public AddQuantity(AdminControls adminControls, List<Products> productList)
        {
            InitializeComponent();
            AdminControls = adminControls;
            ProductList = productList;
        }

        private void AddProductQuantity_Load(object sender, System.EventArgs e)
        {
            //initial settings for dropdown box
            boxWhichProduct.DropDownStyle = ComboBoxStyle.DropDownList;
            boxWhichProduct.Items.Add("Pick a product");
            boxWhichProduct.SelectedIndex = 0;
            boxWhichProduct.DropDownHeight = boxWhichProduct.Font.Height * 10;  //only allow 10 items at a time while looking at combobox

            //put each product into the dropdown box
            foreach (var p in ProductList)
            {
                boxWhichProduct.Items.Add($"{p.GameID} ~ {p.Title}");
            }
        }

        //fill current quantity in stock when admin chooses a product
        private void boxWhichProduct_SelectionChangeCommitted(object sender, System.EventArgs e)
        {
            if (boxWhichProduct.SelectedIndex != 0)
            {
                string[] productArr = boxWhichProduct.Text.Split('~');  //split from the way i displayed in combobox
                string gameId = productArr[0].Trim();

                foreach (var p in ProductList)
                {
                    if (p.GameID.ToString() == gameId)
                    {
                        //fill all textboxes with the product information chosen by the admin
                        txtCurrentQuantity.Text = p.QuantityInStock.ToString();
                    }
                }
            }
            else
            {
                //if the admin goes back to index 0 of dropdown (no choice) then take away the filled quantity
                txtCurrentQuantity.Clear();
            }
        }

        //when admin adds product, ensure it is added to the database successfully and update with new data
        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            try
            {
                string[] productArr = boxWhichProduct.Text.Split('~');
                Int32.TryParse(productArr[0].Trim(), out var gameId);
                string title = productArr[1].Trim();
                Int32.TryParse(txtCurrentQuantity.Text, out var quanitityBefore);
                bool validQuantity = Int32.TryParse(txtQuantityToAdd.Text, out var quanityAdded);
                //take the old quantity in database and entered quantity and add as the new product quantity
                int newQuanity = quanitityBefore + quanityAdded;

                bool success = false;

                //try parse validation, if parses successful then it must be a number
                if (validQuantity)
                {
                    var pd = new ProductDatabase();
                    success = pd.UpdateGameQuantity(gameId, newQuanity);

                }
                else
                {
                    //shouldn't have input issues, but just in case give an appropriate user message
                    MessageBox.Show($"This is not a valid quantity input.");
                }

                //if it updated database successfully, then let admin know and update data
                if (success)
                {
                    AdminControls.AdminSetup();
                    MessageBox.Show(
                        $"{gameId} ~ {title}: Stock quantity updated from {quanitityBefore} to {newQuanity}");
                    Close();
                }
                else if (!success && validQuantity)
                {
                    MessageBox.Show("We are not able to update this product at this time.");
                }
            }
            catch
            {
                MessageBox.Show("You must choose a product to add stock quantity to.");
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
    }
}
