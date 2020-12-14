using IMS.Classes;
using System;
using System.Text.RegularExpressions;
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
            bool valid = false;

            //validate all inputs. done this way so only one message box comes up at a time.
            bool nameValid = ValidateName(txtName.Text);
            if (nameValid)
            {
                bool usernameValid = ValidateUsername(txtUsername.Text);
                if (usernameValid)
                {
                    bool passwordValid = ValidatePassword(txtPassword.Text, txtPassword2.Text);
                    if (passwordValid)
                    {
                        bool emailValid = ValidateEmail(txtEmail.Text);
                        if (emailValid)
                        {
                            valid = true;
                        }
                    }
                }
            }

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

        //ensure input is valid email
        public bool ValidateEmail(string email)
        {
            bool valid = false;
            Regex reg = new Regex(@"^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,6}$", RegexOptions.IgnoreCase);

            if (reg.IsMatch(email))
            {
                valid = true;
            }
            else
            {
                MessageBox.Show("This is not a valid email. Please check it and try again.");
            }

            return valid;
        }

        //ensure input is a valid name
        public bool ValidateName(string name)
        {
            bool valid = false;
            Regex reg = new Regex(@"^[a-zA-Z]+$");

            if (reg.IsMatch(name) && name.Length >= 3)
            {
                valid = true;
            }
            else
            {
                MessageBox.Show("This is not a valid name. It must be at least three characters and no digits or symbols.");
            }

            return valid;
        }

        //ensure input is a valid password
        public bool ValidatePassword(string password, string password2)
        {
            bool valid = false;
            var reg = new Regex(@".{6,}");

            if (!password.Equals(password2))
            {
                MessageBox.Show("Your passwords do not match.");
            }
            else if (reg.IsMatch(password) && reg.IsMatch(password2))
            {
                valid = true;
            }
            else if (password.Length < 6)
            {
                MessageBox.Show("Password must be at least 6 characters long.");
            }

            return valid;
        }

        //ensure input is a valid name
        public bool ValidateUsername(string username)
        {
            bool valid = false;
            Regex reg = new Regex(@"^[a-zA-Z0-9]+$");

            if (reg.IsMatch(username) && username.Length >= 3)
            {
                valid = true;
            }
            else
            {
                MessageBox.Show("This is not a valid username. It must be at least three characters and no symbols.");
            }

            return valid;
        }
    }
}
