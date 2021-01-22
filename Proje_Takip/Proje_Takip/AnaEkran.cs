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
    public partial class AnaEkran : Form
    {
        public AnaEkran()
        {
            InitializeComponent();
        }

        List<Proje> projelerim = new List<Proje>();


        private void AnaEkran_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

                

        private void AnaEkran_Load(object sender, EventArgs e)
        {
            lbl_kullanici.Text = Baglan.Hesap.Ad+" "+Baglan.Hesap.Soyad;
            projeListele();

        }

        void projeListele()
        {
            list_projelerim.Items.Clear();
            projelerim = Baglan.Baglanti().projeListele();

            foreach (Proje item in projelerim)
            {
                list_projelerim.Items.Add(item.ProjeAdi);
            }

        }



        private void btn_yeniProje_Click(object sender, EventArgs e)
        {
            YeniProje yp = new YeniProje();
            yp.ShowDialog();
            projeListele();
        }



        private void menu_goruntule_Click(object sender, EventArgs e)
        {
            int i = list_projelerim.SelectedIndex;
            YeniProje yp = new YeniProje(projelerim[i]);
            yp.ShowDialog();
            projeListele();
            list_projelerim.SelectedIndex = i;
        }



        private void list_projelerim_SelectedIndexChanged(object sender, EventArgs e)
        {
            list_yapilacak.Items.Clear();
            list_yapiliyor.Items.Clear();
            list_tamamlanan.Items.Clear();
            lbl_projeAdi.Text = list_projelerim.SelectedItem.ToString();

            if (list_projelerim.SelectedItem !=null)
            {
                
            int i = list_projelerim.SelectedIndex;
            foreach (Gorev item in projelerim[i].Gorevler)
            {
                int durum = Baglan.Baglanti().gorevDurumOgren(item.Id);
                switch (durum)
                {
                    case 1: list_yapilacak.Items.Add(item.Baslik); break;
                    case 2: list_yapiliyor.Items.Add(item.Baslik); break;
                    case 3: list_tamamlanan.Items.Add(item.Baslik); break;
                    default:
                        break;
                }
            }

            }
            
        }



        private void menu_gorevEkle_Click(object sender, EventArgs e)
        {
            int i = list_projelerim.SelectedIndex;
            YeniGorev yg = new YeniGorev(projelerim[i]);
                       
            yg.ShowDialog();
            projeListele();

            list_projelerim.SelectedIndex = i;
        }


        private void menu_kisiDuzenle_Click(object sender, EventArgs e)
        {
            int i = list_projelerim.SelectedIndex;
            KisiEkle ke = new KisiEkle(projelerim[i]);
            ke.ShowDialog();
            projeListele();
            list_projelerim.SelectedIndex = i;
        }

        #region SÜRÜKLE BIRAK
        int surukle = 0;

        private void list_yapilacak_MouseDown(object sender, MouseEventArgs e)
        {
            if (list_yapilacak.SelectedItem != null)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    gorevGoruntule(list_yapilacak.SelectedItem.ToString());
                }
                else if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    list_yapiliyor.DoDragDrop(list_yapilacak.SelectedItem.ToString(), DragDropEffects.Copy);
                }
            }
        }
    
               		 
	    
        private void list_yapiliyor_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text) && surukle==0 )
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
        
    

        private void list_yapiliyor_DragDrop(object sender, DragEventArgs e)
        {
            if (!list_yapiliyor.Items.Contains(e.Data.GetData(DataFormats.Text)))
            {
                list_yapiliyor.Items.Add(e.Data.GetData(DataFormats.Text));
                list_yapilacak.Items.Remove(e.Data.GetData(DataFormats.Text));
                Baglan.Baglanti().gorevDurumDegistir(projelerim[list_projelerim.SelectedIndex].Id, e.Data.GetData(DataFormats.Text).ToString(), 2);
            }
            
        }
    

        private void list_tamamlanan_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text)&& surukle==1)
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void list_tamamlanan_DragDrop(object sender, DragEventArgs e)
        {
            if (!list_tamamlanan.Items.Contains(e.Data.GetData(DataFormats.Text)))
            {
                list_tamamlanan.Items.Add(e.Data.GetData(DataFormats.Text));
                list_yapiliyor.Items.Remove(e.Data.GetData(DataFormats.Text));
                Baglan.Baglanti().gorevDurumDegistir(projelerim[list_projelerim.SelectedIndex].Id, e.Data.GetData(DataFormats.Text).ToString(), 3);
            }
            
        }

        private void list_yapilacak_MouseEnter(object sender, EventArgs e)
        {
            surukle = 0;
        }

        private void list_yapiliyor_MouseEnter(object sender, EventArgs e)
        {
            surukle = 1;
        }

        private void list_yapiliyor_MouseDown(object sender, MouseEventArgs e)
        {
            if (list_yapiliyor.SelectedItem != null)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    gorevGoruntule(list_yapiliyor.SelectedItem.ToString(), 2);
                }
                else if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    list_tamamlanan.DoDragDrop(list_yapiliyor.SelectedItem.ToString(), DragDropEffects.Copy);
                }
            }
        }


        #endregion

        

        private void gorevGoruntule(string baslik, int durum = 1)
        {
            int i = list_projelerim.SelectedIndex;
            Gorev gr = Baglan.Baglanti().gorevIdOgren(projelerim[i].Id, baslik);
            YeniGorev yg = new YeniGorev(projelerim[i], gr);
            yg.durum = durum;
            yg.ShowDialog();
            projeListele();

            list_projelerim.SelectedIndex = i;
        }

        

        private void list_tamamlanan_MouseDown(object sender, MouseEventArgs e)
        {
            if (list_tamamlanan.SelectedItem != null)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    gorevGoruntule(list_tamamlanan.SelectedItem.ToString(), 3);
                }
            }
        }

        
           

    }
}
