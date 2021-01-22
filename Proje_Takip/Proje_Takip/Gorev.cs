using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje_Takip
{
    public class Gorev
    {
        private int _id;
        private string _baslik;
        private string _aciklama;
        private int _gorevliID;
        private List<KontrolElemani> _kontrolListesi = new List<KontrolElemani>();

        public int Id { get { return _id; } set { _id = value;} }
        public string Baslik { get { return _baslik; } set { _baslik = value ;} }
        public string Aciklama { get { return _aciklama; } set { _aciklama = value;} }
        public int Gorevli { get { return _gorevliID; } set { _gorevliID = value;} }
        public List<KontrolElemani> KontrolList { get { return _kontrolListesi; } set { _kontrolListesi = value;} }

    }
}
