using IMS.Classes;
using IMS.Validation;
using System;
using System.Windows.Forms;

namespace IMS.CustomControls
{
    public partial class RegistrationForm : Form
    {
        private int AccessLevel;
        public RegistrationForm(int accessLevel)
        {
            InitializeComponent();
            AccessLevel = accessLevel;
        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {
            if (AccessLevel != 1)
            {
                checkboxAdmin.Visible = false;
                lblAccess.Visible = false;
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            //function to validate all user inputs when registering and give error messages if invalid
            var uv = new UserValidation();
            bool valid = uv.ValidationMessages(txtName.Text, txtUsername.Text, txtPassword.Text, txtPassword2.Text, txtEmail.Text);

            if (valid)
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

                txtName.Clear();
                txtPassword2.Clear();
                txtUsername.Clear();
                txtPassword.Clear();
                checkboxAdmin.Checked = false;

                MessageBox.Show("User created successfuly");
                Close();
            }
        }
    }
}
