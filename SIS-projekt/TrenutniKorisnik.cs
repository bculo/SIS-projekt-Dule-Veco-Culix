using SIS_projekt.PocetniEkran;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS_projekt
{
    public class TrenutniKorisnik
    {
        public static Korisnik Korisnik { set; get; }
        public static FirebaseKorisnik FirebaseKorisnik { set; get; }
        public static ObservableCollection<FirebaseKorisnik> OnlineKorisnici { set; get; }

        public static BlockingCollection<Byte[]> PrimljenePoruke { set; get; } = new BlockingCollection<byte[]>();
        public static ObservableCollection<Poruka> PoslanePoruke { set; get; } = new ObservableCollection<Poruka>();
    }
}
