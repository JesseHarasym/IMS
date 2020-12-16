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

        //if login is clicked then display login form
        private void btnLogin_Click(object sender, System.EventArgs e)
        {
            var logInForm = new LogInForm(this);
            logInForm.ShowDialog();

        }

        //if create is clicked then display registration form
        private void btnCreateUser_Click(object sender, System.EventArgs e)
        {
            var userForm = new RegistrationForm(AccessLevel);
            userForm.ShowDialog();
        }

        //set user information according to data recieved after logging in successfully
        public void SetUserName(string username, string accessLevel, string currentUserId)
        {
            CustomerId = Convert.ToInt32(currentUserId);
            AccessLevel = Convert.ToInt32(accessLevel);

            //display logged in users username
            txtUserName.Text = username;

            //setup for regular user form view
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
            //setup for admins form view
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

        //if a user logs out then reset all information accordingly for the next login
        private void btnLogout_Click(object sender, System.EventArgs e)
        {
            Size = new Size(688, 130);  //return to not logged in size when user logs out

            //reset all relevant login information
            AccessLevel = 0;
            CustomerId = 0;

            txtAccessLevel.Text = "Not Logged In";
            txtUserName.Text = "Not Logged In";

            btnLogout.Visible = false;
            btnLogin.Visible = true;

            btnCreateUser.Visible = true;

            //clear controls from user login
            pnlUser.Controls.Clear();
            pnlAdmin.Controls.Clear();

            //close any forms that may have been open when attempting to logout
            //was originally because we used Show() instead of ShowDialog(), but kept just in case something was missed
            Form[] forms = Application.OpenForms.Cast<Form>().ToArray();
            foreach (Form thisForm in forms)
            {
                if (thisForm.Name != "MainForm") thisForm.Close();
            }
        }

        //make form this size by default so you can only see login/register portion when not logged in
        private void MainForm_Load(object sender, EventArgs e)
        {
            Size = new Size(706, 130);
        }
    }
}