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
    public partial class KaynakSilForm : Form
    {
        public KaynakSilForm()
        {
            InitializeComponent();
        }
        Kutuphane_OtomasyonuEntities db = new Kutuphane_OtomasyonuEntities();
        private void KaynakSilForm_Load(object sender, EventArgs e)
        {
            var kaynaklar = db.Kaynaklar.ToList();
            dataGridView1.DataSource = kaynaklar.ToList();
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Ad";
            dataGridView1.Columns[2].HeaderText = "Yazar";
            dataGridView1.Columns[3].HeaderText = "Yayıncı";
            dataGridView1.Columns[4].HeaderText = "SayfaSayısı";
            dataGridView1.Columns[5].HeaderText = "Basım Tarihi";
           
        }

        private void silbtn_Click(object sender, EventArgs e)
        {
            DialogResult silinsinMi = MessageBox.Show(text: "Silmek  İstediğinize Emin Misiniz", caption: "Silme İşlemi", MessageBoxButtons.YesNo);
            if (silinsinMi == DialogResult.Yes) 
            
            {
                int secilenId = Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value);
            var silinKaynak = db.Kaynaklar.Where(x => x.kaynak_id == secilenId).FirstOrDefault();
            db.Kaynaklar.Remove(silinKaynak);
            db.SaveChanges();
            var kaynak = db.Kaynaklar.ToList();
                dataGridView1.DataSource = kaynak.ToList();
                       
                MessageBox.Show(text: "Silindi");

            }
            else
            {
                MessageBox.Show(text: "Silme İşlemi Başarısız");
            }

        }
    }
}
