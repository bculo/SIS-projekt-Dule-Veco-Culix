using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS_projekt.PocetniEkran
{
    /// <summary>
    /// Klasa za pamcenje podataka o korisniku
    /// </summary>
    public class Korisnik
    {
        public String KorisnickoIme { set; get; }
        public Byte[] TajniKljuc { set; get; } //AES
        public String PrivatniKljuc { set; get; } //RSA
        public String JavniKljuc { set; get; } //RSA
        public int Port { set; get; }

        public Korisnik(String ime, Byte[] tajni, String privatni, String javni, int port)
        {
            this.KorisnickoIme = ime;
            this.TajniKljuc = tajni;
            this.PrivatniKljuc = privatni;
            this.JavniKljuc = javni;
            this.Port = port;
        }

        public override string ToString() => KorisnickoIme + " - " + Port;
    }
}
