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
    public partial class Addexpense : Form
    {
        public Addexpense()
        {
            InitializeComponent();
        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\tejas\OneDrive\Documents\ExpenseTrackerDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void clear()
        {
            expname.Text = "";
            expamount.Text = "";
            expcat.SelectedIndex = 0;
            expdesc.Text = "";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (expname.Text == "" || expamount.Text == "" || expcat.SelectedIndex == -1 || expdesc.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into ExpenseTbl(ExpName, ExpAmt, ExpCat, ExpDate, ExpDesc, ExpUser)values(@EN, @EA, @EC, @ED, @EDE, @EU)", con);
                    cmd.Parameters.AddWithValue("@EN", expname.Text);
                    cmd.Parameters.AddWithValue("@EA", expamount.Text);
                    cmd.Parameters.AddWithValue("@EC", expcat.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@ED", expdate.Value.Date);
                    cmd.Parameters.AddWithValue("@EDE", expdesc.Text);
                    cmd.Parameters.AddWithValue("@EU", Login.User);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Expense Added");
                    con.Close();
                    clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            viewexpense obj = new viewexpense();
            obj.Show();
            this.Hide();
        }

        private void expamount_TextChanged(object sender, EventArgs e)
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
    }
}
