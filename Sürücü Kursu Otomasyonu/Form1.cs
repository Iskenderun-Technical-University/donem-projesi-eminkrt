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
    
namespace Sürücü_Kursu_Otomasyonu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        SqlDataReader dr;
        DataSet ds;

        //public static string SqlCon = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=Surucu Kursu;Integreted Security=True";

        public static string kullaniciSession = "";
        private void Form1_Load(object sender, EventArgs e)
        {
            Sınıf.BAG();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(Sınıf.login(textBox1.Text,textBox2.Text))
            {
                kullaniciSession = textBox1.Text;
                this.Hide();
                Form3 a= new Form3();
                a.Show();
            }
            else
            {
                MessageBox.Show("Kullanic adi veya sifre hatali");
            }
        }
    }
}
