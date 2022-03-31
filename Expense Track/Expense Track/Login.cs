using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Expense_Track
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\tejas\OneDrive\Documents\ExpenseTrackerDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void label2_Click(object sender, EventArgs e)
        {
            Users obj = new Users();
            obj.Show();
        }
        public static string User;
        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if (Uname.Text == "" || Upass.Text == "")
            {
                MessageBox.Show("Missing UserName or Password");
            }
            else
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select count (*) from UserTbl where Uname = '" + Uname.Text + "' and Upass = '" + Upass.Text + "'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    User = Uname.Text;
                    Dashboard obj = new Dashboard();
                    obj.Show();
                    this.Hide();
                    con.Close();
                }
                else
                {
                    MessageBox.Show("Wrong UserName or Password");
                    Uname.Text = "";
                    Upass.Text = "";
                }
                con.Close();

            }
            
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Uname_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
