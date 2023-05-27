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
    public partial class Surucu_Kursuna_Hosgeldiniz : Form
    {
        public Surucu_Kursuna_Hosgeldiniz()
        {
            InitializeComponent();
        }
        public static string f = "";
            
        public static int fiyat;
        private void button1_Click(object sender, EventArgs e)

        {
            f = textBox2.Text;
            this.Hide();
            Form2 a = new Form2();
            a.Show();

        }

        private void Surucu_Kursuna_Hosgeldiniz_Load(object sender, EventArgs e)
        {
            Sınıf.griddoldur(dataGridView1,"select * from ehliyet");
            dataGridView1.Columns[0].Visible = false;


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
