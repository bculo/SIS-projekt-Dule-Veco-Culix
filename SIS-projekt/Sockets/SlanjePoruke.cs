using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SIS_projekt.Sockets
{
    public class SlanjePoruke
    {
        /// <summary>
        /// Pocni slati poruku na drugoj dretvi
        /// </summary>
        /// <param name="digitalniPecat"></param>
        /// <param name="port"></param>
        public static void PokreniSlanjePoruke(byte[] digitalniPecat, int port)
        {
            Task.Run(() => PosaljiPoruku(digitalniPecat, port));
        }

        /// <summary>
        /// Kreiranje socketa i slanje poruke putem socketa
        /// </summary>
        /// <param name="digitalniPecat"></param>
        private static void PosaljiPoruku(byte[] digitalniPecat, int port)
        {
            try
            {
                Socket soc = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPAddress adresa = IPAddress.Parse(StatickeVarijable.LOCALHOST);
                IPEndPoint remoteEP = new IPEndPoint(adresa, port);
                soc.Connect(remoteEP);
                soc.Send(digitalniPecat);
                byte[] odgovor = new byte[128];
                int primljeno = soc.Receive(odgovor);
                soc.Close();
            }
            catch (Exception e)
            {
                Debug.Print(new StringBuilder(StatickeVarijable.ERROR).Append(e.Message).ToString());
            }
        }
    }
}
