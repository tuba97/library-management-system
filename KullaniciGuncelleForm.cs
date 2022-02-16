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
    public partial class KullaniciGuncelleForm : Form
    {
        public KullaniciGuncelleForm()
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
        private void KullaniciGuncelleForm_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            kullaniciAdtxt.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            kullaniciSoyadtxt.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            kullaniciTctxt.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            kullaniciTeltxt.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            kullaniciEmailtxt.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            kullaniciCezatxt.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            if (dataGridView1.CurrentRow.Cells[7].Value.ToString().Equals("E"))
            {
                Eradio.Checked = true;
            }
               
            else
            {
                Kradio.Checked = true;
            }
        }

        

        private void button1_Click(object sender, EventArgs e)
        {

            int secilenId = Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value);
            var kullan = db.kullanıcılar.Where(x => x.kullanici_id == secilenId).FirstOrDefault();
              
            
        
            if (Eradio.Checked == true)
            {
                kullan.kullanici_cinsiyet = "E";
            }
            else if (Kradio.Checked == true)
            {
                kullan.kullanici_cinsiyet = "K";
            }
            
            db.SaveChanges();
            Listele();
            
        }
        }

        
    }

