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
    public partial class KaynakGuncelleForm : Form
    {
        public KaynakGuncelleForm()
        {
            InitializeComponent();
        }
        Kutuphane_OtomasyonuEntities db = new Kutuphane_OtomasyonuEntities();
        private void KaynakGuncelleForm_Load(object sender, EventArgs e)
        {
            var kaynek = db.Kaynaklar.ToList();
            dataGridView1.DataSource = kaynek.ToList();
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Ad";
            dataGridView1.Columns[2].HeaderText = "Yazar";
            dataGridView1.Columns[3].HeaderText = "Yayıncı";
            dataGridView1.Columns[4].HeaderText = "SayfaSayısı";
            dataGridView1.Columns[5].HeaderText = "Basım Tarihi";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int secilenId = Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value);
            var guncelleKaynak = db.Kaynaklar.Where(x => x.kaynak_id == secilenId).FirstOrDefault();
            guncelleKaynak.kaynak_ad = adKaynaktxt.Text;
            guncelleKaynak.kaynak_yazar = yazarKaynaktxt.Text;
            guncelleKaynak.kaynak_yayıncı = yayınciKaynaktxt.Text;
            guncelleKaynak.kaynak_sayfasayisi = Convert.ToInt16(numericUpDown1.Value);
            guncelleKaynak.kaynak_basımtarihi = dateTimePicker1.Value;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            adKaynaktxt.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            yazarKaynaktxt.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            yayınciKaynaktxt.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            numericUpDown1.Value = Convert.ToDecimal(dataGridView1.CurrentRow.Cells[4].Value);
            dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[5].Value);
            var kaynek = db.Kaynaklar.ToList();
            dataGridView1.DataSource = kaynek.ToList();
        }
    }
}
