using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Proje_Takip;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Gorev g = new Gorev();

            g.Id = 1;

            g.Baslik = "Kullanıcı Giriş Paneli";

            g.Aciklama = "kullanıcı ve yetklilerin giriş " +

                "yapabileceği kullanıcı adı ve şifre istenen modül";

            g.Gorevli = 1;
        }
    }
}
