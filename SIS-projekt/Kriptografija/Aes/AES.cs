using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SIS_projekt
{
    public class AES
    {
        /// <summary>
        /// Kriptiraj tekst i vrati polje byteova
        /// </summary>
        /// <returns></returns>
        public static Byte[] KriptirajTekst(String tekst, Byte[] kljuc, Byte[] vektor = null)
        {
            if (tekst == null || kljuc == null)
                return null;

            byte[] kriptiraniTekst = null;

            try
            {
                using (Aes aes = Aes.Create())
                {
                    aes.Mode = CipherMode.CBC;
                    byte[] temp = vektor ?? aes.IV;
                    ICryptoTransform encryptor = aes.CreateEncryptor(kljuc, temp);

                    using (MemoryStream msEncrypt = new MemoryStream())
                    {
                        msEncrypt.Write(temp, 0, StatickeVarijable.AES_LENGTH_BYTE);
                        using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        {
                            using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                            {
                                swEncrypt.Write(tekst.Trim());
                            }
                            kriptiraniTekst = msEncrypt.ToArray();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Debug.Print(new StringBuilder(StatickeVarijable.ERROR).Append(e.Message).ToString());
                return null;
            }

            return kriptiraniTekst;
        }

        /// <summary>
        /// Vraca objekt gdje je prvi parametar vektor(byte[]) a drugi dekriptirani tekst(String)
        /// </summary>
        /// <param name="poruka"></param>
        /// <param name="kljuc"></param>
        /// <returns>Vraca objekt gdje je prvi element polja vektor(byte[]) a drugi dekriptirani tekst(String)</returns>
        public static String DekriptirajTekst(Byte[] poruka, Byte[] kljuc)
        {
            if (poruka == null || kljuc == null)
                return null;

            String dekriptiraniTekst = String.Empty;

            try
            {
                using (Aes aesAlg = Aes.Create())
                {
                    aesAlg.Mode = CipherMode.CBC;
                    using (MemoryStream msDecrypt = new MemoryStream(poruka))
                    {
                        byte[] IV = new byte[16];
                        msDecrypt.Read(IV, 0, StatickeVarijable.AES_LENGTH_BYTE);
                        ICryptoTransform decryptor = aesAlg.CreateDecryptor(kljuc, IV);
                        using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                            {
                                dekriptiraniTekst = srDecrypt.ReadToEnd();
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Debug.Print(new StringBuilder(StatickeVarijable.ERROR).Append(e.Message).ToString());
                return null;
            }

            return dekriptiraniTekst;
        }

        /// <summary>
        /// Kreiraj kljuc
        /// </summary>
        /// <returns></returns>
        public static Byte[] KreirajKljuc()
        {
            Byte[] kljuc = null;

            try
            {
                using (Aes aesAlg = Aes.Create())
                {
                    kljuc = aesAlg.Key;
                }
            }
            catch (Exception e)
            {
                Debug.Print(new StringBuilder(StatickeVarijable.ERROR).Append(e.Message).ToString());
                return null;
            }

            return kljuc;
        }
    }
}
