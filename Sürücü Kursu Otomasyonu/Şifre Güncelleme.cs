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
using System.Security.Cryptography;

namespace Sürücü_Kursu_Otomasyonu
{
    public partial class Şifre_Güncelleme : Form
    {
        SqlConnection con;

        SqlDataReader dr;
        SqlCommand cmd;
        //public static string SqlCon = @"Data Source=localhost\SQLEXPRESS;Initial Catalog = Surucu Kursu; Integrated Security = True";
        public int sonuc = 0;
        public Şifre_Güncelleme()
        {
            InitializeComponent();
        }

        private void Şifre_Güncelleme_Load(object sender, EventArgs e)
        {

            label5.Name = "";
            CaptchaSayıDegistir();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            label5.Text = "";
            if (textBox4.Text == sonuc.ToString())
            {
                if (textBox2.Text == textBox3.Text)
                {
                    eskisifre();

                }
                else
                {
                    label6.Text = "Eski Ve Yeni Şifreniz Aynı Değildir";
                    CaptchaSayıDegistir();
                }
            }
            else
            {
                label6.Text = "Captcha Hatalı Girildi ";
                CaptchaSayıDegistir();
            }
        }
        public bool eskisifre()
        {
            string sorgu = "select sifre from tbl_login where kullanıcı=@user and sifre=@pass";
            con = new SqlConnection(Sınıf.BAG());
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@user", Form1.kullaniciSession);
            cmd.Parameters.AddWithValue("@pass", Sınıf.MD5sifreleme(textBox1.Text));

            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string sql = "update tbl_login set sifre='" + Sınıf.MD5sifreleme(textBox2.Text) + "'";
                Sınıf.kom(sql);
                MessageBox.Show("Şifreniz Başarıyla Değiştirilmiştir");
            }
            else
            {
                label6.Text = "Eski Şifreniz Hatalıdır";
                CaptchaSayıDegistir();
            }
            con.Close();
            return true;
        }
        public void CaptchaSayıDegistir()
        {
            Random sayı = new Random();
            int bir = sayı.Next(0, 50);
            int iki = sayı.Next(0, 50);
            sonuc = bir + iki;
            label4.Text = bir.ToString() + "+" + iki.ToString() + "=";
            textBox4.Clear();
        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            label5.Text = "";
            if (textBox4.Text == sonuc.ToString())
            {
                if (textBox2.Text == textBox3.Text)
                {
                    eskisifre();

                }
                else
                {
                    label6.Text = "Eski Ve Yeni Şifreniz Aynı Değildir";
                    CaptchaSayıDegistir();
                }
            }
            else
            {
                label6.Text = "Captcha Hatalı Girildi ";
                CaptchaSayıDegistir();
            }
        }
    }
}
    

