using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Lost_and_found
{
    public partial class Form2 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-U6737GM;Initial Catalog=lost_and_found;Integrated Security=True");
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cm = new SqlCommand("select * from Employee where Email=@Email AND Password=@Password", con);
            cm.Parameters.AddWithValue("@Email",textBox1.Text);
            cm.Parameters.AddWithValue("@Password", textBox2.Text);
            SqlDataReader sr = cm.ExecuteReader();
            if (sr.Read())
            {
                textBox1.Text = sr["Email"].ToString();
                textBox2.Text = sr["Password"].ToString();
            Form3 frm3 = new Form3();
            frm3.Show();
            this.Close();
            }
            else 
            {
                string message = "Email or Password might be wrong Try again";
                string title = "invalide Email or Password";
                MessageBox.Show(message, title);
            }
        }

        private void TXT_ONLY_CHAR_KEYPRESS(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TXT_ONLY_NUMBERS_KEYPRESS(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
