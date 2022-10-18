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

namespace BezoekerApp.Paginas
{
    /// <summary>
    /// Interaction logic for BedrijfSelecteren.xaml
    /// </summary>
    public partial class BedrijfSelecteren : Page
    {
        public BedrijfSelecteren()
        {
            InitializeComponent();
            TerugKnopAanmeldScherm.ButtonClick += GaTerug;
            ListBoxBedrijven.Loaded += ListBoxBedrijven_Loaded;
            ListBoxContactpersonen.Loaded += ListBoxContactpersonen_Loaded;
            AanmeldKnop.ButtonClick += PersoonAanmelden;
        }
        private void PersoonAanmelden(object? sender, EventArgs e)
        {
            string bedrijf = ListBoxBedrijven.SelectedValue.ToString();
            string contactpersoon= ListBoxContactpersonen.SelectedValue.ToString();

            // doorsturen naar databank samen met klantgegevens voor de afspraak aan te maken
        }

        


        private void ListBoxBedrijven_Loaded(object sender, RoutedEventArgs e)
        {
           // inladen via databank

            ListBoxBedrijven.Items.Add("Bedrijf 1");
            ListBoxBedrijven.Items.Add("Bedrijf 2");
            ListBoxBedrijven.Items.Add("Bedrijf 3");
            ListBoxBedrijven.Items.Add("Bedrijf 4");
            

        }
        private void ListBoxContactpersonen_Loaded(object sender, RoutedEventArgs e)
        {
            // lijst inladen via databank op basis van string Bedrijf

            ListBoxContactpersonen.Items.Add("Contactpersoon 1");
            ListBoxContactpersonen.Items.Add("Contactpersoon 2");
            ListBoxContactpersonen.Items.Add("Contactpersoon 3");
            ListBoxContactpersonen.Items.Add("Contactpersoon 4");
            ListBoxContactpersonen.Items.Add("Contactpersoon 5");

        }

        private void GaTerug(object? sender, EventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
