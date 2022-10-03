using BezoekerRegistratie.UI_Onderdelen;
using BezoekerRegistratie.Windows;
using Controller;
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

namespace BezoekerRegistratie.Paginas
{
    /// <summary>
    /// Interaction logic for RegistreerBezoekerPagina.xaml
    /// </summary>
    public partial class RegistreerBezoekerPagina : Page
    {
        BezoekerController _bezoekerController;
        private bool alleWaardeZijnIngevuld = false;
        private string maakNieuwBedrijfString = "Maak een nieuw bedrijf";
        public RegistreerBezoekerPagina(BezoekerController bezoekerController)
        {
            _bezoekerController = bezoekerController;
            InitializeComponent();

            registreerBezoeker.ButtonClick += RegistreerBezoeker;
            InitBedrijfComboBox();
            

        }

        private void InitBedrijfComboBox()
        {
            
            List<string> bedrijven = _bezoekerController.GeefAlleBedrijfsNamen();
            bedrijfComboBox.InitItems(bedrijven);
            
        }

      

        private void RegistreerBezoeker(object? sender, EventArgs e)
        {
            //TODO: controle alle waarden moeten ingevuld zijn. + bericht terug geven als het gelukt is
            string vn = voornaam.Text;
            string an = achternaam.Text;
            
            string em = email.Text;
            string num = nummerplaat.Text;
            string be = "";

            bool gelukt = _bezoekerController.RegistreerBezoeker(vn, an, em, be, num);
        }

        private void bedrijfComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(e.AddedItems[0] == maakNieuwBedrijfString)
            {
                VoegBedrijfToeWindow voegBedrijfToeWindow = new VoegBedrijfToeWindow(_bezoekerController);
                voegBedrijfToeWindow.Show();
                InitBedrijfComboBox();

            }
        }
    }
}
