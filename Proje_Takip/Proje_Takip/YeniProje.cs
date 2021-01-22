using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proje_Takip
{
    public partial class YeniProje : Form
    {
        public YeniProje()
        {
            InitializeComponent();
        }


        public YeniProje(Proje projeGetir)
        {
            InitializeComponent();
            pr = projeGetir;
        }


        public Proje pr = new Proje();


        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            bool kontrol = true;
            foreach (Control item in this.Controls)
            {
                if(item is TextBox)
                {
                    TextBox t = (TextBox)item;
                    if (String.IsNullOrEmpty(t.Text))
                    {
                        kontrol = false;
                        break;
                    }
                }
            }


            if (kontrol)
            {                
                pr.ProjeAdi = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(this.txt_projeAdi.Text.Trim());
                pr.Musteri = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(this.txt_musteri.Text.Trim());
                pr.Aciklama = txt_aciklama.Text.Trim();
                if(pr.Id <= 0)
                {
                    Baglan.Baglanti().yeniProje(pr);
                    MessageBox.Show("Yeni proje oluşturuldu...");
                }
                else
                {
                    Baglan.Baglanti().projeDuzenle(pr);
                    MessageBox.Show("Proje bilgileri güncellendi...");
                }
                    
                this.Close();
            }
            else
            {
                MessageBox.Show("Lütfen boş alan bırakmayınız...");
            }
            
        }

        private void YeniProje_Load(object sender, EventArgs e)
        {
            if (pr.Id > 0)
            {
                txt_projeAdi.Text = pr.ProjeAdi;
                txt_musteri.Text = pr.Musteri;
                txt_aciklama.Text = pr.Aciklama;

                int tahminiSure = 0;
                int gecenSure = 0;
                foreach (Gorev item in pr.Gorevler)
	            {
		            tahminiSure += Baglan.Baglanti().KisiOrtalamasi(item.Gorevli);
                    gecenSure += Baglan.Baglanti().GecenSure(item.Id);
	            }
                int TahminiSaat = tahminiSure / 60;
                int TahminiDakika = tahminiSure % 60;

                int GecenSaat = gecenSure / 60;
                int GecenDakika = gecenSure % 60;



                lbl_tahmin.Text = TahminiSaat + " saat, " + TahminiDakika + " dakika";
                lbl_gecen.Text = GecenSaat + " saat, " + GecenDakika + " dakika";
            }
        }


    }
}
