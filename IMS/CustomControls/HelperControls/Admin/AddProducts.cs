using IMS.Database;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using VideoGameInventoryApp.Classes;

namespace IMS.CustomControls.HelperControls
{
    public partial class AddProducts : Form
    {
        public AdminControls AdminControls;
        private List<Products> ProductList;
        public AddProducts(AdminControls adminControl, List<Products> productList)
        {
            ProductList = productList;
            AdminControls = adminControl;
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool successInsert = false;
            bool successSelect = false;
            string gameId = "";
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
                    $"INSERT INTO GameInformation (Title, Quantity, ReleaseDate, Description, Console, Price)" +
                    $"VALUES (@title, @quantity, @releaseDate, @description, @console, @price)", connection))
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
                        successInsert = true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("There was an issue inserting the new game information" + ex);
                    }

                    connection.Close();

                }

                using (SqlCommand cmd = new SqlCommand(
                    $"SELECT TOP 1 * FROM GameInformation ORDER BY GameID DESC ", connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            try
                            {
                                gameId = reader["GameID"].ToString();
                                successSelect = true;
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("There was an issue selecting the new game id" + ex);
                            }

                        }
                    }

                    connection.Close();
                }

                if (successInsert && successSelect)
                {
                    ProductList.Add(new Products(Convert.ToInt32(gameId), title, quantity, releaseDate,
                        description, console, price));
                    AdminControls.AddNewInventory(ProductList);

                    MessageBox.Show($"{quantity} of {title} added to the inventory.");
                    Close();
                }
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
