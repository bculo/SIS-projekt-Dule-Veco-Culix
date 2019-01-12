using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SIS_projekt.ApplicationControls
{
    public partial class OnlineKorisnici : UserControl
    {
        private static OnlineKorisnici instanca;

        public static OnlineKorisnici GetOnlineKorisniciKontrola
        {
            get
            {
                return instanca ?? (instanca = new OnlineKorisnici());
            }
        }

        private OnlineKorisnici()
        {
            InitializeComponent();
            DohvatiAktivneKorisnike();
        }

        /// <summary>
        /// Dohvacanje korisnika s firebejsa
        /// </summary>
        public async void DohvatiAktivneKorisnike()
        {
            TrenutniKorisnik.OnlineKorisnici = await FireBaseV2.GetFireBase2.DohvatiAktivneKorisnike();
            this.bindanje.ItemsSource = TrenutniKorisnik.OnlineKorisnici;
        }

        /// <summary>
        /// Protisnut je gumb OSVJEZI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void osvjezi_Click(object sender, RoutedEventArgs e)
        {
            DohvatiAktivneKorisnike();
        }

        /// <summary>
        /// Odabran korisnik
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bindanje_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try {
                var odabraniKorisnik = (sender as ListView).SelectedItem;
                if (odabraniKorisnik != null)
                {
                    ((ProzorSadrzaj)Window.GetWindow(this))
                        .PromijeniPanel<ApplicationControls.SlanjePoruke>(new SlanjePoruke(odabraniKorisnik as FirebaseKorisnik));
                }
            }
            catch (Exception ex)
            {
                Debug.Print(new StringBuilder(StatickeVarijable.ERROR).Append(ex.Message).ToString());
            }
        }
    }
}
