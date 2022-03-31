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
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\tejas\OneDrive\Documents\ExpenseTrackerDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void clear()
        {
            Uname.Text = "";
            Upass.Text = "";
            Uphone.Text = "";
            Upass.Text = "";
        }
        private void RegisterBtn_Click(object sender, EventArgs e)
        {
            if(Uname.Text == "" || Upass.Text == "" || Uaddress.Text == "" || Uphone.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into UserTbl(Uname, Udob, UPhone, UPass, UAdd)values(@UN, @UD, @UP, @UPA, @UA)", con);
                    cmd.Parameters.AddWithValue("@UN", Uname.Text);
                    cmd.Parameters.AddWithValue("@UD", Udob.Value.Date);
                    cmd.Parameters.AddWithValue("@UP", Uphone.Text);
                    cmd.Parameters.AddWithValue("@UPA", Upass.Text);
                    cmd.Parameters.AddWithValue("@UA", Uaddress.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User Added");
                    con.Close();
                    clear();
                }
                catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
