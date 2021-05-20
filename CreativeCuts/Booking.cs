using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace CreativeCuts
{
    public partial class Booking : Form
    {
        public Booking()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Administrator\Documents\CreativeCutsDb.mdf;Integrated Security=True;Connect Timeout=30");

     

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value.ToString() == "" || cbTime.Text == "" || cbHairstyle.Text == "" || cbBarber.Text == "")
            {
                MessageBox.Show("Missing Data");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "insert into BookingTbl values('" + CustIdCb.Text + "','" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "','" + cbTime.Text + "','" + CustNamelbl.Text + "','" + cbHairstyle.Text + "','" + cbBarber.Text + "' )";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer Successfully Added");
                    ViewBooking vb = new ViewBooking();
                    vb.Show();
                    this.Hide();
                    Con.Close();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void GetCustId()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("select CustId from CustTbl", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("CustId", typeof(string));
            dt.Load(rdr);
            CustIdCb.ValueMember = "CustId";
            CustIdCb.DataSource = dt;
            Con.Close();

        }

        private void Booking_Load(object sender, EventArgs e)
        {
            GetCustId();
        }
        private void fetchCustName()
        {
            Con.Open();
            string mysql = "select * from CustTbl where CustId=" + CustIdCb.SelectedValue.ToString() + ";";
            SqlCommand cmd = new SqlCommand(mysql, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                CustNamelbl.Text = "" + dr["CustName"].ToString();
            }
            Con.Close();
        }

        private void CustIdCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            fetchCustName();
        }
        private void clear()
        {
            cbTime.Text = "";
            cbHairstyle.Text = "";
            cbBarber.Text = "";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            clear();
        }
    }
}
