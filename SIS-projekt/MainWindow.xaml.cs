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

namespace SIS_projekt
{
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Kontruktor koji poziva kontorlu KorisniciPodaci.xml koji se nalazi u ApplicationControlsFolderu
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            PromijeniPanel<PocetniEkran.KorisnickiPodaci>(PocetniEkran.KorisnickiPodaci.GetKorisnickiPodaciControl);
        }

        /// <summary>
        /// Promijena kontrole na prozoru
        /// </summary>
        /// <param name="control"></param>
        public void PromijeniPanel<T>(T control) where T : UserControl
        {
            this.userKontrole.Content = control;
        }

        /// <summary>
        /// Otvaranje novog prozora
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="window"></param>
        public void OtvoriNoviProzor<T>(T window) where T : Window, new()
        {
            this.Hide();
            window.ShowDialog();
            this.Show();
        }
    }
}
