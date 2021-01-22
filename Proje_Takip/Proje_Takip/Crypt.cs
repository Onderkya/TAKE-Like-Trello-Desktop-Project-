using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Proje_Takip
{
    public class Crypt
    {
        // girilen metni kriptolayıp geri gönderen metot
        public static string sifrele(string sifrelenecekmetin)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] dizi = Encoding.UTF8.GetBytes(sifrelenecekmetin);
            dizi = md5.ComputeHash(dizi);
            StringBuilder sifrelimetin = new StringBuilder();

            foreach (byte ba in dizi)
            {
                sifrelimetin.Append(ba.ToString("x2").ToLower());
            }

            return sifrelimetin.ToString();
        }
    }
}
