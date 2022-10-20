using Components.Models;
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

namespace Components.ZoekForms
{
    /// <summary>
    /// Interaction logic for WerknemerZoekForm.xaml
    /// </summary>
    public partial class WerknemerZoekForm : UserControl
    {
        private List<string> _werknemers;
        private ZoekMachine _zoekMachine;
        public WerknemerZoekForm()
        {
            //_werknemers = werknemers;
            _zoekMachine = new ZoekMachine();
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Hier wordt alle data uit de input velden gehaald en op basis van die data gezocht.
            string id = idTxbBox.Text;
            string naam = naamTxtBox.Text;
            string bedrijf = bedrijfTxtBox.Text;
            string functie = functieTxtBox.Text;


        }
    }
}
