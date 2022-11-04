using Components.Models;
using Components.ViewModels;
using Controller;
using Controller.Interfaces;
using Controller.Interfaces.Models;
using Controller.Managers;
using Controller.Models;
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

        public EventHandler<Dictionary<string, Dictionary<string, string>>> AanmeldHandler;
        public BedrijfSelecteren(DomeinController domeinController)
        {
            _bedrijfManager = domeinController.GeefBedrijfManager();
            _werknemerManager = domeinController.GeefWerknemerManager();
            InitializeComponent();

            TerugKnopAanmeldScherm.ButtonClick += GaTerug;

            IReadOnlyList<Bedrijf> temp1 = _bedrijfManager.GeefAlleBedrijven();
            List<ILijstItem> bedrijfLijstItems = GeefBedrijfItems(temp1);
            //List<BedrijfViewModel> test = Omzetter.ZetBedrijvenOmInViewModellen(temp1);
            bedrijfComboBox.VoegLijstToe(bedrijfLijstItems);

            IReadOnlyList<Werknemer> temp2 = _werknemerManager.GeefAlleWerknemers();
            List<ILijstItem> werknemersLijstItems = GeefWerknemerItems(temp2);
            //List<WerknemerViewModel> test1 = Omzetter.ZetWerknemersOmInViewModellen(temp2);
            contactComboBox.VoegLijstToe(werknemersLijstItems);

            bedrijfComboBox.GeSelecteerd += BedrijfGeselecteerd;
            contactComboBox.GeSelecteerd += ContactPersoonGeselecteerd;

            //bedrijfComboBox.VoegLijstToe(bedrijven);
            //contactComboBox.GetListItemSelected();

            AanmeldKnop.ButtonClick += PersoonAanmelden;
        }

        private static List<ILijstItem> GeefWerknemerItems(IReadOnlyList<Werknemer> temp2)
        {
            List<WerknemerViewModel> werknemerViewModels = Omzetter.ZetWerknemersOmInViewModellen(temp2);
            List<ILijstItem> werknemersLijstItems = werknemerViewModels.Select(x => (ILijstItem)x).ToList();
            return werknemersLijstItems;
        }

        private static List<ILijstItem> GeefBedrijfItems(IReadOnlyList<Bedrijf> temp1)
        {
            List<BedrijfViewModel> bedrijfViewModels = Omzetter.ZetBedrijvenOmInViewModellen(temp1);
            List<ILijstItem> bedrijfLijstItems = bedrijfViewModels.Select(x => (ILijstItem)x).ToList();
            return bedrijfLijstItems;
        }

        private void PersoonAanmelden(object? sender, EventArgs e)
        {
            Dictionary<string, Dictionary<string, string>> dict = new Dictionary<string, Dictionary<string, string>>();
            dict.Add("bedrijf", new Dictionary<string, string>() {
                {"naam", bedrijfComboBox.SelectedLabel},
                {"value", bedrijfComboBox.SelectedValue }
            });
            dict.Add("contact-persoon", new Dictionary<string, string>() {
                {"naam", contactComboBox.SelectedLabel},
                {"value", contactComboBox.SelectedValue }
            });
              

            // TODO: checken of dit wel geldige gegevens zijn ? Of moet dit niet?
            // We zouden hier beter terug keren naar de Aanmeldpagina met de juist ingevulde gegevens en daar de bezoeker verder aanmelden
            AanmeldHandler.Invoke(sender, dict);
            // doorsturen naar databank samen met klantgegevens voor de afspraak aan te maken
        }

        private void BedrijfGeselecteerd(object? sender, string value)
        {
            IReadOnlyList<Werknemer> werknemers = _werknemerManager.GeefWerknemersOpEmailBedrijf(value);
            List <ILijstItem> werknemerLijstItems = GeefWerknemerItems(werknemers); 
            contactComboBox.VoegLijstToe(werknemerLijstItems);
        }

        private void ContactPersoonGeselecteerd(object? sender, string value)
        {
            IReadOnlyList<Bedrijf> bedrijven = _bedrijfManager.GeefBedrijvenOpEmailWerknemer(value);
            List<ILijstItem> bedrijfLijstItems = GeefBedrijfItems(bedrijven); 
            bedrijfComboBox.VoegLijstToe(bedrijfLijstItems);
        }
        private void GaTerug(object? sender, EventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
