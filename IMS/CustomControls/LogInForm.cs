using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMS.CustomControls
{
    public partial class LogInForm : Form
    {
        public MainForm myForm;
        public LogInForm(MainForm _form)
        {
            this.myForm = _form;
            InitializeComponent();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            string nameEntered = txtUserName.Text;
            string passwordEntered = txtPassword.Text;

            string connectionString =
            @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dk_ab\Dropbox\BVC\SODV 2202 - OoP\Project OOP\IMS\Database\IMS_Database.mdf;Integrated Security=True";

            DataTable usersRecords = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand(
                    "SELECT * FROM Users WHERE Name = '"+ nameEntered +"'", connection);
                adapter.Fill(usersRecords);


                try
                {
                    DataRow dataRow = usersRecords.Rows[0];

                    if (dataRow["Password"].ToString() == passwordEntered)
                    {
                        MessageBox.Show("Log in Successful");
                        if (dataRow["AccessLevel"].ToString() == "1")
                        {
                            myForm.SetUserName(nameEntered, "1");

                        }
                        else
                        {
                            myForm.SetUserName(nameEntered, "0");
                        }

                        this.Close();

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
