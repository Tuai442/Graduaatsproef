using Controller.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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

namespace BezoekerRegistratie.UI_Onderdelen
{
    /// <summary>
    /// Interaction logic for CustomTable.xaml
    /// </summary>
    public partial class CustomTable : UserControl
    {

        private DataGrid _dataGrid;
        public CustomTable()
        {
            InitializeComponent();

            _dataGrid = new DataGrid();
            grid.Children.Add(_dataGrid);

        }

        public void GenereerTable(List<Dictionary<string, string>> zoekRezultaat)
        {
            if(zoekRezultaat.Count != 0)
            {
                List<string> headerNamen = zoekRezultaat[0].Keys.ToList();
                _dataGrid.Items.Clear();
                _dataGrid.Columns.Clear();
                // Eerst headers maken
                foreach (string naam in headerNamen)
                {
                    DataGridTextColumn textColumn = new DataGridTextColumn();
                    textColumn.Header = naam;
                    textColumn.Binding = new Binding(naam);
                    _dataGrid.Columns.Add(textColumn);
                }


                //List<Bezoeker> list = new List<Bezoeker>();
                //list.Add(new Bezoeker("Jan", "Jansen", "janjansen@email", new Bedrijf("INEO Fenol", "btw", "getn", "99999", "ineoemail")));
                //_dataGrid.ItemsSource = list;

                // Dan kunnen we de waarde invullen
                ObservableCollection<dynamic> map = new ObservableCollection<dynamic>();
                foreach (Dictionary<string, string> data in zoekRezultaat)
                {
                    foreach (string naam in headerNamen)
                    {

                    }
                }


            }


        }
    }
}
