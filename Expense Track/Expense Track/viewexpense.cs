using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Expense_Track
{
    public partial class viewexpense : Form
    {
        public viewexpense()
        {
            InitializeComponent();
            DisplayExpense();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\tejas\OneDrive\Documents\ExpenseTrackerDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void DisplayExpense()
        {
            con.Open();
            string Query = "select * from ExpenseTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ExpenseDvg.DataSource = ds.Tables[0];
            con.Close();
        }
        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ExpenseDvg_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Dashboard obj = new Dashboard();
            obj.Show();
            this.Hide();
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
            viewincome obj = new viewincome();
            obj.Show();
            this.Hide();
        }

        private void pictureBox8_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
