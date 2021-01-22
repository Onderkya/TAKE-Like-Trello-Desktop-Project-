using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Proje_Takip
{
    public class Baglan
    {
        private static Baglan _baglan;

        public static User Hesap;

        // SERVER DB BAĞLANTILI CONNECTİONSTRİNG
        //SqlConnection bag = new SqlConnection(@"Data Source=DESKTOP-TP0F9QD\SQLEXPRESS;Initial Catalog=projeTakip;Integrated Security=True");

        // LOCAL DB BAĞLANTILI CONNECTİONSTRİNG (İLKAY)
        SqlConnection bag = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\projeTakip.mdf;Integrated Security=True;Connect Timeout=30");

        // LOCAL DB BAĞLANTILI CONNECTİONSTRİNG (ÖNDER)
        //SqlConnection bag = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\bin\Debug\projeTakip.mdf;Integrated Security=True;Connect Timeout=30");


        // Singleton tasarım deseni mantığı kullanıldığından örnek yaratılmaması için kurucu metot private yapılmıştır
        private Baglan()
        {
            //
        }

        
        // Tek nesne mantığından dolayı Baglan tipindeki nesne örneği static oluşturulmuştur
        public static Baglan Baglanti()
        {
            if (_baglan == null) 
                _baglan = new Baglan();  
            return _baglan;    
        }


        // Baglantının açık olup olmadığını kontol eden metot
        void baglantiKontrol()
        {
            if (bag.State == System.Data.ConnectionState.Closed) 
                bag.Open();
        }


        #region KAYIT
        // Yeni kullanıcı yakıt işlemini yapan metot
        public bool kayit(User kullanici)
        {
            bool onay = false;

            if(tekrarKayitKontrol(kullanici.KullaniciAdi))
            {
                baglantiKontrol();
                SqlCommand cmd = new SqlCommand("insert into tbl_kullanici (kullaniciAdi,ad,soyad,parola,guvenlikSorusu,guvenlikCevap) values (@kullanici,@ad,@soyad,@parola,@soru,@cevap)", bag);
                cmd.Parameters.AddWithValue("@kullanici", kullanici.KullaniciAdi);
                cmd.Parameters.AddWithValue("@ad", kullanici.Ad);
                cmd.Parameters.AddWithValue("@soyad", kullanici.Soyad);
                cmd.Parameters.AddWithValue("@parola", kullanici.Parola);
                cmd.Parameters.AddWithValue("@soru", kullanici.GuvenlikSorusu);
                cmd.Parameters.AddWithValue("@cevap", kullanici.GuvenlikCevabi);
                cmd.ExecuteNonQuery();
                bag.Close();
                onay = true;
            }
            return onay;
        }


        // Girilen kullanıcı adnın tekrar girilmesini engelleyen kontrol edici metot
        private bool tekrarKayitKontrol(string kullanciAdi)
        {
            bool onay = true;
            baglantiKontrol();
            SqlCommand cmd = new SqlCommand("select * from tbl_kullanici where kullaniciAdi=@ka", bag);
            cmd.Parameters.AddWithValue("@ka", kullanciAdi);
            SqlDataReader dr = cmd.ExecuteReader();
            if(dr.Read())
            {
                onay = false;
            }
            bag.Close();
            return onay;
        }
        #endregion


        #region GİRİŞ
        // kullanıcı adı ve şifrenin doğruluğunu kontrol eden metot
        public bool girisKontrol(string kullaniciAdi, string parola)
        {
            bool onay = false;
            baglantiKontrol();
            SqlCommand cmd = new SqlCommand("select * from tbl_kullanici where kullaniciAdi=@ka and parola=@parola", bag);
            cmd.Parameters.AddWithValue("@ka", kullaniciAdi);
            cmd.Parameters.AddWithValue("@parola", Crypt.sifrele(parola));
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                onay = true;
                giris(Convert.ToInt16(dr["ID"]), dr["ad"].ToString(), dr["soyad"].ToString(), dr["kullaniciAdi"].ToString());
            }
            bag.Close();
            return onay;
        }


        // girişi yapıldığında kullanıcı bilgilerini static nesneye aktaran metot
        private void giris(int id, string ad, string soyad, string kullanici)
        {
            if (Hesap == null)
                Hesap = new User();
            Hesap.Id = id;
            Hesap.Ad = ad;
            Hesap.Soyad = soyad;
            Hesap.KullaniciAdi = kullanici;
        }
        #endregion


        #region PROJE
        // yeni proje oluşturulan metot
        public void yeniProje(Proje yeniProje)
        {
            baglantiKontrol();
            SqlCommand cmd = new SqlCommand("insert into tbl_proje (projeAdi, musteri, aciklama) values (@proje, @musteri, @aciklama)", bag);
            cmd.Parameters.AddWithValue("@proje", yeniProje.ProjeAdi);
            cmd.Parameters.AddWithValue("@musteri", yeniProje.Musteri);
            cmd.Parameters.AddWithValue("@aciklama", yeniProje.Aciklama);
            cmd.ExecuteNonQuery();
            bag.Close();

            baglantiKontrol();
            cmd = new SqlCommand("select IDENT_CURRENT('tbl_proje')", bag);
            SqlDataReader dr2 = cmd.ExecuteReader();
            if(dr2.Read())
                yeniProje.Id = Convert.ToInt32(dr2[0]);
            bag.Close();

            baglantiKontrol();
            cmd = new SqlCommand("insert into tbl_projeKisi (projeId, kullaniciId) values (@projeId, @kullaniciId)", bag);
            cmd.Parameters.AddWithValue("@projeId", yeniProje.Id);
            cmd.Parameters.AddWithValue("@kullaniciId", Hesap.Id);
            cmd.ExecuteNonQuery();
            bag.Close();
        }


        // mevcut proje bilgilerini güncelleyen metot
        public void projeDuzenle(Proje mevcutProje)
        {
            baglantiKontrol();
            SqlCommand cmd = new SqlCommand("update tbl_proje set projeAdi=@projeAdi, musteri=@musteri, aciklama=@aciklama where ID=@id", bag);
            cmd.Parameters.AddWithValue("@projeAdi", mevcutProje.ProjeAdi);
            cmd.Parameters.AddWithValue("@musteri", mevcutProje.Musteri);
            cmd.Parameters.AddWithValue("@aciklama", mevcutProje.Aciklama);
            cmd.Parameters.AddWithValue("@id", mevcutProje.Id);
            cmd.ExecuteNonQuery();
            bag.Close();
        }


        // giriş yapana kullanıcın dahil olduğu projeleri liste içine alan metot
        public List<Proje> projeListele()
        {
            List<Proje> projelerim = new List<Proje>();
            baglantiKontrol();
            SqlCommand cmd = new SqlCommand("select tbl_proje.ID, tbl_proje.projeAdi, tbl_proje.musteri, tbl_proje.aciklama from tbl_proje inner join tbl_projeKisi on tbl_proje.ID=tbl_projeKisi.projeId where kullaniciId = @kullaniciId order by tbl_proje.ID", bag);
            cmd.Parameters.AddWithValue("@kullaniciId", Hesap.Id);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Proje p = new Proje();
                p.Id = Convert.ToInt32(dr["ID"]);
                p.ProjeAdi = dr["projeAdi"].ToString();
                p.Musteri = dr["musteri"].ToString();
                p.Aciklama = dr["aciklama"].ToString();
                projelerim.Add(p);
            }
            bag.Close();

            int i = 0;
            foreach (Proje item in projelerim)
            {
                baglantiKontrol();
                cmd = new SqlCommand("select * from tbl_projeKisi inner join tbl_kullanici on tbl_projeKisi.kullaniciID = tbl_kullanici.ID where projeId = @pr1", bag);
                cmd.Parameters.AddWithValue("@pr1", item.Id);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    User u = new User();
                    u.Id = Convert.ToInt16(dr["kullaniciID"]);
                    u.Ad = dr["ad"].ToString();
                    u.Soyad = dr["soyad"].ToString();
                    u.KullaniciAdi = dr["kullaniciAdi"].ToString();
                    projelerim[i].Kisiler.Add(u);
                }
                bag.Close();

                baglantiKontrol();
                cmd = new SqlCommand("select * from tbl_gorev where projeID = @pr2", bag);
                cmd.Parameters.AddWithValue("@pr2", item.Id);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Gorev g = new Gorev();
                    g.Id = Convert.ToInt32(dr["ID"]);
                    g.Baslik = dr["gorevBaslik"].ToString();
                    g.Gorevli = Convert.ToInt32(dr["gorevliID"]);
                    g.Aciklama = dr["aciklama"].ToString();
                    projelerim[i].Gorevler.Add(g);
                }
                bag.Close();
                i++;
            }
            return projelerim;
        }


        // projeye kişi eklemek için tüm kullanıcılar içinde girilen aramayı yapan metot
        public List<User> kisiAra(string aranan, int projeId)
        {
            List<User> k = new List<User>();
            baglantiKontrol();
            SqlCommand cmd = new SqlCommand("select * from tbl_kullanici where ID not in (select kullaniciId from tbl_projeKisi where projeId = @prId) and (ad like '%" + aranan + "%' or soyad like '%" + aranan + "%' or kullaniciAdi like '%" + aranan + "%')", bag);
            cmd.Parameters.AddWithValue("@prId", projeId);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                User u = new User();
                u.Id = Convert.ToInt16(dr["ID"]);
                u.Ad = dr["ad"].ToString();
                u.Soyad = dr["soyad"].ToString();
                u.KullaniciAdi = dr["kullaniciAdi"].ToString();
                k.Add(u);
            }
            bag.Close();
            return k;
        }

        #endregion


        #region GÖREV
        // yeni görev girişi yapan metot
        public bool gorevEkle(Gorev gorevEkle, int projeId)
        {
            bool onay = false;
            if (tekrarKayitKontrol(projeId, gorevEkle.Baslik))
            {
                baglantiKontrol();
                SqlCommand cmd = new SqlCommand("insert into tbl_gorev (projeId, gorevBaslik, gorevliId, aciklama) values (@prId, @bslk, @grvli, @ack)", bag);
                cmd.Parameters.AddWithValue("@prId", projeId);
                cmd.Parameters.AddWithValue("@bslk", gorevEkle.Baslik);
                cmd.Parameters.AddWithValue("@grvli", gorevEkle.Gorevli);
                cmd.Parameters.AddWithValue("@ack", gorevEkle.Aciklama);
                cmd.ExecuteNonQuery();
                bag.Close();

                int gorevID = 0;
                baglantiKontrol();
                cmd = new SqlCommand("select IDENT_CURRENT('tbl_gorev')", bag);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    gorevID = Convert.ToInt32(dr[0]);
                }
                bag.Close();

                baglantiKontrol();
                cmd = new SqlCommand("insert into tbl_gorevHareketleri (gorevID, durumID, kullaniciID, tarih) values (@gr, @dr, @ka, @tr)", bag);
                cmd.Parameters.AddWithValue("@gr", gorevID);
                cmd.Parameters.AddWithValue("@dr", 1);
                cmd.Parameters.AddWithValue("@ka", Hesap.Id);
                cmd.Parameters.AddWithValue("@tr", DateTime.Now);
                cmd.ExecuteNonQuery();
                bag.Close();

                foreach (KontrolElemani item in gorevEkle.KontrolList)
                {
                    kontrolListesiGuncelle(item, gorevID);
                }

                onay = true;
            }
            return onay;
        }


        // mevcut görevin bilgilerini günelleyen metot
        public bool gorevDuzenle(Gorev gorevGuncelle, int projeId)
        {
            bool onay = false;
            if (tekrarKayitKontrol(projeId, gorevGuncelle.Baslik, false, gorevGuncelle.Id))
            {
                baglantiKontrol();
                SqlCommand cmd = new SqlCommand("update tbl_gorev set gorevBaslik = @bslk, gorevliID = @grvli, aciklama=@ack where ID = @grId", bag);
                cmd.Parameters.AddWithValue("@grId", gorevGuncelle.Id);
                cmd.Parameters.AddWithValue("@bslk", gorevGuncelle.Baslik);
                cmd.Parameters.AddWithValue("@grvli", gorevGuncelle.Gorevli);
                cmd.Parameters.AddWithValue("@ack", gorevGuncelle.Aciklama);
                cmd.ExecuteNonQuery();
                bag.Close();

                baglantiKontrol();
                cmd = new SqlCommand("delete from tbl_kontrolListesi where gorevID = @grId", bag);
                cmd.Parameters.AddWithValue("@grId", gorevGuncelle.Id);
                cmd.ExecuteNonQuery();
                bag.Close();

                foreach (KontrolElemani item in gorevGuncelle.KontrolList)
                {
                    kontrolListesiGuncelle(item, gorevGuncelle.Id);
                }
                onay = true;
            }
            return onay;
        }


        // girilen görev başlığının aynı projede varolup olmadığını kontrolü yapan metot
        private bool tekrarKayitKontrol(int projeId, string baslik, bool yeni = true, int gorevId = 0)
        {
            bool onay = true;
            string sorgu = "";
            baglantiKontrol();
            if (yeni)
                sorgu = "select * from tbl_gorev where projeId = @pr and gorevBaslik = @gb";
            else
                sorgu = "select * from tbl_gorev where projeId = @pr and gorevBaslik = @gb and ID <> @grId";
            SqlCommand cmd = new SqlCommand(sorgu, bag);
            cmd.Parameters.AddWithValue("@grId", gorevId);
            cmd.Parameters.AddWithValue("@pr", projeId);
            cmd.Parameters.AddWithValue("gb", baslik);
            SqlDataReader dr = cmd.ExecuteReader();
            if(dr.Read())
            {
                onay = false;
            }
            bag.Close();
            return onay;
        }


        // göreve sorumlu kullanıcı ataması yapan metot
        public void goreveKisiEkle(List<string> kisiler, int projeid)
        {
            baglantiKontrol();
            SqlCommand cmd = new SqlCommand("delete from tbl_projeKisi where projeId = @pr", bag);
            cmd.Parameters.AddWithValue("@pr", projeid);
            cmd.ExecuteNonQuery();
            bag.Close();
            
            List<int> gorevliId = new List<int>();            
            
            foreach (string item in kisiler)
            {
                baglantiKontrol();
                cmd = new SqlCommand("select ID from tbl_kullanici where kullaniciAdi = @ka", bag);
                cmd.Parameters.AddWithValue("@ka", item);
                SqlDataReader dr = cmd.ExecuteReader();
                if(dr.Read())
                {
                    gorevliId.Add(Convert.ToInt16(dr[0]));
                }
                bag.Close();
            }
            
            
            foreach (int item in gorevliId)
            {
                baglantiKontrol();
                cmd = new SqlCommand("insert into tbl_projeKisi (projeId, kullaniciId) values (@pr, @kl)", bag);
                cmd.Parameters.AddWithValue("@pr", projeid);
                cmd.Parameters.AddWithValue("@kl", item);
                cmd.ExecuteNonQuery();
                bag.Close();
            }
        }


        // görevin durumunu öğrenen metot
        public int gorevDurumOgren(int gorevID)
        {
            int durum = 0;
            baglantiKontrol();
            SqlCommand cmd = new SqlCommand("select top 1 * from tbl_gorevHareketleri where gorevID = @gr order by ID desc", bag);
            cmd.Parameters.AddWithValue("@gr", gorevID);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                durum = Convert.ToInt32(dr["durumID"]);
            }
            bag.Close();
            return durum;
        }


        // görev bilgilerininin atamasını yapan metot
        public Gorev gorevIdOgren(int projeId, string baslik)
        {
            Gorev gr = new Gorev();
            baglantiKontrol();
            SqlCommand cmd = new SqlCommand("select * from tbl_gorev where projeId = @pr and gorevBaslik = @bs", bag);
            cmd.Parameters.AddWithValue("@pr", projeId);
            cmd.Parameters.AddWithValue("@bs", baslik);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                gr.Id = Convert.ToInt32(dr["ID"]);
                gr.Baslik = dr["gorevBaslik"].ToString();
                gr.Gorevli = Convert.ToInt32(dr["gorevliID"]);
                gr.Aciklama = dr["aciklama"].ToString();
            }
            bag.Close();

            baglantiKontrol();
            cmd = new SqlCommand("select * from tbl_kontrolListesi where gorevID = @gr", bag);
            cmd.Parameters.AddWithValue("@gr", gr.Id);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                KontrolElemani ke = new KontrolElemani();
                ke.Id = Convert.ToInt32(dr["ID"]);
                ke.AltBaslik = dr["altBaslik"].ToString();
                ke.Durum = Convert.ToBoolean(dr["durum"]);
                gr.KontrolList.Add(ke);
            }
            bag.Close();
            return gr;
        }


        // görevin durumunu güncelleyen metot
        public void gorevDurumDegistir(int projeId, string baslik, int durum)
        {
            Gorev g = new Gorev();
            g = gorevIdOgren(projeId, baslik);

            baglantiKontrol();
            SqlCommand cmd = new SqlCommand("insert into tbl_gorevHareketleri (gorevID, durumID, kullaniciID, tarih) values (@gr, @dr, @ka, @tr)", bag);
            cmd.Parameters.AddWithValue("@gr", g.Id);
            cmd.Parameters.AddWithValue("@dr", durum);
            cmd.Parameters.AddWithValue("@ka", Hesap.Id);
            cmd.Parameters.AddWithValue("@tr", DateTime.Now);
            cmd.ExecuteNonQuery();
            bag.Close();

            if (durum != 0)
            {
                baglantiKontrol();
                string sorgu = "";
                if (durum == 2)
                    sorgu = "update tbl_gorev set baslama = @tr where ID = @gr";
                else if (durum == 3)
                    sorgu = "update tbl_gorev set bitirme = @tr where ID = @gr";
                cmd = new SqlCommand(sorgu, bag);
                cmd.Parameters.AddWithValue("@gr", g.Id);
                cmd.Parameters.AddWithValue("@tr", DateTime.Now);
                cmd.ExecuteNonQuery();
                bag.Close();
            }
        }


        // görev hareketlerini listeleyen metot
        public DataTable gorevHareketleri(int gorevId)
        {
            DataTable dt = new DataTable();
            baglantiKontrol();
            SqlDataAdapter da = new SqlDataAdapter("select tarih [TARİH], durumAdi [DURUM], ad+' '+soyad [İŞLEM YAPAN] from tbl_gorevHareketleri inner join tbl_kullanici on tbl_gorevHareketleri.kullaniciID=tbl_kullanici.ID inner join tbl_durumlar on tbl_gorevHareketleri.durumID=tbl_durumlar.ID where gorevID = @gr", bag);
            da.SelectCommand.Parameters.AddWithValue("@gr", gorevId);
            da.Fill(dt);
            return dt;
        }


        // göreve kontrol elemanı ekleyen metot
        public void kontrolListesiGuncelle(KontrolElemani kontolElemani, int gorevId)
        {            
            baglantiKontrol();
            SqlCommand cmd = new SqlCommand("insert into tbl_kontrolListesi (gorevID, altBaslik, durum) values (@gr, @ab, @dr)", bag);
            cmd.Parameters.AddWithValue("@gr", gorevId);
            cmd.Parameters.AddWithValue("@ab", kontolElemani.AltBaslik);
            cmd.Parameters.AddWithValue("@dr", kontolElemani.Durum);
            cmd.ExecuteNonQuery();
            bag.Close();
        }
        #endregion

        
        #region SÜRE HESAPLAMA
        // seçili kişinin görev bitirme ortalamasını hesaplayan metot
        public int KisiOrtalamasi(int UserId)
        {
            int ortalamaSure = 0;
            baglantiKontrol();
            SqlCommand cmd = new SqlCommand("select avg(DATEdiff(MINUTE, baslama, bitirme)) from tbl_gorev where bitirme is not null and gorevliID = @gr group by gorevliID", bag);
            cmd.Parameters.AddWithValue("@gr", UserId);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                ortalamaSure = Convert.ToInt16(dr[0]);
            }
            bag.Close();
            return ortalamaSure;
        }
        

        // seçili görevin ne kadar süre yapılıyorda kaldığını hesaplayan metot
        public int GecenSure(int gorevId, int durum = 1)
        {
            baglantiKontrol();
            SqlCommand cmd = new SqlCommand("select top 1 durumId from tbl_gorevHareketleri where gorevId = @gid order by tarih desc", bag);
            cmd.Parameters.AddWithValue("@gid", gorevId);
            SqlDataReader dr2 = cmd.ExecuteReader();
            if (dr2.Read())
            {
                durum = Convert.ToInt16(dr2[0]);
            }
            bag.Close();

            int gecenSure = 0;            
            if (durum > 1)
            {
                string sorgu = "";
                baglantiKontrol();
                if (durum == 3)
                    sorgu = "select DATEDIFF(MINUTE, baslama, bitirme) from tbl_gorev where ID = @id";
                else if (durum == 2)
                    sorgu = "select datediff(minute, baslama, getdate()) from tbl_gorev where ID = @id";
                cmd = new SqlCommand(sorgu, bag);
                cmd.Parameters.AddWithValue("@id", gorevId);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    gecenSure = Convert.ToInt16(dr[0]);
                }

                bag.Close();
            }            
            return gecenSure;
        }

        #endregion
                
    }
}
