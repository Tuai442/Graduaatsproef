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

namespace BeheerderApp.Paginas
{
    /// <summary>
    /// Interaction logic for BeheerderPagina.xaml
    /// </summary>
    public partial class BeheerderPagina : Page
    {
        private BeheerController _beheerController;

        // private ZoekbaarDataGrid _dataGrid;
        // Zoek lijsten
        private List<object> _werknemers = new List<object>(); 
        private List<object> _bezoekers = new List<object>(); 
        private List<object> _afspraken = new List<object>();
        private List<object> _bedrijven = new List<object>();
        public BeheerderPagina(BeheerController beheerController)
        {
            _beheerController = beheerController;
            InitializeComponent();

            bezoekerCheckBox.Checked += CheckBoxe_Bezoeker_Toggle;
            werknemerCheckBox.Checked += CheckBoxe_Werknemer_Toggle;
            afspraakCheckBox.Checked += CheckBoxe_Afspraak_Toggle;
            bedrijfCheckBox.Checked += CheckBoxe_Bedrijven_Toggle;

            terugKnop.ButtonClick += GaPaginaTerug;
            _dataGrid.OpDataVerandering += UpdateData;
        }
        private void VinkAllesUit()
        {
            bezoekerCheckBox.DeActiveer();
            bedrijfCheckBox.DeActiveer();
            werknemerCheckBox.DeActiveer();
            afspraakCheckBox.DeActiveer();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Vanaf er nieuw text in onze zoekbalk komt word dit event opgeroepen. 
            string zoekText = zoekBar.Text;
            // Hier kunnen we ons datagrid filter op het huidige zoekwoord.
            _dataGrid.FilterOp(zoekText);
            

        }

        private void UpdateData(object? sender, object obj)
        {
            string type = obj.GetType().Name;
            if(type == "Bezoeker")
            {
                _beheerController.UpdateBezoeker(obj);
            }
            else if(type == "Werknemer")
            {
                _beheerController.UpdateWerknemer(obj);
            }
        }

        private void GaPaginaTerug(object? sender, EventArgs e)
        {
            NavigationService.GoBack();
        }

        // Checkbox Events
        // TODO: kan allemaal in één methode gedaan worden.
        private void CheckBoxe_Werknemer_Toggle(object sender, bool actief)
        {

            if (actief)
            {
                if (_werknemers.Count == 0)
                {
                    _werknemers = _beheerController.GeefAlleWerknemersInTabelData();
                }

                VinkAllesUit();
                Components.CheckBox checkbox = (Components.CheckBox)sender;
                checkbox.Activeer();

                _dataGrid.VoegDataToe(_werknemers);
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
                    _bezoekers = _beheerController.GeefAlleBezoekersInTabelData();
                }

                VinkAllesUit();
                Components.CheckBox checkbox = (Components.CheckBox)sender;
                checkbox.Activeer();
                _dataGrid.VoegDataToe(_bezoekers);
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
                    _afspraken = _beheerController.GeefAlleAfsprakenInTabelData();
                }

                VinkAllesUit();
                Components.CheckBox checkbox = (Components.CheckBox)sender;
                checkbox.Activeer();
                _dataGrid.VoegDataToe(_afspraken);
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
                    _bedrijven = _beheerController.GeefAlleBedrijvenInTabelData();
                }

                VinkAllesUit();
                Components.CheckBox checkbox = (Components.CheckBox)sender;
                checkbox.Activeer();
                _dataGrid.VoegDataToe(_bedrijven);
            }
            else
            {
                _dataGrid.Clear();
            }
        }
        // -------------------------------------------------


    }
}
