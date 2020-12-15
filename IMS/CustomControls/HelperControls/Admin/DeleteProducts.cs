using IMS.Database;
using System;
using System.Collections.Generic;
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
            //setup for initial dropdown box
            boxWhichProduct.DropDownStyle = ComboBoxStyle.DropDownList;
            boxWhichProduct.Items.Add("Pick a product");
            boxWhichProduct.SelectedIndex = 0;

            //add each product to dropdown box
            foreach (var p in ProductList)
            {
                boxWhichProduct.Items.Add($"{p.GameID} ~ {p.Title}");
            }
        }

        private void bttDelete_Click(object sender, EventArgs e)
        {
            string[] productArr = boxWhichProduct.Text.Split('~');
            string gameId = productArr[0].Trim();
            string title = productArr[1].Trim();
            bool success = false;

            var pd = new ProductDatabase();
            if (boxWhichProduct.SelectedIndex != 0)
            {
                success = pd.DeleteGameInfo(Convert.ToInt32(gameId));
            }
            else
            {
                MessageBox.Show("You must select a product to remove.");
            }

            if (success)
            {
                AdminControls.AdminSetup(); //function that fills admin panel with newly updated data
                MessageBox.Show($"{gameId}: {title} was deleted successfully.");
                Close();
            }
            else
            {
                MessageBox.Show("There was an issue while trying to delete this product.");
            }
        }
    }
}
