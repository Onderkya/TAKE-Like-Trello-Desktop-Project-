using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Proje_Takip;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethod1()
        {

            Proje p = new Proje();
            p.Id = 2;
            p.Musteri = "Myth Coffee";
            p.ProjeAdi = "Adisyon Yazılım Projesi";

        }
    }
}
