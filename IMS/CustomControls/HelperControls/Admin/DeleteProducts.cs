using IMS.Database;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using VideoGameInventoryApp.Classes;

namespace IMS.CustomControls.HelperControls.Admin
{
    public partial class DeleteProducts : Form
    {
        AdminControls AdminControls;
        List<Products> ProductList;
        public DeleteProducts(AdminControls adminControls, List<Products> productList)
        {
            InitializeComponent();
            AdminControls = adminControls;
            ProductList = productList;
        }

        private void DeleteProducts_Load(object sender, EventArgs e)
        {
            boxWhichProduct.DropDownStyle = ComboBoxStyle.DropDownList;
            boxWhichProduct.Items.Add("Pick a product");
            boxWhichProduct.SelectedIndex = 0;

            foreach (var p in ProductList)
            {
                boxWhichProduct.Items.Add($"{p.GameID}: {p.Title}");
            }
        }

        private void bttDelete_Click(object sender, EventArgs e)
        {
            string connectionString = Connection.ConnectionString;

            bool success = false;
            string[] productArr = boxWhichProduct.Text.Split(':');
            string gameId = productArr[0].Trim();
            string title = productArr[1].Trim();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd =
                    new SqlCommand($"DELETE FROM GameInformation " +
                                   $"WHERE GameID = {gameId}", connection))
                {
                    connection.Open();
                    try
                    {
                        cmd.ExecuteNonQuery();
                        success = true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("There was an issue deleting this games information " + ex);
                    }
                    connection.Close();
                }
            }


            if (success)
            {
                List<Products> productList = ProductList.Where(p => p.GameID.ToString() != gameId).ToList();

                AdminControls.AddNewInventory(productList);
                MessageBox.Show($"{gameId}: {title} was deleted successfully.");
                Close();
            }
        }
    }
}
