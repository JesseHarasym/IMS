using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IMS.Classes;

namespace IMS.CustomControls
{
    public partial class AddUser : Form
    {
        public AddUser()
        {
            InitializeComponent();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            if (checkboxAdmin.Checked)
            {
                Admin newAdmin = new Admin(txtName.Text, txtPassword.Text, txtPhoneNumber.Text, txtInfo.Text);
                newAdmin.AddAdminToDatabase();
            }
            else
            {
                Users newUser = new Users(txtName.Text, txtPassword.Text, txtPhoneNumber.Text, txtInfo.Text);
                newUser.AddUserToDatabase();
            }

            txtName.Text = "";
            txtPassword.Text = "";
            txtPhoneNumber.Text = "";
            txtInfo.Text = "";
            checkboxAdmin.Checked = false;

        }
    }
}
