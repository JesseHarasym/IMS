using IMS.Database;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            txtTitle.Enabled = false;
            txtQuantity.Enabled = false;
            txtDescription.Enabled = false;
            txtReleaseDate.Enabled = false;
            txtPrice.Enabled = false;
            txtConsole.Enabled = false;

            boxWhichProduct.DropDownStyle = ComboBoxStyle.DropDownList;
            boxWhichProduct.Items.Add("Pick a product");
            boxWhichProduct.SelectedIndex = 0;

            foreach (var p in ProductList)
            {
                boxWhichProduct.Items.Add($"{p.GameID}: {p.Title}");
            }
        }

        private void boxWhichProduct_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (boxWhichProduct.SelectedIndex != 0)
            {
                string[] productArr = boxWhichProduct.Text.Split(':');
                string gameId = productArr[0].Trim();
                string title = productArr[1].Trim();

                foreach (var p in ProductList)
                {
                    if (p.GameID.ToString() == gameId && p.Title == title)
                    {
                        txtTitle.Text = p.Title;
                        txtTitle.Enabled = true;
                        txtQuantity.Text = p.Quantity.ToString();
                        txtQuantity.Enabled = true;
                        txtDescription.Text = p.Description;
                        txtDescription.Enabled = true;
                        txtReleaseDate.Text = p.ReleaseDate.ToString();
                        txtReleaseDate.Enabled = true;
                        txtPrice.Text = p.Price.ToString();
                        txtPrice.Enabled = true;
                        txtConsole.Text = p.Console;
                        txtConsole.Enabled = true;
                    }
                }
            }
            else
            {
                txtTitle.Text = "";
                txtTitle.Enabled = false;
                txtQuantity.Text = "";
                txtQuantity.Enabled = false;
                txtDescription.Text = "";
                txtDescription.Enabled = false;
                txtReleaseDate.Text = "";
                txtReleaseDate.Enabled = false;
                txtPrice.Text = "";
                txtPrice.Enabled = false;
                txtConsole.Text = "";
                txtConsole.Enabled = false;
            }
        }

        private void bttEdit_Click(object sender, EventArgs e)
        {
            bool success = false;
            string[] productArr = boxWhichProduct.Text.Split(':');
            string gameId = productArr[0].Trim();
            string title = txtTitle.Text;
            int quantity = Convert.ToInt32(txtQuantity.Text);
            DateTime releaseDate = Convert.ToDateTime(txtReleaseDate.Text);
            string description = txtDescription.Text;
            string console = txtConsole.Text;
            double price = Convert.ToDouble(txtPrice.Text);

            string connectionString = Connection.ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(
                    $"UPDATE GameInformation " +
                    $"SET Title = @title, Quantity = @quantity, ReleaseDate = @releaseDate, Description = @description, Console = @console, Price = @price WHERE GameID = {gameId}", connection))
                {
                    cmd.Parameters.AddWithValue("@title", title);
                    cmd.Parameters.AddWithValue("@quantity", quantity);
                    cmd.Parameters.AddWithValue("@releaseDate", releaseDate);
                    cmd.Parameters.AddWithValue("@description", description);
                    cmd.Parameters.AddWithValue("@console", console);
                    cmd.Parameters.AddWithValue("@price", price);
                    connection.Open();
                    try
                    {
                        cmd.ExecuteNonQuery();
                        success = true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("There was an issue updating the new game information " + ex);
                    }

                    connection.Close();

                }

            }

            if (success)
            {
                foreach (var p in ProductList)
                {
                    if (p.GameID.ToString() == gameId)
                    {
                        p.Title = txtTitle.Text;
                        p.Quantity = Convert.ToInt32(txtQuantity.Text);
                        p.ReleaseDate = Convert.ToDateTime(txtReleaseDate.Text);
                        p.Description = txtDescription.Text;
                        p.Console = txtConsole.Text;
                        p.Price = Convert.ToDouble(txtPrice.Text);
                    }
                }

                AdminControls.AddNewInventory(ProductList);
                MessageBox.Show($"{gameId}: {title} was edited successfully.");
                Close();
            }
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!int.TryParse(e.KeyChar.ToString(), out var i) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!int.TryParse(e.KeyChar.ToString(), out var i) && e.KeyChar != '.' && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
            else if ((e.KeyChar == '.') && ((sender as MaskedTextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            else if ((e.KeyChar == '.') && ((sender as MaskedTextBox).Text.Length == 0))
            {
                e.Handled = true;
            }
        }
    }
}
