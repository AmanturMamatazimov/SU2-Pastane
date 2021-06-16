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

namespace SU2_Pastane
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection bag = new SqlConnection(@"server=DESKTOP-DNDEKN8\SQLEXPRESS;initial catalog=pastane;integrated security=yes");
            string kadi = textBox1.Text;
            string sifre = textBox2.Text;
            string sql="select * from kullanicilar where kuladi='"+kadi+"' and sifre='"+sifre+"'";
            SqlDataAdapter da = new SqlDataAdapter(sql, bag);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count>0)
            {
                Form2 frm2 = new Form2();
                frm2.ShowDialog();
            }
            else
            {
                label3.Visible = true;
                label3.Font = new Font("Arial", 7, FontStyle.Bold);
                label3.ForeColor = Color.Red;
                label3.Text = "Kullanici adi veya sifre yanlis";
            }
        }
    }
}
