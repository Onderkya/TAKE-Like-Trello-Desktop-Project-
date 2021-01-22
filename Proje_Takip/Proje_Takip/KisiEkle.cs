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
    public partial class KisiEkle : Form
    {
        public KisiEkle(Proje proje)
        {
            _proje = proje;
            InitializeComponent();
        }
        
        private Proje _proje;

        List<string> kullanicilar = new List<string>();
        
        private void KisiEkle_Load(object sender, EventArgs e)
        {
            txt_projeAdi.Text = _proje.ProjeAdi;
            txt_projeid.Text = _proje.Id.ToString();


            kisiAra();

            foreach (User item in _proje.Kisiler)
            {
                list_gorevliKisiler.Items.Add(item.KullaniciAdi+" - ("+item.Ad + " " + item.Soyad + ")");
            }
        }

        private void txt_ara_EditValueChanged(object sender, EventArgs e)
        {
            kisiAra();                 
        }

        void kisiAra()
        {
            list_tumKisiler.Items.Clear();
            foreach (User item in Baglan.Baglanti().kisiAra(txt_ara.Text.Trim(), _proje.Id))
            {
                list_tumKisiler.Items.Add(item.KullaniciAdi + " - (" + item.Ad + " " + item.Soyad + ")");
            }
        }


        #region KİŞİLERİ AKTAR
        private void list_tumKisiler_MouseDown(object sender, MouseEventArgs e)
        {
            list_gorevliKisiler.DoDragDrop(list_tumKisiler.SelectedItem.ToString(), DragDropEffects.Copy);
        }

        private void list_gorevliKisiler_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void list_gorevliKisiler_DragDrop(object sender, DragEventArgs e)
        {
            if (!list_gorevliKisiler.Items.Contains(e.Data.GetData(DataFormats.Text)))
            {
                list_gorevliKisiler.Items.Add(e.Data.GetData(DataFormats.Text));
                list_tumKisiler.Items.Remove(e.Data.GetData(DataFormats.Text));
            }
                
            
        }

        private void list_gorevliKisiler_MouseDown(object sender, MouseEventArgs e)
        {
            list_tumKisiler.DoDragDrop(list_gorevliKisiler.SelectedItem.ToString(), DragDropEffects.Copy);
        }

        private void list_tumKisiler_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void list_tumKisiler_DragDrop(object sender, DragEventArgs e)
        {
            if(!list_tumKisiler.Items.Contains(e.Data.GetData(DataFormats.Text)))
            {
                list_tumKisiler.Items.Add(e.Data.GetData(DataFormats.Text));
                list_gorevliKisiler.Items.Remove(e.Data.GetData(DataFormats.Text));
            }
                           
        }

        #endregion

        private void btn_kaydet_Click(object sender, EventArgs e)
        {            
            if(list_gorevliKisiler.Items.Count>0)
            {
                foreach (string item in list_gorevliKisiler.Items)
                {
                    kullanicilar.Add(item.Substring(0, item.IndexOf("-")).Trim());
                }

                Baglan.Baglanti().goreveKisiEkle(kullanicilar, _proje.Id);
                this.Close();
            }
            else
            {
                MessageBox.Show("Projede en az 1 kişinin bulunması gereklidir...");
            }

            
        }






    }
}
