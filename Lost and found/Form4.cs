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

    public partial class Form4 : Form
    {
    SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-U6737GM;Initial Catalog=lost_and_found;Integrated Security=True");
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open(); 
             SqlCommand cm = new SqlCommand("select * from Lost_Item_Info where FullName=@FullName AND Lostitem=@Lostitem AND ItemID=@ItemID AND Governorate=@Governorate AND Address=@Address", con);
            cm.Parameters.AddWithValue("@FullName", textBox1.Text);
            cm.Parameters.AddWithValue("@Lostitem", comboBox1.Text);
            cm.Parameters.AddWithValue("@ItemID", textBox2.Text);
            cm.Parameters.AddWithValue("@Governorate", comboBox2.Text);
            cm.Parameters.AddWithValue("@Address", textBox3.Text);
            SqlDataReader sr = cm.ExecuteReader();
            if (sr.Read())
            {
                textBox1.Text = sr["FullName"].ToString();
                comboBox1.Text = sr["Lostitem"].ToString();
                textBox2.Text = sr["ItemID"].ToString();
                comboBox2.Text = sr["Governorate"].ToString();
                textBox3.Text = sr["Address"].ToString();
                Form5 frm5 = new Form5();
                frm5.Show();
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

        private void TXT_NO_CHAR_OR_NUMBER_KEYPRESS(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && char.IsLetterOrDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TXT_ONLY_NUMBER_KEYPRESS(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
