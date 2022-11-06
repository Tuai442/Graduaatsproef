
using Components.ViewModels;
using Controller;
using Controller.Interfaces.Models;

using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

        private Type _type;
        private IEnumerable _data;
        public ZoekbaarDataGrid()
        {
            InitializeComponent();
            _data = new List<object>();
            dataGrid.ItemsSource = _data;
            

        }


        public EventHandler<object> OpDataVerandering;

        public EventHandler<string> OpDataFiltering;

        private object _aanHetVeranderen;

        public void StelDataIn<T>(IEnumerable viewModel)
        {
            _data = viewModel;
            MaakHoofding<T>(viewModel);
            dataGrid.ItemsSource = null;
            dataGrid.ItemsSource = viewModel;
        }

        private void MaakHoofding<T>(IEnumerable viewModel)
        {
            dataGrid.Columns.Clear();
            Dictionary<string, string> hoofding = HoofdingManager.GeefHoofding<T>();
            int index = 0;
            foreach (string key in hoofding.Keys)
            {
                DataGridTextColumn c = new DataGridTextColumn();
                c.Header = hoofding[key];
                c.Binding = new Binding(key);

                dataGrid.Columns.Add(c);
            }
            dataGrid.AutoGenerateColumns = false;
        }

        private void FilterOp(string zoekWoord)
        {
           
        }

        // Als er een aanpassing wordt gedaan worden deze 2 events opgeroepen.
        //private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    _aanHetVeranderen  = e.AddedItems[0];
        //}

        //private void dataGrid_CurrentCellChanged(object sender, EventArgs e)
        //{
        //    if (_aanHetVeranderen != null)
        //    {
                
        //        OpDataVerandering.Invoke(this, _aanHetVeranderen);
        //    }
        //    _aanHetVeranderen = null;
        //}
        // -------------------------------------------------------------------
        
        // Dit wordt opgeroepen vanaf er een verandering in de zoekbalk gebeurt.
        private void zoekBar_TextChanged(object sender, TextChangedEventArgs e)
        {

            // Hier kunnen we ons datagrid filter op het huidige zoekwoord.
            string zoekText = zoekBar.Text;

            // Manier 1:
            // - alle gegevens worden bijgouden in memory.(niet optimaal, maar er word weinig naar de db gestuurd).
            // + we moeten er voor zorgen dat er bij een verandering in de db alle data opnieuw wordt opgehaald.
            //FilterOp(zoekText);

            // Manier 2:
            // - per verandering wordt er gecommuniceerd naar de db.(weinig in memory, veel verkeer). 
            // Voordeel we kunnen filteren met behulp van een query.
            OpDataFiltering.Invoke(sender, zoekText);

        }

       
    }
}


//DataGridRow dataGridRij;
//List<object> temp = new List<object>();
//if (string.IsNullOrEmpty(zoekWoord))
//{
//    //temp = _data;
//}
//else
//{
//    // TODO: totaal niet effecient juist maar voor de demo gebruiken.
//    foreach (var row in dataGrid.ItemsSource)
//    {
//        var json = JsonConvert.SerializeObject(row);
//        var dictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);

//        bool gevonden = false;
//        foreach (string value in dictionary.Values)
//        {
//            if (!string.IsNullOrEmpty(value) && zoekWoord.Length <= value.Length)
//            {
//                bool komtVoorInString = false;
//                for (int i = 0; i < zoekWoord.Length; i++)
//                {
//                    if (Char.ToLower(zoekWoord[i]) == Char.ToLower(value[i]))
//                    {
//                        komtVoorInString = true;
//                    }
//                    else
//                    {
//                        komtVoorInString = false;
//                        break;
//                    }
//                }
//                if (komtVoorInString)
//                {
//                    gevonden = true;
//                }

//            }

//        }

//        //dataGridRij = dataGrid.ItemContainerGenerator.ContainerFromItem(row) as DataGridRow;
//        if (!gevonden)
//        {
//            //dataGridRij.Visibility = System.Windows.Visibility.Collapsed;
//        }

//        else
//        {
//            //dataGridRij.Visibility = System.Windows.Visibility.Visible;
//            temp.Add(row);

//        }
//    }
//}