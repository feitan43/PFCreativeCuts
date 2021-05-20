using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CreativeCuts
{
    public partial class ViewBooking : Form
    {
        public ViewBooking()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Administrator\Documents\CreativeCutsDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void populate()
        {
            Con.Open();
            string query = "select * from BookingTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            BookingDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            bookkey = 0;
            bookkey = Convert.ToInt32(BookingDGV.Rows[e.RowIndex].Cells["Id"].FormattedValue.ToString());
            
        }

        private void ViewBooking_Load(object sender, System.EventArgs e)
        {
            populate();
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            Booking bk = new Booking();
            bk .Show();
            this.Hide();
        }
        int bookkey = 0;
        private void button3_Click(object sender, System.EventArgs e)
        {
            if (bookkey == 0)
            {
                MessageBox.Show("Select the booking to be deleted");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "Delete from BookingTbl where Id=" + bookkey + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Booking Deleted Successfully");
                    Con.Close();
                    populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void label19_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MainForm mf = new MainForm();
            mf.Show();
            this.Hide();
        }
    }
    }

