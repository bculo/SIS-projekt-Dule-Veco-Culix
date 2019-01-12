using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SIS_projekt
{
    public class SHA256
    {

        /// <summary>
        /// Izracunaj Hash na temelju proslijedenih bytova
        /// </summary>
        public static Byte[] IzracunajSazetak(Byte[] tekst)
        {
            Byte[] temp;

            try
            {
                using (SHA256Managed sha = new SHA256Managed())
                {
                    temp = sha.ComputeHash(tekst);
                }
                return temp;
            }
            catch (Exception e)
            {
                Debug.Print(new StringBuilder(StatickeVarijable.ERROR).Append(e.Message).ToString());
                return null;
            }
        }
    }
}
