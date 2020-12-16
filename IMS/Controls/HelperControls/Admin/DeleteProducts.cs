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
            boxWhichProduct.DropDownHeight = boxWhichProduct.Font.Height * 10;  //only allow 10 items at a time while looking

            //add each product to dropdown box
            foreach (var p in ProductList)
            {
                boxWhichProduct.Items.Add($"{p.GameID} ~ {p.Title}");
            }
        }

        private void bttDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string[] productArr = boxWhichProduct.Text.Split('~');
                string gameId = productArr[0].Trim();
                string title = productArr[1].Trim();
                bool success = false;

                //if a product has been selected from combo box, try to delete from database
                var pd = new ProductDatabase();
                if (boxWhichProduct.SelectedIndex != 0)
                {
                    success = pd.DeleteGameInfo(Convert.ToInt32(gameId));
                }

                //if removed successfully from database, then update data and inform admin
                if (success)
                {
                    AdminControls.AdminSetup();
                    MessageBox.Show($"{gameId}: {title} was deleted successfully.");
                    Close();
                }
                else
                {
                    MessageBox.Show("There was an issue while trying to delete this product.");
                }
            }
            catch
            {
                MessageBox.Show("You must choose a product to delete.");
            }

        }
    }
}
