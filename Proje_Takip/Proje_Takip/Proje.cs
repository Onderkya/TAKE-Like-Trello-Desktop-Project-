using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje_Takip
{
    public class Proje
    {
        private int _id;
        private string _projeAdi;
        private string _musteri;
        private string _aciklama;
        private List<User> _kisiler = new List<User>();
        private List<Gorev> _gorevler = new List<Gorev>();


        public int Id { get { return _id; } set { _id = value;} }
        public string ProjeAdi { get { return _projeAdi; } set { _projeAdi = value;} }
        public string Musteri { get { return _musteri; } set { _musteri = value;} }
        public string Aciklama { get { return _aciklama; } set { _aciklama = value;} }
        public List<User> Kisiler { get { return _kisiler; } set { _kisiler = value;} }
        public List<Gorev> Gorevler { get { return _gorevler; } set { _gorevler = value; } }
    }
}
