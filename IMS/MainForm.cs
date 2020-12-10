using IMS.CustomControls;
using System;
using System.Windows.Forms;

namespace IMS
{
    public partial class MainForm : Form
    {
        public int CustomerId;
        public int AccessLevel;

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, System.EventArgs e)
        {
            var logInForm = new LogInForm(this);
            logInForm.Show();
        }

        private void btnCreateUser_Click(object sender, System.EventArgs e)
        {
            var userForm = new AddUser();
            userForm.Show();
        }

        public void SetUserName(string username, string accessLevel, string currentUserId)
        {
            CustomerId = Convert.ToInt32(currentUserId);
            AccessLevel = Convert.ToInt32(accessLevel);

            txtUserName.Text = username;

            if (accessLevel == "0")
            {
                var userControls = new UserControls(CustomerId, AccessLevel);

                txtAccessLevel.Text = "User";

                btnCreateUser.Visible = false;

                btnLogin.Visible = false;
                btnLogout.Visible = true;

                pnlAdmin.Visible = false;
                pnlUser.Visible = true;

                pnlUser.Controls.Add(userControls);
            }
            else if (accessLevel == "1")
            {
                var adminControls = new AdminControls(CustomerId, AccessLevel);
                var userControls = new UserControls(adminControls, CustomerId, AccessLevel);

                txtAccessLevel.Text = "Admin";

                btnLogin.Visible = false;
                btnLogout.Visible = true;

                pnlAdmin.Visible = true;
                pnlUser.Visible = true;

                pnlAdmin.Controls.Add(adminControls);
                pnlUser.Controls.Add(userControls);
            }
        }

        private void btnLogout_Click(object sender, System.EventArgs e)
        {
            txtAccessLevel.Text = "Not Logged In";
            txtUserName.Text = "Not Logged In";

            btnLogout.Visible = false;
            btnLogin.Visible = true;

            pnlAdmin.Visible = false;
            pnlUser.Visible = false;

            btnCreateUser.Visible = true;
        }
    }
}