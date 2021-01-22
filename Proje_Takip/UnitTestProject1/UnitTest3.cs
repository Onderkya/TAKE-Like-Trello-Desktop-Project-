using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Proje_Takip;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest3
    {
        [TestMethod]
        public void TestMethod1()
        {
            KontrolElemani k = new KontrolElemani();

            k.Id = 100;

            k.AltBaslik = "kullanıcı yetki güncelleme";

            k.Durum = true;
        }
    }
}
