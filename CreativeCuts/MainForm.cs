using System.Windows.Forms;

namespace CreativeCuts
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, System.EventArgs e)
        {

        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            Customer cust = new Customer();
            cust.Show();
            this.Hide();
        }

        private void button4_Click(object sender, System.EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void button2_Click_1(object sender, System.EventArgs e)
        {
            ViewBooking vb = new ViewBooking();
            vb.Show();
            this.Hide();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            Booking bk = new Booking();
            bk.Show();
            this.Hide();
        }
    }
}
