using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreativeCuts
{
    public partial class AdminLogin : Form
    {
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            if(tb_pass.Text == "")
            {
                MessageBox.Show("Enter Admin Password");
            }
            else if (tb_pass.Text == "Password")
            {
                Barbers br = new Barbers();
                br.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Wrong Password");
            }
        }
    }
}
