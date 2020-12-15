using IMS.Classes;
using IMS.Database;
using System;
using System.Windows.Forms;

namespace IMS.CustomControls
{
    public partial class LogInForm : Form
    {
        public MainForm myForm;
        public LogInForm(MainForm _form)
        {
            myForm = _form;
            InitializeComponent();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text;
            string passwordEntered = txtPassword.Text;

            var hp = new HashPasswords();
            var ld = new LoginDatabase();

            //get relevant user information needed to log in
            var userInformation = ld.GetUsersPassword(username);
            string hashedPassword = userInformation.Item1;
            string currentUserId = userInformation.Item2;
            string accessLevel = userInformation.Item3;

            if (hp.UnHashAccountPassword(passwordEntered, hashedPassword))
            {
                MessageBox.Show("Log in Successful");
                Close();

                myForm.SetUserName(username, accessLevel, currentUserId);
            }
            else if (string.IsNullOrEmpty(hashedPassword) || string.IsNullOrEmpty(currentUserId) || string.IsNullOrEmpty(accessLevel))
            {
                MessageBox.Show("Username was not found");
            }
            else if (!hp.UnHashAccountPassword(passwordEntered, hashedPassword))
            {
                MessageBox.Show("Wrong password was entered for this username.");
            }



        }
    }
}
