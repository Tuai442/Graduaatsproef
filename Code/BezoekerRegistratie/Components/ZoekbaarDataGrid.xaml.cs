using Components.Models;
using Controller.Interfaces.Models;
using Controller.Models;
using Newtonsoft.Json;
using System;
using System.Collections;
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
using System.Windows.Markup;
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



        public int GridHeight
        {
            get { return (int)GetValue(GridHeightProperty); }
            set { SetValue(GridHeightProperty, value); }
        }

        // Using a DependencyProperty as the backing store for GridHeight.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GridHeightProperty =
            DependencyProperty.Register("GridHeight", typeof(int), typeof(ZoekbaarDataGrid), new PropertyMetadata(null));


        private List<object> _data;

        public ZoekbaarDataGrid()
        {
            InitializeComponent();
            _data = new List<object>();
            dataGrid.ItemsSource = _data;
            

        }


        public EventHandler<object> OpDataVerandering;

        public EventHandler<string> OpDataFiltering;

        private object _aanHetVeranderen;
        public void StelDataIn(List<object> data)
        {
            _data = data;
            dataGrid.ItemsSource = data;
        }
        public void Clear()
        {
            dataGrid.ItemsSource = null;
            dataGrid.Items.Clear();
        }
        public void FilterOp(string zoekWoord)
        {
            DataGridRow dataGridRij;
            List<object> temp = new List<object>();
            if (string.IsNullOrEmpty(zoekWoord))
            {
                foreach (var row in dataGrid.ItemsSource)
                {
                    var json = JsonConvert.SerializeObject(row);
                    var dictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
                    temp.Add(row);
                    //dataGridRij = dataGrid.ItemContainerGenerator.ContainerFromItem(row) as DataGridRow;
                    //dataGridRij.Visibility = System.Windows.Visibility.Visible;
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

                    //dataGridRij = dataGrid.ItemContainerGenerator.ContainerFromItem(row) as DataGridRow;
                    if (!gevonden)
                    {
                        //dataGridRij.Visibility = System.Windows.Visibility.Collapsed;
                    }

                    else
                    {
                        //dataGridRij.Visibility = System.Windows.Visibility.Visible;
                        temp.Add(row);

                    }
                }
            }
            dataGrid.ItemsSource = temp;
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
       
        // Dit wordt opgeroepen vanaf er een verandering in de zoekbalk gebeurt.
        private void zoekBar_TextChanged(object sender, TextChangedEventArgs e)
        {

            // Hier kunnen we ons datagrid filter op het huidige zoekwoord.
            string zoekText = zoekBar.Text;
            // Manier 1:
            // - alle gegevens worden bijgouden in memory.(niet optimaal, maar er word weinig naar de db gestuurd).
            FilterOp(zoekText);

            // Manier 2:
            // - per verandering wordt er gecommuniceerd naar de db.(weinig in memory, veel verkeer).
            // OpDataFiltering.Invoke(sender, zoekText);

        }
    }
}
