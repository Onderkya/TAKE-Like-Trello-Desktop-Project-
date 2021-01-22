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

        // from kapandığında uygulamayı sonlandıran metot
        private void AnaEkran_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

                
        // ana ekran yüklendiğinde kullanıcı adını ve projeleri listeleyen metot
        private void AnaEkran_Load(object sender, EventArgs e)
        {
            lbl_kullanici.Text = Baglan.Hesap.Ad+" "+Baglan.Hesap.Soyad;
            projeListele();

        }


        // giriş yapan kullanıcının projelerini listeleyen metot
        void projeListele()
        {
            list_projelerim.Items.Clear();
            projelerim = Baglan.Baglanti().projeListele();

            foreach (Proje item in projelerim)
            {
                list_projelerim.Items.Add(item.ProjeAdi);
            }

        }


        // yeni proje oluşturulması için yönlendirme yapan metot
        private void btn_yeniProje_Click(object sender, EventArgs e)
        {
            YeniProje yp = new YeniProje();
            yp.ShowDialog();
            projeListele();
        }


        // proje bilgilerini görüntülemek/güncellemek için yönlendirme yapan metot
        private void menu_goruntule_Click(object sender, EventArgs e)
        {
            int i = list_projelerim.SelectedIndex;
            YeniProje yp = new YeniProje(projelerim[i]);
            yp.ShowDialog();
            projeListele();
            list_projelerim.SelectedIndex = i;
        }


        // farklı proje seçimi yapıldığında projeye ait detay bilgilerini değiştiren metot
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
                        default: break;
                    }
                }
            }
            
        }


        // seçili projeye yeni görev eklenmesi için yönlendirme yapan metot
        private void menu_gorevEkle_Click(object sender, EventArgs e)
        {
            int i = list_projelerim.SelectedIndex;
            YeniGorev yg = new YeniGorev(projelerim[i]);
                       
            yg.ShowDialog();
            projeListele();

            list_projelerim.SelectedIndex = i;
        }


        // seçili projeye kişi atamaları yapılması için yönlendirme yapan metot
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
        //List_yapılacakların mouseDown'ına eklediğimiz mouse click eventlerini kontrol ediyoruz
        //sağ tıklama ile gorev'i görüntülüyoruz yani
        //o görevin detayını ve istersek alt görevi eklebiliyoruz.
        // sol tıklama ilede sürükle bırak eventini aktif hale getirip aktıralacak
        //Dosyası kopyalıyoruz bir nevi
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


        //DranEnter'da ise dosyayı kopyalamak için  surukle'i 0'a eşit olup
        //olmadığını kontrol etmemiz gerekiyor
        // eğer etmezsek 1.ci listbok olan yapılacaklardan direkt olarak
        //tamamlanan listbox'a  atılabilir bilgimiz
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


        // Burada ilk olarak nesneyi arıyoruz listbox içerisinde
        //eğer liste yoksa alttaki işlemleri yapıyoruz
        //eğer bunu yapmazsak program yanlış anlar ve dosyayı tekrardan
        //İçinde bulunduğumuz list_box'a atar
        private void list_yapiliyor_DragDrop(object sender, DragEventArgs e)
        {
            if (!list_yapiliyor.Items.Contains(e.Data.GetData(DataFormats.Text)))
            {
                list_yapiliyor.Items.Add(e.Data.GetData(DataFormats.Text));
                list_yapilacak.Items.Remove(e.Data.GetData(DataFormats.Text));
                Baglan.Baglanti().gorevDurumDegistir(projelerim[list_projelerim.SelectedIndex].Id, e.Data.GetData(DataFormats.Text).ToString(), 2);
            }
            
        }

        //Dragenter eventi başladıında surukleyi== 1 mi
        //Diye kontrol ediyoruz bunun sebebi
        //listyapılıyordan mı geliyor eğer gelirse işlem başarılı
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

        //burada yine yukarıdaki gibi kontrol ediyoruz
        //içinde taşıdğımız dosya varmı varsa eklemiyoruz
        private void list_tamamlanan_DragDrop(object sender, DragEventArgs e)
        {
            if (!list_tamamlanan.Items.Contains(e.Data.GetData(DataFormats.Text)))
            {
                list_tamamlanan.Items.Add(e.Data.GetData(DataFormats.Text));
                list_yapiliyor.Items.Remove(e.Data.GetData(DataFormats.Text));
                Baglan.Baglanti().gorevDurumDegistir(projelerim[list_projelerim.SelectedIndex].Id, e.Data.GetData(DataFormats.Text).ToString(), 3);
            }
            
        }

        //list mounse enter üstüne geldiğinde surukleyi otomatik 0 yap
        //ki diğer listboxlara doğru şekilde atabileleim
        private void list_yapilacak_MouseEnter(object sender, EventArgs e)
        {
            surukle = 0;
        }

        //aynı şekilde surukle nin 1 olması lazım yoksa listboxlar arası
        //veri taşımada yanlışlık olabilir
        private void list_yapiliyor_MouseEnter(object sender, EventArgs e)
        {
            surukle = 1;
        }

        //yukarıdaki yapılacaklardaki list mousedown ile aynı özelliklere sahip
        //sağ tıklama ile görev detayı
        //sol tıklama ile dragdrop'u aktif ediyoruz.
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

        // seçili görevin bilgilerini görüntüleme/güncelleme yapılması için yönlendirme yapan metot
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
