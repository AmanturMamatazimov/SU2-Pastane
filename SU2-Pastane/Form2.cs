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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection bag = new SqlConnection(@"server=DESKTOP-DNDEKN8\SQLEXPRESS;initial catalog=pastane;integrated security=yes");
        public void kategorigetir()
        {
            string sql = "select * from kategoriler";
            SqlDataAdapter da = new SqlDataAdapter(sql,bag);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = dt.Columns[1].ColumnName; //"kategori";
            comboBox1.ValueMember = "kategorino";
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            kategorigetir();
            hareketlerilistele();
        }

        public void hareketlerilistele()
        {
            string sql = "select * from hareketler";
            SqlDataAdapter da = new SqlDataAdapter(sql, bag);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string kategori = comboBox1.SelectedValue.ToString();
            string sql = "Select * from urunler where kategorino='"+kategori+"'";
            SqlDataAdapter da = new SqlDataAdapter(sql,bag);
            DataTable dt = new DataTable();
            da.Fill(dt);
            listBox1.DataSource = dt;
            listBox1.ValueMember = "urunno";
            listBox1.DisplayMember = "urun";
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string urun = listBox1.SelectedValue.ToString();//global tanimla
            string sql = "select * from urunler where urunno='" + urun + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql,bag);
            DataTable dt = new DataTable();
            da.Fill(dt);
            textBox2.Text = dt.Rows[0][4].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string urunno = listBox1.SelectedValue.ToString();//global tanimla
            string miktar = textBox1.Text;
            string tarih = DateTime.Now.ToShortDateString();
            string sql = "insert into hareketler(urunno,adet,tarih,hareket_tip) values('"+urunno+"','"+miktar+"','"+tarih+"',1)";
            SqlCommand komut = new SqlCommand(sql, bag);
            bag.Open();
            komut.ExecuteNonQuery();
            bag.Close();
        }
    }
}
