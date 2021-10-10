using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicalAuthPass
{
    public partial class WelcomePage : Form
    {
        public WelcomePage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login fl = new();
            fl.Show();
        }

        private void WelcomePage_Load(object sender, EventArgs e)
        {
            labelUserAcc.Text = Login.SetUserName;
        }
    }
}
