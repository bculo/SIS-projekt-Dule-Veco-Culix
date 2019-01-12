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

namespace SIS_projekt.ApplicationControls
{
    public partial class PoslanePoruke : UserControl
    {
        private static PoslanePoruke instanca;

        public static PoslanePoruke GetPoslanePoruke
        {
            get
            {
                return instanca ?? (instanca = new PoslanePoruke());
            }
        }

        private PoslanePoruke()
        {
            InitializeComponent();
            this.bindanje.ItemsSource = TrenutniKorisnik.PoslanePoruke;
        }
    }
}
