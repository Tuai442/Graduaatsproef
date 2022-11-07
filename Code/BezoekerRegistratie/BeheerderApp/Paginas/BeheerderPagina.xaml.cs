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

using Controller.Models;
using Controller.Managers;
using Controller.Interfaces.Models;

using Controllers;
using Components.Datagrids;
using Components.ViewModels;

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
        private List<WerknemerView> _werknemerViews = new List<WerknemerView>(); 
        private List<BezoekerView> _bezoekerViews = new List<BezoekerView>(); 
        private List<AfspraakView> _afspraakViews = new List<AfspraakView>();
        private List<BedrijfView> _bedrijfViews = new List<BedrijfView>();
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

            dataGrid.OpDataFiltering += FilterData;
        }

        private void FilterData(object? sender, string zoekText)
        {
            if (bezoekerCheckBox.IsActief)
            {
                werknemerDataGrid.Visibility = Visibility.Hidden;
                dataGrid.Visibility = Visibility.Visible;
                IReadOnlyList<Bezoeker> bezoekers = _bezoekerManger.ZoekOp(zoekText);
                _bezoekerViews = new List<BezoekerView>();
                foreach (Bezoeker bezoeker in bezoekers)
                {
                    BezoekerView bezoekerView = new BezoekerView(bezoeker);
                    bezoekerView.PropertyChanged += UpdateBezoeker;
                    _bezoekerViews.Add(bezoekerView);
                }
                dataGrid.StelDataIn<BezoekerView>(_bezoekerViews);
            }
            else if (werknemerCheckBox.IsActief)
            {
                werknemerDataGrid.Visibility = Visibility.Visible;
                dataGrid.Visibility = Visibility.Hidden;
                IReadOnlyList<Werknemer> werknemers = _werknemerManger.ZoekOp(zoekText);
                _werknemerViews = new List<WerknemerView>();
                foreach (Werknemer werknemer in werknemers)
                {
                    WerknemerView werknemerView = new WerknemerView(werknemer);
                    //werknemerView.PropertyChanged += UpdateWerknemer;
                    _werknemerViews.Add(werknemerView);
                }
                werknemerDataGrid.StelDataIn(_werknemerViews);
            }
            else if (afspraakCheckBox.IsActief)
            {
                werknemerDataGrid.Visibility = Visibility.Hidden;
                dataGrid.Visibility = Visibility.Visible;
                IReadOnlyList<Afspraak> afspraken = _afspraakManager.ZoekOp(zoekText);
                _afspraakViews = new List<AfspraakView>();
                foreach (Afspraak afspraak in afspraken)
                {
                    AfspraakView afspraakView = new AfspraakView(afspraak);
                    //afspraakView.PropertyChanged += UpdateAfspraak;
                    _afspraakViews.Add(afspraakView);
                }
                dataGrid.StelDataIn<AfspraakView>(_afspraakViews);



            }
            else if (bedrijfCheckBox.IsActief)
            {
                werknemerDataGrid.Visibility = Visibility.Hidden;
                dataGrid.Visibility = Visibility.Visible;
                IReadOnlyList<Bedrijf> bedrijven = _bedrijfManager.ZoekOp(zoekText);
                _bedrijfViews = new List<BedrijfView>();
                foreach (Bedrijf bedrijf in bedrijven)
                {
                    BedrijfView bedrijfView = new BedrijfView(bedrijf);
                    //bedrijfView.PropertyChanged += UpdateBedrijf;
                    _bedrijfViews.Add(bedrijfView);
                }
                dataGrid.StelDataIn<BedrijfView>(_bedrijfViews);
            }

        }

        // Checkbox Events
        private void CheckBoxe_Werknemer_Toggle(object sender, bool actief)
        {
            if (actief)
            {
                //werknemerDataGrid.Visibility = Visibility.Visible;
                //dataGrid.Visibility = Visibility.Collapsed;
                if (_werknemerViews.Count == 0)
                {
                    IReadOnlyList<Werknemer> werknemers = _werknemerManger.GeefAlleWerknemers();
                    _werknemerViews = werknemers.Select(x => new WerknemerView(x)).ToList();
                }

                Components.CheckBox check = (Components.CheckBox)sender;
                VinkAllesUitBehalve(check);

                dataGrid.StelDataIn<WerknemerView>(_werknemerViews);
                //werknemerDataGrid.StelDataIn(_werknemerViews);
                //dataGrid.StelDataIn<WerknemerView>(_werknemerViews);

            }

        }

        private void CheckBoxe_Bezoeker_Toggle(object sender, bool actief)
        {
            if (actief) 
            {
                werknemerDataGrid.Visibility = Visibility.Hidden;
                dataGrid.Visibility = Visibility.Visible;

                //if (_bezoekerViews.Count == 0)
                //{
                //    IReadOnlyList<Bezoeker> bezoekers = _bezoekerManger.GeefAlleAanwezigeBezoekers();
                //    foreach (Bezoeker bezoeker in bezoekers)
                //    {
                //        BezoekerView bezoekerView = new BezoekerView(bezoeker);
                //        //bezoekerView.PropertyChanged += UpdateBezoeker;
                //        _bezoekerViews.Add(bezoekerView);
                //    }
                //}

                Components.CheckBox check = (Components.CheckBox)sender;
                VinkAllesUitBehalve(check);

                dataGrid.StelDataIn<BezoekerView>(_bezoekerViews);

            }

        }

        private void CheckBoxe_Afspraak_Toggle(object sender, bool actief)
        {

            if (actief)
            {
                werknemerDataGrid.Visibility = Visibility.Hidden;
                dataGrid.Visibility = Visibility.Visible;

                //if (_afspraakViews.Count == 0)
                //{
                //    IReadOnlyList<Afspraak> af = _afspraakManager.GeefAlleAfspraken();
                //    _afspraakViews = af.Select(x => new AfspraakView(x)).ToList();
                //}

                Components.CheckBox check = (Components.CheckBox)sender;
                VinkAllesUitBehalve(check);

                dataGrid.StelDataIn<AfspraakView>(_afspraakViews);

            }

        }

        private void CheckBoxe_Bedrijven_Toggle(object sender, bool actief)
        {

            if (actief)
            {
                werknemerDataGrid.Visibility = Visibility.Hidden;
                dataGrid.Visibility = Visibility.Visible;
                //if (_bedrijfViews.Count == 0)
                //{
                //    IReadOnlyList<Bedrijf> bedrijven = _bedrijfManager.GeefAlleBedrijven();
                //    _bedrijfViews = bedrijven.Select(x => new BedrijfView(x)).ToList();
                //}
                Components.CheckBox check = (Components.CheckBox)sender;
                VinkAllesUitBehalve(check);

                dataGrid.StelDataIn<BedrijfView>(_bedrijfViews);

            }
            
        }
        // -------------------------------------------------

        // Updates

        private void UpdateBezoeker(object? sender, PropertyChangedEventArgs e)
        {
            BezoekerView bezoekerView = (BezoekerView)sender;
            _bezoekerManger.UpdateBezoeker(bezoekerView.Bezoeker);
        }

        // -------------------------------------------------

        private void VinkAllesUitBehalve(Components.CheckBox check)
        {
            if(check != bezoekerCheckBox)
            {
                bezoekerCheckBox.DeActiveer();
            }
            if (check != bedrijfCheckBox)
            {
                bedrijfCheckBox.DeActiveer();
            }
            if (check != werknemerCheckBox)
            {
                werknemerCheckBox.DeActiveer();
            }
            if (check != afspraakCheckBox)
            {
                afspraakCheckBox.DeActiveer();
            }
        }
        private void GaPaginaTerug(object? sender, EventArgs e)
        {
            NavigationService.GoBack();
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

        private void herlaadBtn_Click(object sender, RoutedEventArgs e)
        {
            dataGrid.StelDataIn<BezoekerView>(_bezoekerViews);
        }
    }
}
