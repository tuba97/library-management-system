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
    public partial class KullaniciEkleForm : Form
    {
        public KullaniciEkleForm()
        {
            InitializeComponent();
        }
        Kutuphane_OtomasyonuEntities db = new Kutuphane_OtomasyonuEntities();
        public void Listele()
        {

            var kullanicilar = db.kullanıcılar.ToList();
            dataGridView1.DataSource = kullanicilar.ToList();
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Ad";
            dataGridView1.Columns[2].HeaderText = "SoyAd";
            dataGridView1.Columns[3].HeaderText = "TC";
            dataGridView1.Columns[4].HeaderText = "Email";
            dataGridView1.Columns[5].HeaderText = "Telefon No";
            dataGridView1.Columns[6].HeaderText = "Ceza";
            dataGridView1.Columns[7].HeaderText = "Cinsiyet";

        }



        private void KullaniciEkleForm_Load(object sender, EventArgs e)
        {

            Listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            kullanıcılar kullanici = new kullanıcılar();
            kullanici.kullanici_id = Convert.ToInt32(kullaniciIdtxt.Text);
            kullanici.kullanici_ad = kullaniciAdtxt.Text;
            kullanici.kullanıcı_soyad = kullaniciSoyadtxt.Text;
            kullanici.kullanici_tc = kullaniciTctxt.Text;
            kullanici.kullanici_tel = kullaniciTeltxt.Text;
            kullanici.kullanici_email = kullaniciEmailtxt.Text;
            kullanici.kullanici_ceza = Convert.ToDouble(kullaniciCezatxt.Text);
            if (Eradio.Checked == true)
            {
                kullanici.kullanici_cinsiyet = "E";
            }
            else if (Kradio.Checked == true)
            {
                kullanici.kullanici_cinsiyet = "K";
            }
            db.kullanıcılar.Add(kullanici);
            db.SaveChanges();
            Listele();
        }
    }
}