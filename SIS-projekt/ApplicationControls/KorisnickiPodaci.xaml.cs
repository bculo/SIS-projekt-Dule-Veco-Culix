using System;
using System.Collections.Generic;
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
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace SIS_projekt.PocetniEkran
{

    public partial class KorisnickiPodaci : UserControl
    {
        private static KorisnickiPodaci instanca;

        public static KorisnickiPodaci GetKorisnickiPodaciControl
        {
            get
            {
                return instanca ?? (instanca = new KorisnickiPodaci());
            }
        }

        private KorisnickiPodaci()
        {
            InitializeComponent();
            UcitajPodatkeIzDatoteke();
        }

        /// <summary>
        /// Provjeri da li datoteka postoji
        /// </summary>
        private void UcitajPodatkeIzDatoteke()
        {
            if (!File.Exists(StatickeVarijable.KORISNICKIPODACI))
            {
                File.Create(StatickeVarijable.KORISNICKIPODACI);
                return;
            }

            PostaviKorisnickePodatke();
        }

        /// <summary>
        /// Procitaj podatke o trenutnom korisniku i zapisi u Trenutnog korisnika
        /// </summary>
        private void PostaviKorisnickePodatke()
        {
            try
            {
                string procitaniText = File.ReadAllText(StatickeVarijable.KORISNICKIPODACI);
                Korisnik korisnik = JsonConvert.DeserializeObject<Korisnik>(procitaniText);
                TrenutniKorisnik.Korisnik = korisnik;

                if (korisnik != null)
                {
                    this.korisnickoIme.Text = korisnik.KorisnickoIme;
                    this.korisnickoIme.IsEnabled = false;
                }
            }
            catch (Exception e)
            {
                Debug.Print(new StringBuilder(StatickeVarijable.ERROR).Append(e.Message).ToString());
            }
        }

        /// <summary>
        /// Provjera unosa kod porta (smiju biti samo brojevi)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void korisnickiPort_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        /// <summary>
        /// Provjeri unesene podatke
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dalje_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(this.korisnickoIme.Text) || String.IsNullOrEmpty(this.korisnickiPort.Text))
            {
                MessageBox.Show("Potrebno je unijeti sve podatke");
                return;
            }

            if (TrenutniKorisnik.Korisnik == null)
                UnesiNovePodatke();
            else
            {
                TrenutniKorisnik.Korisnik.Port = int.Parse(this.korisnickiPort.Text);
                OtvoriNoviProzor();
            }
        }

        /// <summary>
        /// Unesi podatke u JSON datoteku
        /// </summary>
        private void UnesiNovePodatke()
        {
            Rsa.RSAPar par = RSA.KreirajParKljuceva();
            TrenutniKorisnik.Korisnik = new Korisnik(this.korisnickoIme.Text, AES.KreirajKljuc(), par.Privatni, par.Javni, int.Parse(this.korisnickiPort.Text));

            try
            {
                File.WriteAllText(StatickeVarijable.KORISNICKIPODACI, JsonConvert.SerializeObject(TrenutniKorisnik.Korisnik, Formatting.Indented));
            }
            catch (Exception ex)
            {
                Debug.Print(new StringBuilder(StatickeVarijable.ERROR).Append(ex.Message).ToString());
            }

            OtvoriNoviProzor();
        }

        /// <summary>
        /// Otvori novi prozor
        /// </summary>
        private void OtvoriNoviProzor()
        {
            try
            {
                ((MainWindow)Window.GetWindow(this)).OtvoriNoviProzor<ProzorSadrzaj>(new ProzorSadrzaj());
            }
            catch (Exception ex)
            {
                Debug.Print(new StringBuilder(StatickeVarijable.ERROR).Append(ex.Message).ToString());
            }
        }
    }
}
