using IMS.Classes;
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
            if (AccessLevel != 1)
            {
                checkboxAdmin.Visible = false;
                lblAccess.Visible = false;
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            //validate all inputs. done this way so only one message box comes up at a time.
            //function is quite verbose, so it made sense to separate it
            bool valid = ValidateUserInputs();

            if (valid)
            {
                if (checkboxAdmin.Checked)
                {
                    Admin newAdmin = new Admin(txtName.Text, txtUsername.Text, txtPassword.Text, txtPassword2.Text);
                    newAdmin.AddAdminToDatabase();
                }
                else
                {
                    Users newUser = new Users(txtName.Text, txtUsername.Text, txtPassword.Text, txtPassword2.Text);
                    newUser.AddUserToDatabase();
                }

                txtName.Text = "";
                txtPassword2.Text = "";
                txtUsername.Text = "";
                txtPassword.Text = "";
                checkboxAdmin.Checked = false;

                MessageBox.Show("User created successfuly");
                Close();
            }
        }

        public bool ValidateUserInputs()
        {
            //get access to database related functions for checking existing emails/usernames
            var rd = new RegistrationDatabase();
            //get access to validation functions
            var uv = new UserValidation();
            //get tuple of bools back so we can check for two bools: Item1 is password match, Item2 is password at least 6 chars long
            var validatePassword = uv.ValidatePassword(txtPassword.Text, txtPassword2.Text);


            if (!uv.ValidateName(txtName.Text))
            {
                MessageBox.Show("This is not a valid name. It must be at least three characters and no digits or symbols.");
                return false;
            }

            if (!uv.ValidateUsername(txtUsername.Text))
            {
                MessageBox.Show("This is not a valid username. It must be at least three characters and no symbols.");
                return false;
            }

            if (!rd.CheckForExistingUsername(txtUsername.Text))
            {
                MessageBox.Show("This username already exists. Please choose something else.");
                return false;
            }

            if (!validatePassword.Item1)
            {
                MessageBox.Show("Your passwords do not match.");
                return false;
            }

            if (!validatePassword.Item2)
            {
                MessageBox.Show("Password must be at least 6 characters long.");
                return false;
            }

            if (!uv.ValidateEmail(txtEmail.Text))
            {
                MessageBox.Show("This is not a valid email. Please check it and try again.");
                return false;
            }

            if (!rd.CheckForExistingEmail(txtEmail.Text))
            {
                MessageBox.Show("This email already has an account associated with it.");
                return false;
            }

            return true;
        }
    }
}
