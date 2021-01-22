using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje_Takip
{
    public class KontrolElemani
    {
        private int _id;
        private string _altBaslik;
        private bool _durum;

        public int Id { get { return _id; } set { _id = value;} }
        public string AltBaslik { get { return _altBaslik; } set { _altBaslik = value;} }
        public bool Durum { get { return _durum; } set {_durum = value ;} }
    }
}
