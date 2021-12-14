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
    public partial class Form3 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-U6737GM;Initial Catalog=lost_and_found;Integrated Security=True");

        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cm = new SqlCommand("INSERT INTO Lost_Item_Info (FullName,Lostitem,ItemID,Governorate,Address) VALUES (@FullName,@Lostitem,@ItemID,@Governorate,@Address)", con);
            con.Open();
            cm.Parameters.AddWithValue("@FullName",textBox1.Text);
            cm.Parameters.AddWithValue("@Lostitem", comboBox1.SelectedItem.ToString());
            cm.Parameters.AddWithValue("@ItemID", textBox2.Text);
            cm.Parameters.AddWithValue("@Governorate", comboBox2.SelectedItem.ToString());
            cm.Parameters.AddWithValue("@Address", textBox3.Text);
            cm.ExecuteNonQuery();
            string message = "information saved";
            string title = "Title";
            MessageBox.Show(message, title);
            this.Close();
        }

        private void TXT_ONLY_CHAR_KEYPRESS(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TXT_NO_CHAR_AND_NUMBERS_KEYPRESS(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && char.IsLetterOrDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
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
