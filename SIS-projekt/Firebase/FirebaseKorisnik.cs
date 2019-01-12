using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SIS_projekt
{
    public class FirebaseKorisnik
    {
        public String KljucFirebase { get; set; }
        public String KorisnickoIme { get; set; }
        public int Port { get; set; }
        public String JavniKljuc { get; set; }

        public FirebaseKorisnik()
        {

        }

        public FirebaseKorisnik(String ime, int port, String kljuc)
        {
            this.KorisnickoIme = ime;
            this.Port = port;
            this.JavniKljuc = kljuc;
        }

        public FirebaseKorisnik(String kljucFirebase, String ime, int port, String kljuc)
        {
            this.KljucFirebase = kljuc;
            this.KorisnickoIme = ime;
            this.Port = port;
            this.JavniKljuc = kljuc;
        }
    }
}
