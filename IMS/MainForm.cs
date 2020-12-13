using IMS.CustomControls;
using System;
using System.Drawing;
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
            var userForm = new RegistrationForm(AccessLevel);
            userForm.Show();
        }

        public void SetUserName(string username, string accessLevel, string currentUserId)
        {
            CustomerId = Convert.ToInt32(currentUserId);
            AccessLevel = Convert.ToInt32(accessLevel);

            txtUserName.Text = username;

            if (accessLevel == "0")
            {
                Size = new Size(706, 535);
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
                Size = new Size(1606, 535);
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
            Size = new Size(688, 130);

            txtAccessLevel.Text = "Not Logged In";
            txtUserName.Text = "Not Logged In";

            btnLogout.Visible = false;
            btnLogin.Visible = true;

            pnlAdmin.Visible = false;
            pnlUser.Visible = false;

            btnCreateUser.Visible = true;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Size = new Size(706, 130);
        }
    }
}