using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS_projekt
{
    public class DigitalniPecat
    {

        /// <summary>
        /// Kreiranje digitalnog pecata
        /// </summary>
        /// <param name="orginalTekst"></param>
        public static Byte[] KreirajDigitalniPecat(string orginalTekst, String javniKljucPrimateljaPoruke)
        {
            //C1 = AES(citkitekst, tajnikljuc)
            Byte[] simetricnoKriptiranjeTeksta = 
                AES.KriptirajTekst(orginalTekst, TrenutniKorisnik.Korisnik.TajniKljuc);

            //C2 = RSA(tajnikljuc, javni_kljuc_primatelja)
            Byte[] kriptiraniTajniKljuc = 
                RSA.KriptirajTekst(TrenutniKorisnik.Korisnik.TajniKljuc, javniKljucPrimateljaPoruke);

            //S = SHA256(C1, C2);
            Byte[] sazetakC1ConcatC2 = simetricnoKriptiranjeTeksta
                .Concat(kriptiraniTajniKljuc)
                .ToArray();

            Byte[] sazetak = SHA256.IzracunajSazetak(sazetakC1ConcatC2);

            //C3 = RSA(sazetak, vlastitiPrivatniKljuc)
            Byte[] kriptiraniSazetak = RSA.KriptirajPrivatnimKljucem(sazetak);
            
            //DigitalniPecat M = (c1, c2, c3)
            Byte[] digitalniPecat = simetricnoKriptiranjeTeksta
                .Concat(kriptiraniTajniKljuc)
                .Concat(kriptiraniSazetak)
                .ToArray();

            //Dodavanje firebase korisnika c4
            Byte[] posiljatelj = 
                Encoding.UTF8.GetBytes(TrenutniKorisnik.FirebaseKorisnik.KljucFirebase);

            //Konacna poruka P = (c1, c2, c3, c4)
            Byte[] poruka = simetricnoKriptiranjeTeksta
                .Concat(kriptiraniTajniKljuc)
                .Concat(kriptiraniSazetak)
                .Concat(posiljatelj)
                .ToArray();

            return poruka;
        }

        /// <summary>
        /// PROVJERA PECATA. Prvi element polja je dekriptirana poruka, a drugi element govori ime osobe koja je to poslala.
        /// U slucaju da se vrati null znaci da korisnik nije pronaden
        /// </summary>
        /// <param name="primljeniPodaci"></param>
        /// <returns></returns>
        public static String[] DekriptirajPoruku(Byte[] primljeniPodaci)
        {
            try
            {
                String[] rezultat = new String[2];
                int totalnaDuljinaPolja = primljeniPodaci.Length;

                // Dohvati firebase kljuc osobe koja je poslala poruku
                int skipanje = totalnaDuljinaPolja - (StatickeVarijable.POSILJATELJ / 8);
                Byte[] posiljatelj = primljeniPodaci.Skip(skipanje).Take(StatickeVarijable.VELICINA_KLJUCA_RSA / 8).ToArray(); 

                //Dohvaćane firebasekorisnik objekta na temelju kljuca
                String posiljateljString = Encoding.UTF8.GetString(posiljatelj);
                FirebaseKorisnik firebaseKorisnikPosiljatelj = TrenutniKorisnik.OnlineKorisnici
                    .First(item => item.KljucFirebase.Equals(posiljateljString));
                
                if (firebaseKorisnikPosiljatelj == null) 
                    return null;

                //Potpis (kriptirano privatnim kljucem osobe koja ja poslala poruku)
                skipanje = totalnaDuljinaPolja - ((StatickeVarijable.VELICINA_KLJUCA_RSA / 8) + (StatickeVarijable.POSILJATELJ / 8));
                Byte[] C3 = primljeniPodaci.Skip(skipanje).Take(StatickeVarijable.VELICINA_KLJUCA_RSA / 8).ToArray(); 

                //Kriptirani tajni kljuc
                skipanje = totalnaDuljinaPolja - ((StatickeVarijable.VELICINA_KLJUCA_RSA / 8) 
                    + (StatickeVarijable.VELICINA_KLJUCA_RSA / 8)
                    + (StatickeVarijable.POSILJATELJ / 8));
                Byte[] C2 = primljeniPodaci.Skip(skipanje).Take(StatickeVarijable.VELICINA_KLJUCA_RSA / 8).ToArray();

                //Kriptirani tekst simetricnim kljucem
                Byte[] C1 = primljeniPodaci.Take(skipanje).ToArray();

                //Dekriptiran simetricni kljuc
                Byte[] simetricniKljucDekriptiran = RSA.DekriptirajTekst(C2, TrenutniKorisnik.Korisnik.PrivatniKljuc);
                
                //orginal tekst
                rezultat[0] = $"Sadrzaj poruke: { AES.DekriptirajTekst(C1, simetricniKljucDekriptiran) }"; 

                //Racunamo sazetak
                Byte[] sazetakC1ConcatC2 = C1.Concat(C2).ToArray(); 
                Byte[] sazetak = SHA256.IzracunajSazetak(sazetakC1ConcatC2); 

                //Provjera potpisa
                if (RSA.ProvjeriPotpis(sazetak, C3, firebaseKorisnikPosiljatelj.JavniKljuc)) 
                    rezultat[1] = "Posalo korisnik: " + firebaseKorisnikPosiljatelj.KorisnickoIme;
                else
                    rezultat[1] = null;

                return rezultat;
            }
            catch(Exception e)
            {
                Debug.Print(new StringBuilder(StatickeVarijable.ERROR).Append(e.Message).ToString());
                return null;
            }
        }
    }
}
