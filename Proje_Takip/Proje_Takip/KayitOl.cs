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
    public partial class KayitOl : Form
    {
        public KayitOl()
        {
            InitializeComponent();
        }

        // kaydet butonuna basıldığında gerçekleşecek olan işlev
        private void btn_kayit_Click(object sender, EventArgs e)
        {
            bool kontrol = true;
            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    TextBox t = (TextBox)item;
                    if (String.IsNullOrEmpty(t.Text))
                    {
                        kontrol = false;
                        break;
                    }
                }
                
            }

            if (!kontrol)
            {
                MessageBox.Show("Lütfen boş alan bırakmayınız...");
            }
            else
            {
                if (txt_parola.Text.Trim() == txt_tekrar.Text.Trim())
                {
                    txt_ad.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(this.txt_ad.Text);
                    txt_soyad.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(this.txt_soyad.Text);
                    User u = new User();
                    u.Ad = txt_ad.Text.Trim();
                    u.Soyad = txt_soyad.Text.Trim();
                    u.KullaniciAdi = txt_kullanici.Text.Trim();
                    u.Parola = txt_parola.Text.Trim();
                    u.GuvenlikSorusu = txt_soru.Text.Trim();
                    u.GuvenlikCevabi = txt_cevap.Text.Trim();
                                        

                    if(Baglan.Baglanti().kayit(u))
                    {
                        MessageBox.Show("Kayıt işlemi başarılı...");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("İşlem başarısız. Lütfen bilgilerinizi kontrol ediniz...");
                    }
                        
                }
                else
                {
                    MessageBox.Show("Şifreler arası uyumsuzluk var...");
                }
                
            }
        }

        


    }
}
