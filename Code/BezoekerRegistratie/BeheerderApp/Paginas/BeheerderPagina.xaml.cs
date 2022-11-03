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
        private List<WerknemerViewModel> _werknemers = new List<WerknemerViewModel>(); 
        private List<BezoekerViewModel> _bezoekers = new List<BezoekerViewModel>(); 
        private List<AfspraakViewModel> _afspraken = new List<AfspraakViewModel>();
        private List<BedrijfViewModel> _bedrijven = new List<BedrijfViewModel>();
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
                //_bezoekerManger.UpdateBezoeker(obj);
            }
            else if(type == "Werknemer")
            {
                _werknemerManger.UpdateWerknemer(obj);
            }
        }
        private void FilterData(object? sender, string zoekText)
        {
            
            if (bezoekerCheckBox.IsActief)
            {
                IReadOnlyList<Bezoeker> bezoekers = _bezoekerManger.ZoekOp(zoekText);
                _bezoekers = Omzetter.ZetBezoekersOmInViewModellen(bezoekers);
                _dataGrid.StelDataIn<BezoekerViewModel>(_bezoekers);
            }
            else if (werknemerCheckBox.IsActief)
            {
                IReadOnlyList<Werknemer> werknemers = _werknemerManger.ZoekOp(zoekText);
                _werknemers = Omzetter.ZetWerknemersOmInViewModellen(werknemers);
                _dataGrid.StelDataIn<WerknemerViewModel>(_werknemers);
            }
            else if (afspraakCheckBox.IsActief)
            {
                IReadOnlyList<Afspraak> afspraaks = _afspraakManager.ZoekOp(zoekText);
                _afspraken = Omzetter.ZetAfsprakenOmInViewModellen(afspraaks);
                _dataGrid.OpDataVerandering = _afspraakManager.OpUpdateAfspraak;
                _dataGrid.StelDataIn<AfspraakViewModel>(_afspraken);
            }
            else if (bedrijfCheckBox.IsActief)
            {
                IReadOnlyList<Bedrijf> bedrijven = _bedrijfManager.ZoekOp(zoekText);
                _bedrijven = Omzetter.ZetBedrijvenOmInViewModellen(bedrijven);
                _dataGrid.StelDataIn<BedrijfViewModel>(_bedrijven);
            }
            
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
                //if (_werknemers.Count == 0)
                //{
                //    IReadOnlyList<Werknemer> werknemers = (IReadOnlyList<Werknemer>)_werknemerManger.GeefAlleWerknemers() ;
                //    _werknemers = Omzetter.ZetWerknemersOmInViewModellen(werknemers);
                //}

                VinkAllesUit();
                Components.CheckBox check = (Components.CheckBox)sender;
                check.Activeer();

                _dataGrid.StelDataIn<Werknemer>(_werknemers);
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
                //if (_bezoekers.Count == 0)
                //{
                //    _bezoekers = _bezoekerManger.GeefAlleAanwezigeBezoekers();
                //}

                VinkAllesUit();
                Components.CheckBox check = (Components.CheckBox)sender;
                check.Activeer();

                _dataGrid.StelDataIn<Bezoeker>(_bezoekers);
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
                //if (_afspraken.Count == 0)
                //{
                //    IReadOnlyList<Afspraak> afspraken = (IReadOnlyList<Afspraak>)_afspraakManager.GeefAlleAfspraken();
                //    _afspraken = Omzetter.ZetAfsprakenOmInViewModellen(afspraken);
                //}

                VinkAllesUit();
                Components.CheckBox check = (Components.CheckBox)sender;
                check.Activeer();

                _dataGrid.StelDataIn<AfspraakViewModel>(_afspraken);
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
                //if (_bedrijven.Count == 0)
                //{
                //    _bedrijven = _bedrijfManager.GeefAlleBedrijven();
                //}

                VinkAllesUit();
                Components.CheckBox check = (Components.CheckBox)sender;
                check.Activeer();

                _dataGrid.StelDataIn<Bedrijf>(_bedrijven);
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
