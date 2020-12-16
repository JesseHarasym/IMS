using IMS.Classes.Database.Accounts;
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
            string password = txtPassword.Text;

            var ad = new AccountsDatabase();

            //get relevant user information needed to log in
            var userInformation = ad.GetAccountPassword(username, password);
            bool passwordMatch = userInformation.Item1;     //does password match hashed password in database
            string currentUserId = userInformation.Item2;
            string accessLevel = userInformation.Item3;

            if (passwordMatch)
            {
                MessageBox.Show("Log in Successful");
                Close();

                myForm.SetUserName(username, accessLevel, currentUserId);
            }
            else if (string.IsNullOrEmpty(currentUserId) || string.IsNullOrEmpty(accessLevel))
            {
                MessageBox.Show("Username was not found or the wrong password was entered");
            }
        }
    }
}
