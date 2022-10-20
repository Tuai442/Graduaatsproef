using Components.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Components
{
    /// <summary>
    /// Interaction logic for ZoekbaarDataGrid.xaml
    /// </summary>
    public partial class ZoekbaarDataGrid : UserControl
    {
        private List<object> _data;
        public ZoekbaarDataGrid()
        {
            InitializeComponent();
            _data = new List<object>();
            dataGrid.ItemsSource = _data;
            

        }


        public EventHandler<object> OpDataVerandering;

        private object _aanHetVeranderen;
        public void VoegDataToe(List<object> data)
        {
            _data = data;
            dataGrid.ItemsSource = _data;
        }
        public void Clear()
        {
            dataGrid.ItemsSource = null;
            dataGrid.Items.Clear();
        }
        public void FilterOp(string zoekWoord)
        {
            DataGridRow dataGridRij;
            if (string.IsNullOrEmpty(zoekWoord))
            {
                foreach (var row in dataGrid.ItemsSource)
                {
                    var json = JsonConvert.SerializeObject(row);
                    var dictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
                    dataGridRij = dataGrid.ItemContainerGenerator.ContainerFromItem(row) as DataGridRow;
                    dataGridRij.Visibility = System.Windows.Visibility.Visible;
                }
            }
            else
            {
                // TODO: totaal niet effecient juist maar voor de demo gebruiken.
                foreach (var row in dataGrid.ItemsSource)
                {
                    var json = JsonConvert.SerializeObject(row);
                    var dictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);

                    bool gevonden = false;
                    foreach (string value in dictionary.Values)
                    {
                        if (!string.IsNullOrEmpty(value) && zoekWoord.Length <= value.Length)
                        {
                            bool komtVoorInString = false;
                            for (int i = 0; i < zoekWoord.Length; i++)
                            {
                                if (Char.ToLower(zoekWoord[i]) == Char.ToLower(value[i]))
                                {
                                    komtVoorInString = true;
                                }
                                else
                                {
                                    komtVoorInString = false;
                                    break;
                                }
                            }
                            if (komtVoorInString)
                            {
                                gevonden = true;
                            }

                        }

                    }

                    dataGridRij = dataGrid.ItemContainerGenerator.ContainerFromItem(row) as DataGridRow;
                    if (!gevonden)
                    {
                        dataGridRij.Visibility = System.Windows.Visibility.Collapsed;
                    }

                    else
                    {
                        dataGridRij.Visibility = System.Windows.Visibility.Visible;
                    }
                }
            }
        }


        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _aanHetVeranderen  = e.AddedItems[0];
        }

        private void dataGrid_CurrentCellChanged(object sender, EventArgs e)
        {
            if(_aanHetVeranderen != null)
            {
                OpDataVerandering.Invoke(this, _aanHetVeranderen);
            }
            _aanHetVeranderen = null;
        }
    }
}
