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
    public partial class PrikazPrimljenihPoruka : UserControl
    {
        public PrikazPrimljenihPoruka(ObservableCollection<byte[]> observableCollection)
        {
            InitializeComponent();
            this.bindanje.ItemsSource = observableCollection;
        }

        /// <summary>
        /// Provjera primljene poruke
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bindanje_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var odabranaPoruka = (byte[])(sender as ListView).SelectedItem;
                if (odabranaPoruka != null)
                {
                    String[] rezultat = DigitalniPecat.DekriptirajPoruku(odabranaPoruka);

                    if (rezultat == null)
                        MessageBox.Show("Došlo je do pogreške!!!");

                    if (rezultat[1] == null)
                        MessageBox.Show("Poruka je modificirana");
                    else
                        MessageBox.Show($"{rezultat[1]}\n{rezultat[0]}");
                }
            }
            catch (Exception ex)
            {
                Debug.Print(new StringBuilder(StatickeVarijable.ERROR).Append(ex.Message).ToString());
            }
        }
    }
}
