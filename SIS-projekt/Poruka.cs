using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS_projekt
{
    public class Poruka
    {
        public FirebaseKorisnik FireBaseKorisnik { get; set; }
        public Byte[] DigitalniPecat { get; set; }
        public String CitkaPoruka { get; set; }

        public Poruka(FirebaseKorisnik korisnik, Byte[] pecat, String poruka)
        {
            this.FireBaseKorisnik = korisnik;
            this.DigitalniPecat = pecat;
            this.CitkaPoruka = poruka;
        }
    }
}
