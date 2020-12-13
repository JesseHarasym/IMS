using IMS.Database;
using System;
using System.Data;
using System.Data.SqlClient;
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
            bool success = false;
            string nameEntered = txtUserName.Text;
            string passwordEntered = txtPassword.Text;
            string currentUser = "";
            string accessLevel = "";

            string connectionString = Connection.ConnectionString;

            DataTable usersRecords = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand(
                    "SELECT * FROM Accounts WHERE Username = '" + nameEntered + "'", connection);
                adapter.Fill(usersRecords);

                try
                {
                    DataRow dataRow = usersRecords.Rows[0];

                    if (dataRow["Password"].ToString() == passwordEntered)
                    {
                        currentUser = dataRow["Id"].ToString();
                        accessLevel = dataRow["AccessLevel"].ToString();
                        success = true;
                    }
                    else
                    {
                        MessageBox.Show("Wrong username and/or password");
                    }
                }
                catch
                {
                    MessageBox.Show("User not found");
                }
            }

            if (success)
            {
                MessageBox.Show("Log in Successful");
                Close();

                myForm.SetUserName(nameEntered, accessLevel, currentUser);
            }
        }
    }
}
