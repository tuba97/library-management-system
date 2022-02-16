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
    public partial class IslemPaneli : Form
    {
        public IslemPaneli()
        {
            InitializeComponent();
        }
        Kutuphane_OtomasyonuEntities db = new Kutuphane_OtomasyonuEntities();
       

        private void IslemPaneli_Load(object sender, EventArgs e)
        {
            ekleKullanicibtn.Visible = false;
            silKullanicibtn.Visible = false;
            gunceleKullanicibtn.Visible = false;

            ekleKaynakbtn.Visible = false;
            silKaynakbtn.Visible = false;
            guncelleKaynakbtn.Visible = false;
        }

        private void Kullanicibtn_Click_1(object sender, EventArgs e)
        {
            if (ekleKullanicibtn.Visible == false)
            {
                ekleKullanicibtn.Visible = true;
                silKullanicibtn.Visible = true;
                gunceleKullanicibtn.Visible = true;
            }

            else
            {
                ekleKullanicibtn.Visible = false;
                silKullanicibtn.Visible = false;
                gunceleKullanicibtn.Visible = false;
            }
            KullaniciListeForm klisteform = new KullaniciListeForm();
            klisteform.Show();
            
        }

        private void guncelKullanicibtn_Click(object sender, EventArgs e)
        {

            KullaniciGuncelleForm Kguncelle = new KullaniciGuncelleForm();
            Kguncelle.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (ekleKaynakbtn.Visible == false)
            {
                ekleKaynakbtn.Visible = true;
                silKaynakbtn.Visible = true;
                guncelleKaynakbtn.Visible = true;
            }
            else
            {
                ekleKaynakbtn.Visible = false;
                silKaynakbtn.Visible = false;
                guncelleKaynakbtn.Visible = false;
            }
            KaynakListeForm kliste = new KaynakListeForm();
            kliste.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            OduncVerForm odunc = new OduncVerForm();
            odunc.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            GeriAlForm geri = new GeriAlForm();

            geri.Show();
        }

        private void ekleKullanicibtn_Click_1(object sender, EventArgs e)
        {
            KullaniciEkleForm kEkle = new KullaniciEkleForm();

            kEkle.Show();
        }

        private void silKullanicibtn_Click_1(object sender, EventArgs e)
        {

            KullaniciSilForm kSil = new KullaniciSilForm();
            kSil.Show();
        }

        private void ekleKaynakbtn_Click_1(object sender, EventArgs e)
        {

            KaynakEkleForm kEkle = new KaynakEkleForm();
            kEkle.Show();
        }

        private void guncelleKaynakbtn_Click_1(object sender, EventArgs e)
        {

            KaynakGuncelleForm kguncelle = new KaynakGuncelleForm();

            kguncelle.Show();
        }

        private void silKaynakbtn_Click_1(object sender, EventArgs e)
        {
            KaynakSilForm silform = new KaynakSilForm();
            silform.Show();
        }
    }
}