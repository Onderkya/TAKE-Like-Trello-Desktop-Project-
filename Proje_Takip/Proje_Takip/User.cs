using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje_Takip
{
    public class User
    {
        public static User _girisYapanKullanici;


        private int _id;
        private string _ad;
        private string _soyad;
        private string _kullaniciAdi;
        private string _parola;
        private string _guvenlikSoru;
        private string _guvenlikCevap;


        public int Id { get { return _id; } set { _id = value; } }
        public string Ad { get { return _ad; } set { _ad = value; } }
        public string Soyad { get { return _soyad; } set { _soyad = value; } }
        public string KullaniciAdi { get { return _kullaniciAdi; } set { _kullaniciAdi = value; } }
        public string Parola { get { return _parola; } set { _parola = gizle(value); } }
        public string GuvenlikSorusu { get { return _guvenlikSoru; } set { _guvenlikSoru = value; } }
        public string GuvenlikCevabi { get { return _guvenlikCevap; } set { _guvenlikCevap = gizle(value); } }

        // kullanıcı parolasını kriptolayan metot
        private string gizle(string metin)
        {
            string gizlen;
            gizlen = Crypt.sifrele(metin);
            return gizlen;
        }


    }
}
