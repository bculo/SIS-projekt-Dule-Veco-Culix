using SIS_projekt.Rsa;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SIS_projekt
{
    public class RSA
    {
        /// <summary>
        /// Kriptiraj tekst
        /// </summary>
        /// <param name="tekst"></param>
        /// <returns></returns>
        public static Byte[] KriptirajTekst(Byte[] tekst, string kljuc)
        {
            if (tekst == null || kljuc == null)
                return null;

            Byte[] kriptiraniTekstString = null;
            RSACryptoServiceProvider csp = new RSACryptoServiceProvider(StatickeVarijable.VELICINA_KLJUCA_RSA);

            try
            {
                csp.ImportParameters(PretvoriStringURSAParametar(kljuc));
                kriptiraniTekstString = csp.Encrypt(tekst, false);
            }
            catch (Exception e)
            {
                Debug.Print(new StringBuilder(StatickeVarijable.ERROR).Append(e.Message).ToString());
                return null;
            }

            return kriptiraniTekstString;
        }

        /// <summary>
        /// Dekriptiraj tekst
        /// </summary>
        /// <param name="tekst"></param>
        /// <param name="kljuc"></param>
        /// <returns></returns>
        public static Byte[] DekriptirajTekst(Byte[] tekst, string kljuc)
        {
            if (tekst == null || kljuc == null)
                return null;

            Byte[] cistiTekstBajtovi = null;
            RSACryptoServiceProvider csp = new RSACryptoServiceProvider(StatickeVarijable.VELICINA_KLJUCA_RSA);
            
            try
            {
                csp.ImportParameters(PretvoriStringURSAParametar(kljuc));
                cistiTekstBajtovi = csp.Decrypt(tekst, false);
            }
            catch (Exception e)
            {
                Debug.Print(new StringBuilder(StatickeVarijable.ERROR).Append(e.Message).ToString());
                return null;
            }

            return cistiTekstBajtovi;
        }

        /// <summary>
        /// Pretvaranje strina U RSAParametars
        /// </summary>
        /// <param name="kljuc"></param>
        /// <returns></returns>
        private static RSAParameters PretvoriStringURSAParametar(string kljuc)
        {
            StringReader sr = new StringReader(kljuc);
            var xs = new XmlSerializer(typeof(RSAParameters));
            return (RSAParameters)xs.Deserialize(sr);
        }

        /// <summary>
        /// Pretvaranje RSAPArametra u String
        /// </summary>
        /// <param name="rSAParameters"></param>
        /// <returns></returns>
        private static String PretvoriRSAParametarUString(RSAParameters rSAParameters)
        {
            StringWriter sw = new StringWriter();
            var xs = new XmlSerializer(typeof(RSAParameters));
            xs.Serialize(sw, rSAParameters);
            return sw.ToString();
        }

        /// <summary>
        /// Kreiraj par kljuceva (privatni i javni)
        /// </summary>
        /// <returns></returns>
        public static RSAPar KreirajParKljuceva()
        {
            RSACryptoServiceProvider csp = new RSACryptoServiceProvider(StatickeVarijable.VELICINA_KLJUCA_RSA);

            RSAParameters privatiK = csp.ExportParameters(true); //PRIVATNI
            RSAParameters javniK = csp.ExportParameters(false); //JAVNI

            return new RSAPar(PretvoriRSAParametarUString(privatiK), PretvoriRSAParametarUString(javniK));
        }

        /// <summary>
        /// Kriptiranje privatnim kljucem / POTPIS
        /// </summary>
        /// <param name="sadrzaj"></param>
        /// <returns></returns>
        public static Byte[] KriptirajPrivatnimKljucem(Byte[] sadrzaj)
        {
            RSACryptoServiceProvider csp = new RSACryptoServiceProvider(StatickeVarijable.VELICINA_KLJUCA_RSA);
            csp.ImportParameters(PretvoriStringURSAParametar(TrenutniKorisnik.Korisnik.PrivatniKljuc));
            Byte[] temp;

            try
            {
                temp = csp.SignHash(sadrzaj, CryptoConfig.MapNameToOID("SHA256"));
            }
            catch (Exception e)
            {
                Debug.Print(new StringBuilder(StatickeVarijable.ERROR).Append(e.Message).ToString());
                return null;
            }

            return temp;
        }

        /// <summary>
        /// Provjeri potpis
        /// </summary>
        /// <param name="sazetak"></param>
        /// <param name="potpisanSazetak"></param>
        /// <returns></returns>
        public static Boolean ProvjeriPotpis(Byte[] sazetak, Byte[] potpisanSazetak, String javniKljucPosiljatelja)
        {
            RSACryptoServiceProvider csp = new RSACryptoServiceProvider(StatickeVarijable.VELICINA_KLJUCA_RSA);
            csp.ImportParameters(PretvoriStringURSAParametar(javniKljucPosiljatelja));

            try
            {
                return csp.VerifyHash(sazetak, CryptoConfig.MapNameToOID("SHA256"), potpisanSazetak);
            }
            catch (Exception e)
            {
                Debug.Print(new StringBuilder(StatickeVarijable.ERROR).Append(e.Message).ToString());
                return false;
            }
        }

    }
}
