using Controller;
using Controller.Interfaces.Models;
using Controller.Managers;
using Controllers;
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
        
        BedrijfManager _bedrijfManager;
        WerknemerManager _werknemerManager;

        public EventHandler<Dictionary<string, string>> AanmeldHandler;
        public BedrijfSelecteren(DomeinController domeinController)
        {
            _bedrijfManager = domeinController.GeefBedrijfManager();
            _werknemerManager = domeinController.GeefWerknemerManager();
            InitializeComponent();

            TerugKnopAanmeldScherm.ButtonClick += GaTerug;
            List<IBedrijf> bedrijven = _bedrijfManager.GeefAlleBedrijven();
            List<IWerknemer> werknemers = _werknemerManager.GeefAlleWerknemers();
            
            bedrijfComboBox.VoegLijstToe(bedrijven.Select(x => x.ToString()).ToList());
            contactComboBox.VoegLijstToe(werknemers.Select(x => x.ToString()).ToList());

            AanmeldKnop.ButtonClick += PersoonAanmelden;
        }
        private void PersoonAanmelden(object? sender, EventArgs e)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("bedrijf", bedrijfComboBox.searchText);
            dict.Add("contact-persoon", contactComboBox.searchText);

            // TODO: checken of dit wel geldige gegevens zijn ? Of moet dit niet?
            // We zouden hier beter terug keren naar de Aanmeldpagina met de juist ingevulde gegevens en daar de bezoeker verder aanmelden
            AanmeldHandler.Invoke(sender, dict);
            // doorsturen naar databank samen met klantgegevens voor de afspraak aan te maken
        }

        private void GaTerug(object? sender, EventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
