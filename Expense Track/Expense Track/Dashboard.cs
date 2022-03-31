using System.Data;
using System.Data.SqlClient;

namespace Expense_Track
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            GetTotInc();
            GetTotExp();
            GetIncCount();  
            GetExpCount();  
            GetLastIncDate();
            GetLastExpDate();
            GetMaxInc();
            GetMaxExp();
            GetMinInc();
            GetMinExp();
            GetBalance();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\tejas\OneDrive\Documents\ExpenseTrackerDb.mdf;Integrated Security=True;Connect Timeout=30");
        int Inc, Exp;
        private void GetTotInc()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Sum(IncAmt) from IncomeTbl where IncUser = '" + Login.User + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            totalincome.Text = dt.Rows[0][0].ToString();
            con.Close();
        }
        private void GetTotExp()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Sum(ExpAmt) from ExpenseTbl where ExpUser = '" + Login.User + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            totalexpense.Text = dt.Rows[0][0].ToString();
            con.Close();
        }
        private void GetIncCount()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Count(*) from IncomeTbl where IncUser = '" + Login.User + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            totalincometransactions.Text = dt.Rows[0][0].ToString();
            con.Close();
        }
        private void GetExpCount()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Count(*) from ExpenseTbl where ExpUser = '" + Login.User + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            totalexpensetransactions.Text = dt.Rows[0][0].ToString();
            con.Close();
        }
        private void GetLastIncDate()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Max(IncDate) from IncomeTbl where IncUser = '" + Login.User + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            lastincomedate.Text = dt.Rows[0][0].ToString();
            lastinc.Text = dt.Rows[0][0].ToString();
            con.Close();
        }
        private void GetMaxInc()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Max(IncAmt) from IncomeTbl where IncUser = '" + Login.User + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            maxinc.Text = dt.Rows[0][0].ToString();
            Inc = Convert.ToInt32(dt.Rows[0][0]);
            con.Close();
        }
        private void GetMinInc()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Min(IncAmt) from IncomeTbl where IncUser = '" + Login.User + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            mininc.Text = dt.Rows[0][0].ToString();
            con.Close();
        }
        private void GetLastExpDate()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Max(ExpDate) from ExpenseTbl where ExpUser = '" + Login.User + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            lastexpensedate.Text = dt.Rows[0][0].ToString();
            lastexp.Text = dt.Rows[0][0].ToString();
            con.Close();
        }
        private void GetMaxExp()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Max(ExpAmt) from ExpenseTbl where ExpUser = '" + Login.User + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            maxexp.Text = dt.Rows[0][0].ToString();
            Exp = Convert.ToInt32(dt.Rows[0][0]);
            con.Close();
        }
        private void GetBalance()
        {
            double net = Inc - Exp;
            balance.Text = ""+net;
        }
        private void GetMinExp()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Min(ExpAmt) from ExpenseTbl where ExpUser = '" + Login.User + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            minexp.Text = dt.Rows[0][0].ToString();
            con.Close();
        }
        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Addincome obj = new Addincome();
            obj.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Addexpense obj = new Addexpense();
            obj.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
           viewincome obj = new viewincome();
            obj.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            viewexpense obj = new viewexpense();
            obj.Show();
            this.Hide();
        }
    }
}