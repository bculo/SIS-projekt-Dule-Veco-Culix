using SIS_projekt.ApplicationControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace SIS_projekt
{
    public partial class ProzorSadrzaj : Window
    {
        private Sockets.PrimanjePoruka poruke;
        private DispatcherTimer timer;

        public ProzorSadrzaj()
        {
            InitializeComponent();
            PostaviKorisnickePodatke();
            poruke = new Sockets.PrimanjePoruka();
            PostaviTimer();
        }

        /// <summary>
        /// Postavljanje i pokretanje timera
        /// </summary>
        public void PostaviTimer()
        {
            timer = new DispatcherTimer();
            timer.Tick += dispatcherTimer_Tick;
            timer.Interval = new TimeSpan(0, 0, 5);
            timer.Start();
        }

        /// <summary>
        /// Prikazi broj poruka svakih 5 sekundi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {            
            this.primljeniPoruke.Content = $"PRIMLJENE PORUKE {TrenutniKorisnik.PrimljenePoruke.Count}";
        }

        /// <summary>
        /// Zapisi na izbornik podatke o korisniku i na firebejs
        /// </summary>
        private async void PostaviKorisnickePodatke()
        {
            this.informacijeKorisnik.Text = TrenutniKorisnik.Korisnik.ToString();

            if (!await FireBaseV2.GetFireBase2.OznaciAktivnostNaFireBejsu()) {
                ObrisiAktivnostNaFirebejsu();
                this.Close();
            }

            PromijeniPanel<OnlineKorisnici>(OnlineKorisnici.GetOnlineKorisniciKontrola);
        }

        /// <summary>
        /// Promijena panela
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="control"></param>
        public void PromijeniPanel<T>(T control) where T : UserControl
        {
            this.paneliIzmjena.Content = control;
        }

        /// <summary>
        /// Zatvaranje prozora
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ObrisiAktivnostNaFirebejsu();
        }

        /// <summary>
        /// Brisanje aktivnosti na firebejsu i ciscenje statickih varijabli
        /// </summary>
        private async void ObrisiAktivnostNaFirebejsu()
        {
            while (TrenutniKorisnik.PrimljenePoruke.Count > 0)
                TrenutniKorisnik.PrimljenePoruke.Take();

            TrenutniKorisnik.PoslanePoruke.Clear();
            TrenutniKorisnik.OnlineKorisnici.Clear();
            timer.Stop();
            poruke.ZatvoriSocket();

            await FireBaseV2.GetFireBase2.ObrisiAktinostNaFireBejsu();
        }

        /// <summary>
        /// Odjava korisnika
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void odjava_Click(object sender, RoutedEventArgs e)
        {
            ObrisiAktivnostNaFirebejsu();
            this.Close();
        }

        /// <summary>
        /// Otvori panel onlina korisnika
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void onlineKorisnici_Click(object sender, RoutedEventArgs e)
        {
            PromijeniPanel<OnlineKorisnici>(OnlineKorisnici.GetOnlineKorisniciKontrola);
        }

        /// <summary>
        /// Prikazi poslane poruke
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void poslanePoruke_Click(object sender, RoutedEventArgs e)
        {
            PromijeniPanel<PoslanePoruke>(PoslanePoruke.GetPoslanePoruke);
        }

        /// <summary>
        /// Prikaz primljenih poruka
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void primljeniPoruke_Click(object sender, RoutedEventArgs e)
        {
            PromijeniPanel<PrikazPrimljenihPoruka>(new PrikazPrimljenihPoruka(new ObservableCollection<byte[]>(TrenutniKorisnik.PrimljenePoruke)));
        }
    }
}
