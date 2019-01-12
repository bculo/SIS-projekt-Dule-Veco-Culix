using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SIS_projekt.ApplicationControls
{
    public partial class SlanjePoruke : UserControl
    {
        private FirebaseKorisnik primateljPoruke;

        public SlanjePoruke(FirebaseKorisnik primatelj)
        {
            InitializeComponent();
            this.primateljPoruke = primatelj;
            PostaviKorisnickeInformacije();
        }

        /// <summary>
        /// Prikazi informacije o primatelju poruke na ekranu
        /// </summary>
        private void PostaviKorisnickeInformacije()
        {
            this.primateljInformacije.Text = "Korisnicko ime primatelja: " + this.primateljPoruke.KorisnickoIme;
        }

        /// <summary>
        /// Pozovi funkciju za slanje poruke putem socketa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void posaljiPoruku_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(this.unesiTekst.Text))
            {
                MessageBox.Show("Potrebno je popuniti sva polja");
                return;
            }

            Byte[] digitalniPecat = DigitalniPecat.KreirajDigitalniPecat(this.unesiTekst.Text, primateljPoruke.JavniKljuc);
            DodajUPoslanePoruke(this.unesiTekst.Text, digitalniPecat);
            Sockets.SlanjePoruke.PokreniSlanjePoruke(digitalniPecat, primateljPoruke.Port);
            ((ProzorSadrzaj)Window.GetWindow(this)).PromijeniPanel<PoslanePoruke>(PoslanePoruke.GetPoslanePoruke);
        }

        /// <summary>
        /// Dodaj u red poslanih poruka
        /// </summary>
        /// <param name="poruka"></param>
        /// <param name="pecat"></param>
        public void DodajUPoslanePoruke(String citkaPoruka, Byte[] pecat)
        {
            TrenutniKorisnik.PoslanePoruke.Add(new Poruka(primateljPoruke, pecat, citkaPoruka));
        }
    }
}
