using BezoekerRegistratie.Models;
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

namespace BezoekerRegistratie.Paginas.Forms
{


    /// <summary>
    /// Interaction logic for MaakAfspraakPagina.xaml
    /// </summary>
    public partial class MaakAfspraakPagina : Page
    {

        private BezoekerController _bezoekerController;

        public MaakAfspraakPagina(BezoekerController bezoekerController)
        {
            _bezoekerController = bezoekerController;
            InitializeComponent();
            InitComboboxes();

            maakAfspraak.ButtonClick += MaakAfspraak;
            terugKnop.ButtonClick += GaPaginaTerug;
        }

        private void GaPaginaTerug(object? sender, EventArgs e)
        {
            NavigationService.GoBack();
        }

        private void MaakAfspraak(object? sender, EventArgs e)
        {
            // TODO: Controle op lege velden!
            string vn = voornaam.Text;
            string an = achternaam.Text;
            string datum = datePicker.Text;
            string bedrijf = bedrijfComboBox.comboBox.Text;
            string contactPersoon = contactPersoonComboBox.comboBox.Text;
            DateTime oDate = DateTime.ParseExact(datum, "yyyy-MM-dd HH:mm tt", null);

            bool gelukt = _bezoekerController.MaakNieuweAfspraak(vn, an, oDate, bedrijf, contactPersoon, "");

            string bericht = "";
            if (gelukt)
            {
                bericht = "gelukt";
            }
            else
            {
                bericht = "niet gelukt";
            }

            MessageBox.Show(bericht, "/", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        private void InitComboboxes()
        {
            List<string> bedrijfItems = _bezoekerController.GeefAlleBedrijfsNamen();
            bedrijfComboBox.InitItems(bedrijfItems);

            List<string> contactPersoonItems = _bezoekerController.GeefAlleContactPersonen();
            contactPersoonComboBox.InitItems(contactPersoonItems);
        }

        private void bedrijfComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


        //private void contactPersoon_PreviewTextInput_1(object sender, TextCompositionEventArgs e)
        //{
        //    contactPersoonComboBox.IsDropDownOpen = true;
        //}

        
    }
}
