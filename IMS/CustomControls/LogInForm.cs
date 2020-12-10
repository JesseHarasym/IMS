using System;
using System.Configuration;
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
            string nameEntered = txtUserName.Text;
            string passwordEntered = txtPassword.Text;

            string connectionString = ConfigurationManager.ConnectionStrings["IMS_DatabaseConnectionString"].ConnectionString;

            DataTable usersRecords = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand(
                    "SELECT * FROM Users WHERE Name = '" + nameEntered + "'", connection);
                adapter.Fill(usersRecords);

                try
                {
                    DataRow dataRow = usersRecords.Rows[0];

                    if (dataRow["Password"].ToString() == passwordEntered)
                    {
                        MessageBox.Show("Log in Successful");

                        string currentUser = dataRow["Id"].ToString();
                        string accessLevel = dataRow["AccessLevel"].ToString();

                        myForm.SetUserName(nameEntered, accessLevel, currentUser);

                        Close();
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
        }
    }
}
