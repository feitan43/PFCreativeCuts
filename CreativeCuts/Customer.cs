using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CreativeCuts
{
    public partial class Customer : Form
    {

        public Customer()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Administrator\Documents\CreativeCutsDb.mdf;Integrated Security=True;Connect Timeout=30");


        private void button1_Click(object sender, EventArgs e)
        {
            if (tb_custName.Text == "" || tb_custCont.Text == "" || tb_custPass.Text == "")
            {
                MessageBox.Show("Missing Data");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "insert into CustTbl values('" + tb_custName.Text + "','" + tb_custCont.Text + "','" + tb_custPass.Text + "' )";
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
        private void populate()
        {
            Con.Open();
            string query = "select * from CustTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            CustomerDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void Customer_Load(object sender, EventArgs e)
        {
            populate();
        }
        int custkey = 0;
        private void CustomerDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            tb_custName.Text = CustomerDGV.Rows[e.RowIndex].Cells["custName"].FormattedValue.ToString();
            tb_custCont.Text = CustomerDGV.Rows[e.RowIndex].Cells["custCont"].FormattedValue.ToString();
            tb_custPass.Text = CustomerDGV.Rows[e.RowIndex].Cells["custPass"].FormattedValue.ToString();
            if(tb_custPass.Text == "")
            {
                custkey = 0;
            }else
            {
                custkey = Convert.ToInt32(CustomerDGV.Rows[e.RowIndex].Cells["custId"].FormattedValue.ToString());
            }

        }

        private void clear()
        {
            tb_custName.Text = "";
            tb_custCont.Text = "";
            tb_custPass.Text = "";
        }
        private void button4_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(custkey == 0)
            {
                MessageBox.Show("Select the customer to be deleted");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "Delete from CustTbl where CustId=" + custkey + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer Deleted Successfully");
                    Con.Close();
                    populate();
                    clear();
                   
                }catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (tb_custName.Text == "" || tb_custCont.Text == "" || tb_custPass.Text == "")
            {
                MessageBox.Show("Missing Data");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "update CustTbl set custName='"+tb_custName.Text+"',custCont='"+tb_custCont.Text+"',custPass='" + tb_custPass.Text+"' where custId=" + custkey + ";";
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
