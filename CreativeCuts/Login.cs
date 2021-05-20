using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace CreativeCuts
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Administrator\Documents\CreativeCutsDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            AdminLogin log = new AdminLogin();
            log.Show();
            this.Hide();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            
            if(tb_user.Text == "" || tb_pass.Text == "")
                {
                    MessageBox.Show("Enter Username and Password");
                }else
            {
                try
                {
                    Con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter("select COUNT(*) from BarberTbl where BarberName='" + tb_user.Text + "' and BarberPass='" + tb_pass.Text + "'", Con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows[0][0].ToString() == "1")
                    {
                        MainForm Home = new MainForm();
                        Home.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Wrong Username or Password");
                        tb_user.Text = "";
                        tb_pass.Text = "";
                    }
                    Con.Close();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }

        }
           
    }
}
