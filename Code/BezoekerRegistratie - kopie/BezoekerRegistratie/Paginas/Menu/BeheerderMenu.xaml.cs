using BezoekerRegistratie.UI_Onderdelen;
using Controller;
using Controller.Interfaces;
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

namespace BezoekerRegistratie.Paginas
{
    /// <summary>
    /// Interaction logic for BeheerderMenu.xaml
    /// </summary>
    public partial class BeheerderMenu : Page
    {
        private BeheerController _beheerController;
        private CustomTable _table;
        
        public BeheerderMenu(BeheerController beheerController)
        {
            _beheerController = beheerController;
            InitializeComponent();
            _table = new CustomTable();
            terugKnop.ButtonClick += GaPaginaTerug;
        }

        private void GaPaginaTerug(object sender, EventArgs e)
        {
            NavigationService.GoBack();
        }

        private void zoekVeld_SelectionChanged(object sender, RoutedEventArgs e)
        {
            // Hier kan er gezocht worden op verschillende manieren aan de hand van welke checkbox
            // je hebt aangevinkt.


            List<Dictionary<string, string>> zoekLijst = new List<Dictionary<string, string>>();
            // Omdat bool begin met null waarde
            if ((zoekenOpWerknemer.IsChecked ?? false) )
            {
                //zoekLijst = _beheerController.GeefAlleWerknemers();
            }
            else if(zoekenOpBedrijf.IsChecked ?? false)
            {
                // zoekLijst = _beheerController.GeefAlleBedrijven();
            }
            else if(zoekenOpBezoeker.IsChecked ?? false)
            {
                zoekLijst = _beheerController.GeefAlleBezoekersNamen();
            }
            else if(zoekenOpDatum.IsChecked ?? false)
            {
                //zoekLijst = _beheerController.GeefAlleDatumsVanAfspraken();
            }
            else
            {
                // Er wordt op alles gezocht.
                //zoekLijst = _beheerController.GeefAlleData();
            }

            string zoekWoord = zoekVeld.Text;


            List<Dictionary<string, string>> zoekRezultaat = zoekLijst;
            if (zoekWoord != "")
            {
                zoekRezultaat = DynamishZoeken(zoekWoord, zoekLijst, "Voornaam");
            }

            List<object> tabelObjects = _beheerController.GeefAlleBezoekersInObjecten();

            _table.GenereerTable(tabelObjects);
            tablePanel.Children.Clear();
            tablePanel.Children.Add(_table);

            foreach (var r in zoekRezultaat)
            {
                Trace.WriteLine(r);
            }


        }

        private List<Dictionary<string, string>> DynamishZoeken(string? zoekWoord, 
            List<Dictionary<string, string>> zoekLijst, string zoekAttribut)
        {
            // Werking:
            // De zoeklijst is eigelijk een JSON-fromaat van de obecten die we willen doorgeven aan de Presentatie laag
            // vb: Bezoeker = { "Voornaam": "Tuur", "Achtenaam": "Van Holen", ... }
            // We kunnen op verschillende manieren zoeken aan de hand van het zoek attribut. 
            // Stel zoekAttribut = "Voornaam" dan zal er van die lijst alleen gezocht worden op voornaam.


            List<Dictionary<string, string>> result = new List<Dictionary<string, string>>();
            foreach (Dictionary<string, string> formaat in zoekLijst)
            {
                string woord = formaat[zoekAttribut];
                int matchedKarakters = 0;
                for (int i = 0; i < zoekWoord.Length; i++)
                {
                    if (i < woord.Length)
                    {
                        if (Char.ToLower(zoekWoord[i]) == Char.ToLower(woord[i]))
                        {
                            matchedKarakters++;
                        }
                        else
                        {
                            matchedKarakters = 0;
                        }
                    }
                    else
                    {
                        matchedKarakters = 0;
                    }
                }

                if (matchedKarakters > 0)
                {
                    result.Add(formaat);
                }
            }
            return result;
        }
    }
}
