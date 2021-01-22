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
    public partial class GirisEkrani : Form
    {
        public GirisEkrani()
        {
            InitializeComponent();
        }

        // kayıt ol butonuna tıklandığında gerçekleşecek olan işlev
        private void lbl_kayit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            KayitOl kayit = new KayitOl();
            kayit.ShowDialog();
        }


        // giriş butonuna basıldığında gerçekleşecek olan işlev
        private void btn_giris_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(txt_kullaniciAdi.Text.Trim()) && !String.IsNullOrEmpty(txt_parola.Text.Trim()))
            {
                if(Baglan.Baglanti().girisKontrol(txt_kullaniciAdi.Text.Trim(), txt_parola.Text.Trim()))
                {
                    AnaEkran ae = new AnaEkran();
                    this.Hide();
                    ae.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Kullanıcı Adı veya Parola hatalı. Lütfen tekrar deneyiniz...");
                }
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya parola boş geçilemez...");
            }
        }



    }
}
