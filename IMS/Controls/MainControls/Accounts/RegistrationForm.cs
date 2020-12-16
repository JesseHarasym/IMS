using IMS.Classes;
using IMS.Classes.MainClasses.Accounts;
using IMS.Database;
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
            //only allow other admins to create admin accounts
            if (AccessLevel != 1)
            {
                checkboxAdmin.Visible = false;
                lblAccess.Visible = false;
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            bool success;

            var uv = new UserValidation();
            //function to validate all user inputs when registering and give error messages if invalid
            bool valid = uv.ValidationMessages(txtName.Text, txtUsername.Text, txtPassword.Text, txtPassword2.Text, txtEmail.Text);
            //access functions pertaining to registration
            var rd = new RegistrationDatabase();

            //if validation of all user inputs are valid
            if (valid)
            {
                if (checkboxAdmin.Checked)
                {
                    //insert admin into accounts database table
                    var admin = new Admins(txtName.Text, txtUsername.Text, txtPassword.Text, txtEmail.Text);
                    success = rd.AddAccount(admin);
                }
                else
                {
                    //insert user into accounts database table
                    var user = new Users(txtName.Text, txtUsername.Text, txtPassword.Text, txtEmail.Text);
                    success = rd.AddAccount(user);
                }

                //if added successfully then let user know
                if (success)
                {
                    MessageBox.Show("User created successfuly");
                    Close();
                }
                else
                {
                    MessageBox.Show("There was a problem while creating this user");
                }
            }
        }
    }
}
