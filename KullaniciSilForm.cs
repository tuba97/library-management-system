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
    public partial class KullaniciSilForm : Form
    {
        public KullaniciSilForm()
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

        private void KullaniciSilForm_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void silbtn_Click(object sender, EventArgs e)
        {
            DialogResult silinsinMi = MessageBox.Show(text: "Silmek  İstediğinize Emin Misiniz", caption: "Silme İşlemi", MessageBoxButtons.YesNo);
            if (silinsinMi == DialogResult.Yes)
            {
                int secilenId = Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value);
                var kullanici = db.kullanıcılar.Where(x => x.kullanici_id == secilenId).FirstOrDefault();
                db.kullanıcılar.Remove(kullanici);
                db.SaveChanges();
                Listele();
                MessageBox.Show(text: "Silindi");

            }
            else
            {
                MessageBox.Show(text: "Silme İşlemi Başarısız");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string aranan = textBox1.Text;
            var kullaniciVarmi = db.kullanıcılar.Where(x => x.kullanici_tc == aranan).FirstOrDefault();
            if (kullaniciVarmi != null)
            {
                label2.Text = kullaniciVarmi.kullanici_ad + " " + kullaniciVarmi.kullanıcı_soyad;


            }
            else
            {
                label2.Text = "Böyle bir kullanıcı henüz yok";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }





}

