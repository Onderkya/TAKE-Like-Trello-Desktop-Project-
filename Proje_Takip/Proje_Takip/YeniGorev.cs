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
    public partial class YeniGorev : Form
    {
        public YeniGorev(Proje proje)
        {
            _proje = proje;
            InitializeComponent();
            kisiler();
        }

        public YeniGorev(Proje proje, Gorev gorev)
        {
            _proje = proje;
            _gorev = gorev;
            InitializeComponent();
            kisiler();

            txt_baslik.Text = _gorev.Baslik;
            txt_aciklama.Text = _gorev.Aciklama;

            int i =0;
            foreach (User item in _proje.Kisiler)
            {
                if(item.Id == _gorev.Gorevli)
                {
                    cmb_gorevli.SelectedIndex = i;
                    break;
                }
                i++;
            }
            dataGridView1.DataSource = Baglan.Baglanti().gorevHareketleri(_gorev.Id);
        }
        
        private Proje _proje;
        private Gorev _gorev;
        private List<KontrolElemani> geciciListe = new List<KontrolElemani>();
        public int durum = 1;


        // from yüklendiğinde gerçekleşecek olan işlev
        private void YeniGorev_Load(object sender, EventArgs e)
        {
            txt_projeid.Text = _proje.Id.ToString();
            txt_projeAdi.Text = _proje.ProjeAdi;
            kontrolListesi();
            
            if (_gorev != null)
            {
                txt_tahmini.Text =  Baglan.Baglanti().KisiOrtalamasi(_gorev.Gorevli) + " dakika";
                
                if (durum == 3)
                {
                    txt_durum.Text = "Tamamlandı"; 
                    btn_kaydet.Enabled = false;
                    cmb_gorevli.Enabled = false;
                    btn_ekle.Enabled = false;
                    txt_baslik.Enabled = false;
                    txt_aciklama.Enabled = false;
                    panel1.Enabled = false;
                }
                else if (durum == 2)
                {
                    txt_durum.Text = "Devam Ediyor";
                }
                else
                {
                    txt_durum.Text = "Yapılacak";
                }
                txt_tamamlanan.Text = Baglan.Baglanti().GecenSure(_gorev.Id, durum) + " dakika";   
            }
        }


        // comboboz a kullanıcıları yazdıran metot
        private void kisiler()
        {
            foreach (User item in _proje.Kisiler)
            {
                cmb_gorevli.Properties.Items.Add(item.Ad + " " + item.Soyad + " - (" + item.KullaniciAdi + ")");
            }
        }



        // kaydet butonuna basıldığında gerçekleşecek olan işlev
        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(txt_baslik.Text) && !String.IsNullOrEmpty(txt_aciklama.Text) && cmb_gorevli.SelectedIndex >= 0)
            {
                if (_gorev == null)
                {
                    Gorev gr = new Gorev();
                    gr.Baslik = System.Threading.Thread.CurrentThread.CurrentUICulture.TextInfo.ToTitleCase(txt_baslik.Text);
                    gr.Aciklama = txt_aciklama.Text.Trim();
                    gr.Gorevli = _proje.Kisiler[cmb_gorevli.SelectedIndex].Id;
                    gr.KontrolList = geciciListe;

                    if (Baglan.Baglanti().gorevEkle(gr, _proje.Id))
                    {
                        MessageBox.Show("Görev eklendi...");

                        txt_baslik.Text = null;
                        txt_aciklama.Text = null;
                        cmb_gorevli.SelectedItem = null;
                        panel1.Controls.Clear();
                        geciciListe.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Bu başlık tekrar kullanılamaz...");
                    }
                }
                else
                {
                    _gorev.Baslik = System.Threading.Thread.CurrentThread.CurrentUICulture.TextInfo.ToTitleCase(txt_baslik.Text);
                    _gorev.Aciklama = txt_aciklama.Text.Trim();
                    _gorev.Gorevli = _proje.Kisiler[cmb_gorevli.SelectedIndex].Id;
                    if(Baglan.Baglanti().gorevDuzenle(_gorev, _proje.Id))
                    {
                        MessageBox.Show("Görev bilgileri güncellendi...");
                        this.Close();
                    }                        
                }                
            }
            else
            {
                MessageBox.Show("Lütfen boş alanları doldurunuz...");
            }
        }


        // ekle butona basıldığında gerçekleşecek olan işlev
        private void btn_ekle_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txt_kontList.Text))
            {   KontrolElemani ke = new KontrolElemani();
                ke.AltBaslik = txt_kontList.Text.Trim();
                ke.Durum = false;
                if (_gorev == null)
                    geciciListe.Add(ke);
                else
                    _gorev.KontrolList.Add(ke);
                kontrolListesi();
                txt_kontList.Text = null;
            }
            else {
                MessageBox.Show("Alt Başlık Giriniz");
            }       
        }


        // panel içerisine göreve ait kontrol elemanlarını ekleyen metot
        private void kontrolListesi()
        {
            if(_gorev != null)
                geciciListe = _gorev.KontrolList;

            panel1.Controls.Clear();

            int top = 25;
            int left = 25;
            foreach (KontrolElemani item in geciciListe)
            {
                CheckBox cb = new CheckBox();
                cb.AutoSize = true;
                cb.Top = top;
                cb.Left = left;
                cb.Checked = item.Durum;
                cb.Text = item.AltBaslik;
                cb.CheckedChanged += cb_CheckedChanged;
                panel1.Controls.Add(cb);
                top += 40;
            }
        }


        // kontrol elemanın cheched özelliği değiştiğinde gerçekleşecek olan işlev
        void cb_CheckedChanged(object sender, EventArgs e)
        {
            int i = 0;
            foreach (CheckBox item in panel1.Controls)
            {
                geciciListe[i].Durum = item.Checked;
                if (_gorev != null)
                    _gorev.KontrolList[i].Durum = item.Checked;
                i++;
            }
        }


        // görevli combox ı değiştiğinde gerçekleşecek olan işlev
        private void cmb_gorevli_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmb_gorevli.SelectedIndex >= 0)
                txt_tahmini.Text = Baglan.Baglanti().KisiOrtalamasi(_proje.Kisiler[cmb_gorevli.SelectedIndex].Id) + " dakika";
        }

       


    }
}
