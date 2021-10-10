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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            string cn = ConfigurationManager.ConnectionStrings["StoreDB"].ConnectionString;
            // string cn = @"Data Source=SQL5104.site4now.net:1433;Initial Catalog=db_a7ac7d_storecontextdb;User Id=db_a7ac7d_storecontextdb_admin;Password=MyDBpassword@24;Connect Timeout=30";

            StringBuilder sb = new();
            foreach (var item in lstBoxPass.Items)
            {
                sb.Append(item.ToString());
                sb.Append("");
            }
            //MessageBox.Show(sb.ToString());

            txtPwd.Text = sb.ToString();

            string username = txtUserName.Text;
           
            string fname = txtFullName.Text;
            
            string password = txtPwd.Text;



            //check id and pw
            if (password == "" && fname == "")
            {
                MessageBox.Show("fill all text field appropriately");
                // result.Text = "please check input value";
                return;
            }
            else
            {






                using SqlConnection connection = new(cn);




                // Create a SqlCommand, create a new account.
                using SqlCommand sqlCommand = new("usp_UserAccountGraph", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                // Add input parameter for the stored procedure and specify what to use as its value.
                Random nm = new();

                sqlCommand.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int));
                sqlCommand.Parameters["@ID"].Value = nm.Next(1, 9999);

                sqlCommand.Parameters.Add(new SqlParameter("@userName", SqlDbType.NVarChar, 50));
                sqlCommand.Parameters["@userName"].Value = username;

                sqlCommand.Parameters.Add(new SqlParameter("@pwd", SqlDbType.NVarChar, 100));
                sqlCommand.Parameters["@pwd"].Value = password;

                sqlCommand.Parameters.Add(new SqlParameter("@FullName", SqlDbType.NVarChar, 100));
                sqlCommand.Parameters["@FullName"].Value = fname;










                try
                {
                    connection.Open();

                    // Run the stored procedure.
                    sqlCommand.ExecuteNonQuery();


                    MessageBox.Show("Your Account is created " + MessageBoxButtons.OK + " " + MessageBoxIcon.Information);
                    txtUserName.Clear();

                    txtFullName.Clear();

                    lstBoxPass.Items.Clear();
                    txtPwd.Clear();
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

            txtFullName.Clear();

            lstBoxPass.Items.Clear();
            txtPwd.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 nh = new();
            nh.Hide();
            Form frm = new Login();
            frm.Show();
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
