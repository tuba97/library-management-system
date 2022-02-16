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
    public partial class KaynakEkleForm : Form
    {
        public KaynakEkleForm()
        {
            InitializeComponent();
        }
        Kutuphane_OtomasyonuEntities db = new Kutuphane_OtomasyonuEntities();
        private void KaynakEkleForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Kaynaklar kaynak = new Kaynaklar();
            kaynak.kaynak_ad = adKaynaktxt.Text;
            kaynak.kaynak_yazar = yazarKaynaktxt.Text;
            kaynak.kaynak_yayıncı = yayınciKaynaktxt.Text;
            kaynak.kaynak_sayfasayisi = Convert.ToInt16(numericUpDown1.Value);
            kaynak.kaynak_basımtarihi = dateTimePicker1.Value;
            db.Kaynaklar.Add(kaynak);
            db.SaveChanges();

            var kliste = db.Kaynaklar.ToList();
            dataGridView1.DataSource = kliste.ToList();
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Ad";
            dataGridView1.Columns[2].HeaderText = "Yazar";
            dataGridView1.Columns[3].HeaderText = "Yayıncı";
            dataGridView1.Columns[4].HeaderText = "SayfaSayısı";
            dataGridView1.Columns[5].HeaderText = "Basım Tarihi";
        }
    }
}
