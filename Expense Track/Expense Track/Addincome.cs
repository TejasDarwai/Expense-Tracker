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
    public partial class Addincome : Form
    {
        public Addincome()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\tejas\OneDrive\Documents\ExpenseTrackerDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void clear()
        {
            incname.Text = "";
            incamount.Text = "";
            incdesc.Text = "";
            inccat.SelectedIndex = 0;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (incname.Text == "" || incamount.Text == "" || inccat.SelectedIndex == -1 || incdesc.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into IncomeTbl(IncName, IncAmt, IncCat, IncDate, IncDecs, IncUser)values(@UN, @UA, @UC, @UD, @UDE, @UU)", con);
                    cmd.Parameters.AddWithValue("@UN", incname.Text);
                    cmd.Parameters.AddWithValue("@UA", incamount.Text);
                    cmd.Parameters.AddWithValue("@UC", inccat.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@UD", incdate.Value.Date);
                    cmd.Parameters.AddWithValue("@UDE",incdesc.Text);
                    cmd.Parameters.AddWithValue("@UU", Login.User);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Income Added");
                    con.Close();
                    clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Dashboard obj = new Dashboard();
            obj.Show();
            this.Hide();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            viewincome obj = new viewincome();
            obj.Show();
            this.Hide();
        }

        private void inccat_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            viewexpense obj = new viewexpense();
            obj.Show();
            this.Hide();
        }
    }
}
