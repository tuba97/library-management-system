using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp7
{
    public partial class Form1 : Form
    {
        Kutuphane_OtomasyonuEntities db = new Kutuphane_OtomasyonuEntities();
        private object x;
        public Form1()
        {
            InitializeComponent();
        }
         
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        

        private void GirisBtn_Click(object sender, EventArgs e)
        {
            string gelenAd = adGiriştxt.Text;
            string gelenSifre = şifreGiriştxt.Text;
            var personel = db.Personeller.Where(x => x.personel_ad.Equals(gelenAd) && x.personel_şifre.Equals(gelenSifre)).FirstOrDefault();

            if (personel == null)
            {
                MessageBox.Show(text: "Kullanıcı adı veya şifre hatalı");
            }

            else
            {
                MessageBox.Show(text: "Giriş Başarılı");
                IslemPaneli panel = new IslemPaneli();
                panel.Show();
                this.Hide();

            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void şifreGiriştxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
