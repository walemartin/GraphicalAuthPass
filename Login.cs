using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicalAuthPass
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        public static string SetUserName = "";
        private void BtnRegister_Click(object sender, EventArgs e)
        {
            string cn = ConfigurationManager.ConnectionStrings["StoreDB"].ConnectionString;

            StringBuilder sb = new();
            foreach (var item in lstBoxPass.Items)
            {
                sb.Append(item.ToString());
                sb.Append("");
            }
            //MessageBox.Show(sb.ToString());

            txtPwd.Text = sb.ToString();
            string username = txtUserName.Text;

            string password = txtPwd.Text;

            //check id and pw
            if (password == "" && username == "")
            {
                MessageBox.Show("Please enter username or color combination");
                // result.Text = "please check input value";
                return;
            }
            else
            {

                using SqlConnection connection = new(cn);

                // Create a SqlCommand, create a new account.
                using SqlCommand sqlCommand = new("usp_UserAuthenticationGraph", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                // Add input parameter for the stored procedure and specify what to use as its value.


                sqlCommand.Parameters.Add(new SqlParameter("@userName", SqlDbType.NVarChar, 50));
                sqlCommand.Parameters["@userName"].Value = username;

                sqlCommand.Parameters.Add(new SqlParameter("@pwd", SqlDbType.NVarChar, 100));
                sqlCommand.Parameters["@pwd"].Value = password;








                try
                {
                    connection.Open();
                    SqlDataAdapter adapt = new SqlDataAdapter(sqlCommand);
                    DataSet ds = new();
                    adapt.Fill(ds);
                    connection.Close();
                    int count = ds.Tables[0].Rows.Count;
                    //If count is equal to 1, than show frmMain form
                    if (count == 1)
                    {
                        //MessageBox.Show("Login Successful!");
                        this.Close();
                        SetUserName = username;
                        Form frm = new WelcomePage();
                        frm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Login Failed!");
                        txtUserName.Clear();
                        lstBoxPass.Items.Clear();
                        txtPwd.Clear();
                        txtUserName.Focus();


                    }
                    // Run the stored procedure.
                    // sqlCommand.ExecuteNonQuery();


                    // MessageBox.Show("Your Account is created " + MessageBoxButtons.OK + " " + MessageBoxIcon.Information);
                    // Form frm = new WelcomeForm();
                    // frm.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    connection.Close();
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtUserName.Clear();
            lstBoxPass.Items.Clear();
            txtPwd.Clear();
            txtUserName.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int a = 1;
            lstBoxPass.Items.Add(a);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int a = 2;
            lstBoxPass.Items.Add(a);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int a = 3;
            lstBoxPass.Items.Add(a);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int a = 4;
            lstBoxPass.Items.Add(a);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int a = 5;
            lstBoxPass.Items.Add(a);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int a = 6;
            lstBoxPass.Items.Add(a);
        }
    }
}
