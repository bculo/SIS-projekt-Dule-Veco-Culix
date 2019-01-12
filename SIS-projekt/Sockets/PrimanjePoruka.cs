using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SIS_projekt.Sockets
{
    public class PrimanjePoruka
    {
        public Socket socket;

        /// <summary>
        /// Pokretanje taska za primanje poruke
        /// </summary>
        public PrimanjePoruka()
        {
            Task.Run(() => CekajNaPoruku());
        }

        /// <summary>
        /// Cekanje na poruku
        /// </summary>
        public void CekajNaPoruku()
        {
            if (!KreirajSocket())
                return;

            while (true)
            {
                Socket cekaj = socket.Accept();
                Task.Run(() => CitanjePoruke(cekaj));
            }
        }

        /// <summary>
        /// Citanje poruke
        /// </summary>
        /// <param name="citanje"></param>
        public void CitanjePoruke(Socket citanje)
        {
            try
            {
                Byte[] citanjeBajtova = new Byte[1024];
                Byte[] primljenaPoruka = null;

                while (true)
                {
                    int bajtovaPrimljeno = citanje.Receive(citanjeBajtova);

                    if (bajtovaPrimljeno == 0)
                        break;

                    if (primljenaPoruka == null)
                    {
                        primljenaPoruka = new Byte[bajtovaPrimljeno];
                        Array.Copy(citanjeBajtova, primljenaPoruka, bajtovaPrimljeno);
                    }
                    else
                        primljenaPoruka = primljenaPoruka.Concat(citanjeBajtova.Take(bajtovaPrimljeno).ToArray()).ToArray();

                    if (bajtovaPrimljeno < 1024)
                        break;
                }

                citanje.Send(Encoding.UTF8.GetBytes(StatickeVarijable.PORUKA_PRIMLJENA));
                citanje.Close();

                if (primljenaPoruka != null)
                    TrenutniKorisnik.PrimljenePoruke.Add(primljenaPoruka);
            }
            catch(Exception e)
            {
                Debug.Print(new StringBuilder(StatickeVarijable.ERROR).Append(e.Message).ToString());
            }
        }

        /// <summary>
        /// Kreiraj socket
        /// </summary>
        /// <returns></returns>
        public Boolean KreirajSocket()
        {
            try
            {
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPAddress aresa = IPAddress.Parse(StatickeVarijable.LOCALHOST);
                IPEndPoint remoteEP = new IPEndPoint(aresa, TrenutniKorisnik.Korisnik.Port);
                socket.Bind(remoteEP);
                socket.Listen(StatickeVarijable.BROJ_PRIMATELJA);
                return true;
            }
            catch(SocketException e)
            {
                Debug.Print(new StringBuilder(StatickeVarijable.ERROR).Append(e.Message).ToString());
                return false;
            }
        }
    }
}
