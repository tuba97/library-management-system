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
    public partial class OduncVerForm : Form
    {
        public OduncVerForm()
        {
            InitializeComponent();
        }
        Kutuphane_OtomasyonuEntities db = new Kutuphane_OtomasyonuEntities();
        private void OduncVerForm_Load(object sender, EventArgs e)
        {
            var kayitList = db.Kayitlar.ToList();
            dataGridView1.DataSource = kayitList.ToList();

            var kaynakList = db.Kaynaklar.ToList();
            dataGridView2.DataSource = kaynakList.ToList();

            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string aranan = Tcbultxt.Text;
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

        private void Tcbultxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string gelenAd = textBox1.Text;
            var bulunanKaynaklar = db.Kaynaklar.Where(x => x.kaynak_ad.Contains(gelenAd)).ToList();
            dataGridView2.DataSource = bulunanKaynaklar;

        }

        private void button2_Click(object sender, EventArgs e)
        {
           string secilenKisiTc = Tcbultxt.Text;
            var secilenKisi = db.kullanıcılar.Where(x => x.kullanici_tc.Equals(secilenKisiTc)).FirstOrDefault();
            int secilenKitapId = Convert.ToInt16(dataGridView2.CurrentRow.Cells[0].Value);
            var secilenKitap = db.Kaynaklar.Where(x => x.kaynak_id == secilenKitapId).FirstOrDefault();

            Kayitlar yeniKayit = new Kayitlar();
            yeniKayit.kitap_id = secilenKitap.kaynak_id;
            yeniKayit.kullanici_id = secilenKisi.kullanici_id;
            yeniKayit.alis_tarihi = DateTime.Today;
            yeniKayit.son_tarih = DateTime.Today.AddDays(15);
            yeniKayit.durum = false;
            db.Kayitlar.Add(yeniKayit);
            db.SaveChanges();
            var kayitList = db.Kayitlar.ToList();
            dataGridView1.DataSource = kayitList.ToList();
        }
    }
}
