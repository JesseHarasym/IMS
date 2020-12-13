using IMS.Classes;
using System;
using System.Windows.Forms;

namespace IMS.CustomControls
{
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            if (checkboxAdmin.Checked)
            {
                Admin newAdmin = new Admin(txtName.Text, txtUsername.Text, txtPassword.Text, txtEmail.Text);
                newAdmin.AddAdminToDatabase();
            }
            else
            {
                Users newUser = new Users(txtName.Text, txtUsername.Text, txtPassword.Text, txtEmail.Text);
                newUser.AddUserToDatabase();
            }

            txtName.Text = "";
            txtEmail.Text = "";
            txtUsername.Text = "";
            txtPassword.Text = "";
            checkboxAdmin.Checked = false;

            MessageBox.Show("User created successfuly");
            Close();
        }
    }
}
