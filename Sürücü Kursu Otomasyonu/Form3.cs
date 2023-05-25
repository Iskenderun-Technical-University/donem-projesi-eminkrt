using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sürücü_Kursu_Otomasyonu
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            Sınıf.griddoldur(dataGridView1, "Select * from login");
            dataGridView1.Columns[2].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Surucu_Kursuna_Hosgeldiniz a= new Surucu_Kursuna_Hosgeldiniz();
            a.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Şifre_Güncelleme a= new Şifre_Güncelleme();
            a.Show();

        }
    }
}
