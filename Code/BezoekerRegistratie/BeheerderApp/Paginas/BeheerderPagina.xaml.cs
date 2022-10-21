using Controller;
using System;
using System.Collections.Generic;
using System.Configuration;
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
using Components;
using System.ComponentModel;
using Components.Models;
using Components.ZoekForms;
using Controller.Models;
using Controller.Managers;
using Controller.Interfaces.Models;
using Components.ViewModels;
using Controllers;

namespace BeheerderApp.Paginas
{
    /// <summary>
    /// Interaction logic for BeheerderPagina.xaml
    /// </summary>
    public partial class BeheerderPagina : Page
    {
        private DomeinController _domeinController;
        private WerknemerManager _werknemerManger;
        private BezoekerManager _bezoekerManger;
        private AfspraakManager _afspraakManager;
        private BedrijfManager _bedrijfManager;

        // Zoek lijsten
        private List<IWerknemer> _werknemers = new List<IWerknemer>(); 
        private List<IBezoeker> _bezoekers = new List<IBezoeker>(); 
        private List<IAfspraak> _afspraken = new List<IAfspraak>();
        private List<IBedrijf> _bedrijven = new List<IBedrijf>();
        public BeheerderPagina(DomeinController domeinController)
        {
            InitializeComponent();
            _domeinController = domeinController;
            // Managers
            _werknemerManger = _domeinController.GeefWerknemerManager();
            _bezoekerManger = _domeinController.GeefBezoekerManager();
            _afspraakManager = _domeinController.GeefAfspraakManager();
            _bedrijfManager = _domeinController.GeefBedrijfManager();
            
            // Events
            bezoekerCheckBox.Checked += CheckBoxe_Bezoeker_Toggle;
            werknemerCheckBox.Checked += CheckBoxe_Werknemer_Toggle;
            afspraakCheckBox.Checked += CheckBoxe_Afspraak_Toggle;
            bedrijfCheckBox.Checked += CheckBoxe_Bedrijven_Toggle;

            terugKnop.ButtonClick += GaPaginaTerug;

            _dataGrid.OpDataVerandering += UpdateData;
            _dataGrid.OpDataFiltering += FilterData;
        }

        

        private void UpdateData(object? sender, object obj)
        {
            string type = obj.GetType().Name;
            if(type == "Bezoeker")
            {
                _bezoekerManger.UpdateBezoeker(obj);
            }
            else if(type == "Werknemer")
            {
                _werknemerManger.UpdateWerknemer(obj);
            }
        }
        private void FilterData(object? sender, string zoekText)
        {
            List<object> itemSource = new List<object>();
            if (bezoekerCheckBox.IsActief)
            {
                List<IBezoeker> bezoekers = _bezoekerManger.ZoekOp(zoekText);
                itemSource = bezoekers.Select(x => x.GeefItemSource()).ToList();
            }
            else if (werknemerCheckBox.IsActief)
            {
                List<IWerknemer> werknemers = _werknemerManger.ZoekOp(zoekText);
                itemSource = werknemers.Select(x => x.GeefItemSource()).ToList();
            }
            else if (afspraakCheckBox.IsActief)
            {
                List<IAfspraak> afspraaks = _afspraakManager.ZoekOp(zoekText);
                itemSource = afspraaks.Select(x => x.GeefItemSource()).ToList();
            }
            else if (bedrijfCheckBox.IsActief)
            {
                List<IBedrijf> bedrijfs = _bedrijfManager.ZoekOp(zoekText);
                itemSource = bedrijfs.Select(x => x.GeefItemSource()).ToList();
            }
            _dataGrid.StelDataIn(itemSource);
        }

        private string GeefGeselecteerdBox()
        {
            if (bezoekerCheckBox.IsActief)
            {
                return "Bezoeker";
            }
            else if (werknemerCheckBox.IsActief)
            {
                return "Werknemer";
            }
            else if (afspraakCheckBox.IsActief)
            {
                return "Afspraak";
            }
            else if (bedrijfCheckBox.IsActief)
            {
                return "Bedrijf";
            }
            return null;
        }
      
        // Checkbox Events
        // TODO: kan allemaal in één methode gedaan worden.
        private void CheckBoxe_Werknemer_Toggle(object sender, bool actief)
        {

            if (actief)
            {
                if (_werknemers.Count == 0)
                {
                    _werknemers = _werknemerManger.GeefAlleWerknemers() ;
                }

                VinkAllesUit();
                Components.CheckBox checkbox = (Components.CheckBox)sender;
                checkbox.Activeer();

                List<object> itemSources = _werknemers.Select(x => x.GeefItemSource()).ToList();
                _dataGrid.StelDataIn(itemSources);
            }
            else
            {
                _dataGrid.Clear();
            }
        }

        private void CheckBoxe_Bezoeker_Toggle(object sender, bool actief)
        {

            if (actief)
            {
                if (_werknemers.Count == 0)
                {
                    _bezoekers = _bezoekerManger.GeefAlleBezoekers();
                }

                VinkAllesUit();
                Components.CheckBox checkbox = (Components.CheckBox)sender;
                checkbox.Activeer();

                List<object> itemSources = _bezoekers.Select(x => x.GeefItemSource()).ToList();
                _dataGrid.StelDataIn(itemSources);
            }
            else
            {
                _dataGrid.Clear();
            }
        }

        private void CheckBoxe_Afspraak_Toggle(object sender, bool actief)
        {

            if (actief)
            {
                if (_werknemers.Count == 0)
                {
                    _afspraken = _afspraakManager.GeefAlleAfspraken();
                }

                VinkAllesUit();
                Components.CheckBox checkbox = (Components.CheckBox)sender;
                checkbox.Activeer();

                List<object> itemSources = _afspraken.Select(x => x.GeefItemSource()).ToList();
                _dataGrid.StelDataIn(itemSources);
            }
            else
            {
                _dataGrid.Clear();
            }
        }

        private void CheckBoxe_Bedrijven_Toggle(object sender, bool actief)
        {

            if (actief)
            {
                if (_werknemers.Count == 0)
                {
                    _bedrijven = _bedrijfManager.GeefAlleBedrijven();
                }

                VinkAllesUit();
                Components.CheckBox checkbox = (Components.CheckBox)sender;
                checkbox.Activeer();

                List<object> itemSources = _bedrijven.Select(x => x.GeefItemSource()).ToList();
                _dataGrid.StelDataIn(itemSources);
            }
            else
            {
                _dataGrid.Clear();
            }
        }
        // -------------------------------------------------

        private void VinkAllesUit()
        {
            bezoekerCheckBox.DeActiveer();
            bedrijfCheckBox.DeActiveer();
            werknemerCheckBox.DeActiveer();
            afspraakCheckBox.DeActiveer();
        }
        private void GaPaginaTerug(object? sender, EventArgs e)
        {
            NavigationService.GoBack();
        }

    }
}
