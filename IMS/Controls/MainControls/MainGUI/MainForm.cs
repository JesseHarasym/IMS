using IMS.CustomControls;
using System;
using System.Drawing;
using System.Linq;
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
            logInForm.ShowDialog();

        }

        private void btnCreateUser_Click(object sender, System.EventArgs e)
        {
            var userForm = new RegistrationForm(AccessLevel);
            userForm.ShowDialog();
        }

        public void SetUserName(string username, string accessLevel, string currentUserId)
        {
            CustomerId = Convert.ToInt32(currentUserId);
            AccessLevel = Convert.ToInt32(accessLevel);

            txtUserName.Text = username;

            if (accessLevel == "0")
            {
                Size = new Size(706, 560);
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
                Size = new Size(1606, 560);
                var adminControls = new AdminControls(CustomerId, AccessLevel);
                var userControls = new UserControls(adminControls, CustomerId, AccessLevel);

                txtAccessLevel.Text = "Admin";

                btnLogin.Visible = false;
                btnLogout.Visible = true;

                pnlAdmin.Visible = true;
                pnlUser.Visible = true;

                pnlUser.Controls.Add(userControls);
                pnlAdmin.Controls.Add(adminControls);

            }
        }

        private void btnLogout_Click(object sender, System.EventArgs e)
        {
            Size = new Size(688, 130);

            txtAccessLevel.Text = "Not Logged In";
            txtUserName.Text = "Not Logged In";

            btnLogout.Visible = false;
            btnLogin.Visible = true;

            btnCreateUser.Visible = true;

            //clear controls from user login
            pnlUser.Controls.Clear();
            pnlAdmin.Controls.Clear();

            //close any forms that may have been open when attempting to logout
            Form[] forms = Application.OpenForms.Cast<Form>().ToArray();
            foreach (Form thisForm in forms)
            {
                if (thisForm.Name != "MainForm") thisForm.Close();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Size = new Size(706, 130);
        }
    }
}