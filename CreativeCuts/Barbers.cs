using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CreativeCuts
{
    public partial class Barbers : Form
    {
        public Barbers()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Administrator\Documents\CreativeCutsDb.mdf;Integrated Security=True;Connect Timeout=30");

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tb_barberName.Text == "" || tb_barberCont.Text == "" || tb_barberPass.Text == "")
            {
                MessageBox.Show("Missing Data");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "insert into BarberTbl values('" + tb_barberName.Text + "','" + tb_barberCont.Text + "','" + tb_barberPass.Text + "' )";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer Successfully Added");
                    Con.Close();
                    populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        private void Barbers_Load(object sender, EventArgs e)
        {
            populate();
        }
        int barberkey = 0;

        private void populate()
        {
            Con.Open();
            string query = "select * from BarberTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            BarberDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void BarberDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            tb_barberName.Text = BarberDGV.Rows[e.RowIndex].Cells["BarberName"].FormattedValue.ToString();
            tb_barberCont.Text = BarberDGV.Rows[e.RowIndex].Cells["BarberCont"].FormattedValue.ToString();
            tb_barberPass.Text = BarberDGV.Rows[e.RowIndex].Cells["BarberPass"].FormattedValue.ToString();
            if (tb_barberPass.Text == "")
            {
                barberkey = 0;
            }
            else
            {
                barberkey = Convert.ToInt32(BarberDGV.Rows[e.RowIndex].Cells["BarberId"].FormattedValue.ToString());
            }

        }


        private void clear()
        {
            tb_barberName.Text = "";
            tb_barberCont.Text = "";
            tb_barberPass.Text = "";
            barberkey = 0;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (barberkey == 0)
            {
                MessageBox.Show("Select the barber to be deleted");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "Delete from BarberTbl where BarberId=" + barberkey + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Barber Deleted Successfully");
                    Con.Close();
                    populate();
                    clear();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (tb_barberName.Text == "" || tb_barberCont.Text == "" || tb_barberPass.Text == "")
            {
                MessageBox.Show("Missing Data");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "update BarberTbl set BarberName='" + tb_barberName.Text + "',BarberCont='" + tb_barberCont.Text + "',BarberPass='" + tb_barberPass.Text + "' where BarberId=" + barberkey + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer Successfully Updated");
                    Con.Close();
                    populate();
                    clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MainForm mf = new MainForm();
            mf.Show();
            this.Hide();
        }
    }

}