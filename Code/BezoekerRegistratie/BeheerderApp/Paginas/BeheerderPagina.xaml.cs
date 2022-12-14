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

using Controllers;
using Components.Datagrids;
using Components.ViewModels;
using System.Collections.ObjectModel;
using BeheerderApp.Windows;
using Components.Interfaces;
using DebounceThrottle;

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

        private DebounceDispatcher _debounceDispatcher;
        public BeheerderPagina(DomeinController domeinController)
        {
            try
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
                voegToeBtns.Visibility = Visibility.Hidden;
                dataGrid.OpDataFiltering += FilterData;
                dataGrid.OpDataVerwijdering += VerwijderData;

                IReadOnlyList<Bedrijf> bedrijven = _bedrijfManager.GeefAlleBedrijven();
                foreach (Bedrijf bedrijf in bedrijven)
                {
                    BedrijfView bedrijfView = new BedrijfView(bedrijf);
                    bedrijfView.PropertyChanged += UpdateBedrijf;
                    _bedrijfViews.Add(bedrijfView);
                }

                _debounceDispatcher = new DebounceDispatcher(1000);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        //TODO: alle verwijder zijn niet uitgeschreven
        private void VerwijderData(object? sender, int index)
        {
            try
            {
                if (bezoekerCheckBox.IsActief)
                {
                    _bezoekerManger.VerwijderBezoeker(index);
                }
                else if (werknemerCheckBox.IsActief)
                {
                    _werknemerManger.VerwijderWerknemer(index);
                }
                else if (bedrijfCheckBox.IsActief)
                {
                    _bedrijfManager.VerwijderBedrijf(index);
                }
                else if (afspraakCheckBox.IsActief)
                {
                    _afspraakManager.VerwijderAfspraak(index);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void FilterData(object? sender, string zoekText)
        {
            try
            {
                _debounceDispatcher.Debounce(() =>
                {
                    if (bezoekerCheckBox.IsActief)
                    {
                        IReadOnlyList<Bezoeker> bezoekers = _bezoekerManger.ZoekOp(zoekText);
                        _bezoekerViews = new List<BezoekerView>();
                        foreach (Bezoeker bezoeker in bezoekers)
                        {
                            BezoekerView bezoekerView = new BezoekerView(bezoeker);
                            bezoekerView.PropertyChanged += UpdateBezoeker;
                            _bezoekerViews.Add(bezoekerView);
                        }

                        //TODO: wat is dispatcher?
                        Dispatcher.Invoke(() =>
                        {
                            dataGrid.StelDataIn<BezoekerView>(_bezoekerViews);
                        });
                    }
                    else if (werknemerCheckBox.IsActief)
                    {
                        IReadOnlyList<Werknemer> werknemers = _werknemerManger.ZoekOp(zoekText);
                        _werknemerViews = new List<WerknemerView>();
                        foreach (Werknemer werknemer in werknemers)
                        {
                            WerknemerView werknemerView = new WerknemerView(werknemer);
                            werknemerView.PropertyChanged += UpdateWerknemer;
                            _werknemerViews.Add(werknemerView);
                        }
                        Dispatcher.Invoke(() =>
                        {
                            dataGrid.StelDataIn<WerknemerView>(_werknemerViews, false, _bedrijfViews);
                        });
                    }
                    else if (afspraakCheckBox.IsActief)
                    {
                        //werknemerDataGrid.Visibility = Visibility.Hidden;
                        //dataGrid.Visibility = Visibility.Visible;
                        IReadOnlyList<Afspraak> afspraken = _afspraakManager.ZoekOp(zoekText);
                        _afspraakViews = new List<AfspraakView>();
                        foreach (Afspraak afspraak in afspraken)
                        {
                            AfspraakView afspraakView = new AfspraakView(afspraak);
                            afspraakView.PropertyChanged += UpdateAfspraak;
                            _afspraakViews.Add(afspraakView);
                        }
                        Dispatcher.Invoke(() =>
                        {
                            dataGrid.StelDataIn<AfspraakView>(_afspraakViews);
                        });
                    }
                    else if (bedrijfCheckBox.IsActief)
                    {
                        //werknemerDataGrid.Visibility = Visibility.Hidden;
                        //dataGrid.Visibility = Visibility.Visible;
                        IReadOnlyList<Bedrijf> bedrijven = _bedrijfManager.ZoekOp(zoekText);
                        _bedrijfViews = new List<BedrijfView>();
                        foreach (Bedrijf bedrijf in bedrijven)
                        {
                            BedrijfView bedrijfView = new BedrijfView(bedrijf);
                            bedrijfView.PropertyChanged += UpdateBedrijf;
                            _bedrijfViews.Add(bedrijfView);
                        }
                        Dispatcher.Invoke(() =>
                        {
                            dataGrid.StelDataIn<BedrijfView>(_bedrijfViews);

                        });
                    }
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        // Checkbox Events
        private void CheckBoxe_Werknemer_Toggle(object sender, bool actief)
        {
            try
            {
                if (actief)
                {
                    //werknemerDataGrid.Visibility = Visibility.Visible;
                    //dataGrid.Visibility = Visibility.Collapsed;
                    if (_werknemerViews.Count == 0)
                    {
                        IReadOnlyList<Werknemer> werknemers = _werknemerManger.GeefAlleWerknemers();
                        foreach (Werknemer werknemer in werknemers)
                        {
                            WerknemerView werknemerView = new WerknemerView(werknemer);
                            werknemerView.PropertyChanged += UpdateWerknemer;
                            _werknemerViews.Add(werknemerView);
                        }

                    }
                    voegToeBtns.Visibility = Visibility.Visible;
                    voegToeBtns.Content = "Voeg werknemer toe";

                    Components.CheckBox check = (Components.CheckBox)sender;
                    VinkAllesUitBehalve(check);

                    //TODO: wrm ook bedrijvenView?
                    if (_bedrijfViews.Count == 0)
                    {
                        IReadOnlyList<Bedrijf> bedrijven = _bedrijfManager.GeefAlleBedrijven();
                        foreach (Bedrijf bedrijf in bedrijven)
                        {
                            BedrijfView bedrijfView = new BedrijfView(bedrijf);
                            bedrijfView.PropertyChanged += UpdateBedrijf;
                            _bedrijfViews.Add(bedrijfView);
                        }
                    }

                    //List<string> bedrijbString = _bedrijfViews.Select(x => x.Naam).ToList();
                    dataGrid.StelDataIn<WerknemerView>(_werknemerViews, false, _bedrijfViews);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void CheckBoxe_Bezoeker_Toggle(object sender, bool actief)
        {
            try
            {
                if (actief)
                {
                    //werknemerDataGrid.Visibility = Visibility.Hidden;
                    //dataGrid.Visibility = Visibility.Visible;

                    if (_bezoekerViews.Count == 0)
                    {
                        IReadOnlyList<Bezoeker> bezoekers = _bezoekerManger.GeefAlleAanwezigeBezoekers();
                        foreach (Bezoeker bezoeker in bezoekers)
                        {
                            BezoekerView bezoekerView = new BezoekerView(bezoeker);
                            bezoekerView.PropertyChanged += UpdateBezoeker;
                            _bezoekerViews.Add(bezoekerView);
                        }
                    }
                    voegToeBtns.Visibility = Visibility.Hidden;
                    // voegToeBtns.Content = "Voeg bezoeker toe"; // gaat normaal niet nodig zijn

                    Components.CheckBox check = (Components.CheckBox)sender;
                    VinkAllesUitBehalve(check);

                    dataGrid.StelDataIn<BezoekerView>(_bezoekerViews);

                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void CheckBoxe_Afspraak_Toggle(object sender, bool actief)
        {
            try
            {

                if (actief)
                {
                    //werknemerDataGrid.Visibility = Visibility.Hidden;
                    //dataGrid.Visibility = Visibility.Visible;

                    if (_afspraakViews.Count == 0)
                    {
                        IReadOnlyList<Afspraak> afspraken = _afspraakManager.GeefAlleAfspraken();
                        foreach (Afspraak afspraak in afspraken)
                        {
                            AfspraakView afspraakView = new AfspraakView(afspraak);
                            afspraakView.PropertyChanged += UpdateAfspraak;
                            _afspraakViews.Add(afspraakView);
                        }
                    }
                    voegToeBtns.Visibility = Visibility.Hidden;

                    Components.CheckBox check = (Components.CheckBox)sender;
                    VinkAllesUitBehalve(check);

                    dataGrid.StelDataIn<AfspraakView>(_afspraakViews, true);

                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void CheckBoxe_Bedrijven_Toggle(object sender, bool actief)
        {
            try
            {
                if (actief)
                {

                    if (_bedrijfViews.Count == 0)
                    {
                        IReadOnlyList<Bedrijf> bedrijven = _bedrijfManager.GeefAlleBedrijven();
                        foreach (Bedrijf bedrijf in bedrijven)
                        {
                            BedrijfView bedrijfView = new BedrijfView(bedrijf);
                            bedrijfView.PropertyChanged += UpdateBedrijf;
                            _bedrijfViews.Add(bedrijfView);
                        }
                    }
                    voegToeBtns.Visibility = Visibility.Visible;
                    voegToeBtns.Content = "Voeg bedrijf toe";

                    Components.CheckBox check = (Components.CheckBox)sender;
                    VinkAllesUitBehalve(check);

                    dataGrid.StelDataIn<BedrijfView>(_bedrijfViews);

                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        // Updates - Mogen we dit niet rechtstreeks naar de managers leggen ?
        private void UpdateWerknemer(object? sender, PropertyChangedEventArgs e)
        {
            try
            {
                WerknemerView werknemerView = (WerknemerView)sender;
                _werknemerManger.UpdateWerknemer(werknemerView.Werknemer);
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void UpdateBezoeker(object? sender, PropertyChangedEventArgs e)
        {
            try
            {
                BezoekerView bezoekerView = (BezoekerView)sender;
                _bezoekerManger.UpdateBezoeker(bezoekerView.Bezoeker);
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //TODO: Afspraak kunnen updaten
        private void UpdateAfspraak(object? sender, PropertyChangedEventArgs e)
        {
            //TODO: juist gedaan ??
            try
            {
                AfspraakView afspraakView = (AfspraakView)sender;
                _afspraakManager.UpdateAfspraak(afspraakView.Afspraak);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void UpdateBedrijf(object? sender, PropertyChangedEventArgs e)
        {
            try
            {
                BedrijfView bedrijfView = (BedrijfView)sender;
                _bedrijfManager.UpdateBedrijf(bedrijfView.Bedrijf);
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // -------------------------------------------------

        private void VinkAllesUitBehalve(Components.CheckBox check)
        {
            if (check != bezoekerCheckBox)
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

        //TODO: wordt niet gebruikt
        //private void herlaadBtn_Click(object sender, RoutedEventArgs e)
        //{

        //    _bezoekerViews = new List<BezoekerView>();
        //    _bedrijfViews = new List<BedrijfView>();
        //    _afspraakViews = new List<AfspraakView>();
        //    _werknemerViews = new List<WerknemerView>();
        //    dataGrid.StelDataIn<object>(null);
        //}
        private void voegToeBtns_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (werknemerCheckBox.IsActief)
                {
                    List<ILijstItems> bedrijfItems = _bedrijfViews.Select(x => (ILijstItems)x).ToList();
                    VoegWerknemerToeWindow v = new VoegWerknemerToeWindow(_domeinController, bedrijfItems);
                    v.Show();
                }
                else if (bedrijfCheckBox.IsActief)
                {
                    VoegBedrijfToe bedrijfWindow = new VoegBedrijfToe(_domeinController);
                    bedrijfWindow.Show();
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
