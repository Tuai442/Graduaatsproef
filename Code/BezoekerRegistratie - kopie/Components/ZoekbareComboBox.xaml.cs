using Accessibility;
using Components.Interfaces;
using Controller.Interfaces;
using Controller.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection;
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
using System.Windows.Xps;

namespace Components
{
    /// <summary>
    /// Interaction logic for ZoekbareComboBox.xaml
    /// </summary>
    public partial class ZoekbareComboBox : UserControl
    {
        //TODO: wat doet dit?
        public static readonly DependencyProperty HeightProperty =
            DependencyProperty.Register("Height", typeof(int), typeof(ZoekbareComboBox), new PropertyMetadata(null));


        public EventHandler<string> GeSelecteerd;
        public string SelectedValue { get; private set; }
        public string SelectedLabel { get; private set; }
        private List<ILijstItems> _alleItems;

        private bool skipTextChanged = false;

        public ZoekbareComboBox()
        {
            InitializeComponent();
            comboBox.IsDropDownOpen = false;

        }

        public void VoegLijstToe(List<ILijstItems> items)
        {
            comboBox.Items.Clear();
            _alleItems = items;
            foreach (ILijstItems item in items)
            {
                comboBox.Items.Add(item.ItemNaam);
            }
        }

        //private void listItemSelected(object sender, RoutedEventArgs e)
        //{
        //    throw new NotImplementedException();
        //}

        private void FilterLijst(List<ILijstItems> items)
        {
            //comboBox.ItemsSource = null; // Dit roept ook het selectionChanged event op daarom tijdelijke oplossing/
            comboBox.Items.Clear();
            foreach (ILijstItems item in items)
            {
                comboBox.Items.Add(item.ItemNaam);
            }
        }

        //filteren op text in box
        private void comboBox_TextChanged(object sender, TextChangedEventArgs e){
            if (!skipTextChanged)
            {
                if (string.IsNullOrWhiteSpace(comboBox.Text))
                {
                    FilterLijst(_alleItems);
                }
                else
                {
                    comboBox.IsDropDownOpen = true;
                    string text = comboBox.Text;
                    FilterLijst(FilterOp(text));
                }
            }
            skipTextChanged = false;
        }
        private List<ILijstItems> FilterOp(string zoekwoord)
        {
            List<ILijstItems> result = new List<ILijstItems>();
            foreach (ILijstItems w in _alleItems)
            {
                string woord = w.ItemNaam;
                bool gevonden = false;
                if (zoekwoord.Length <= woord.Length)
                {
                    for (int i = 0; i < zoekwoord.Length; i++)
                    {
                        if (Char.ToLower(zoekwoord[i]) == Char.ToLower(woord[i]))
                        {
                            gevonden = true;
                        }
                        else
                        {
                            gevonden = false;
                            break;
                        }
                    }
                    if (gevonden)
                    {
                        result.Add(w);
                    }
                }
            }
            return result;
        }


        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // TODO: elke keer als het SelectionChanged event wordt aangroepen wordt het comboBox_TextChanged ook aangeroepen
            // die dan opnieuw de SelectionChanged aaroept waarop dan een error volgt, momeneteel tijdelijk oplossing (_skipSelectionChangedEvent).
            // zie debugger voor meer info.
            //=> gefixt met een bool

            if ((e.AddedItems.Count > 0))
            {
                int SelectedIndex = comboBox.SelectedIndex;
                SelectedValue = _alleItems[SelectedIndex].Id;
                SelectedLabel = _alleItems[SelectedIndex].ItemNaam;
                if (GeSelecteerd != null)
                {
                    GeSelecteerd.Invoke(this, SelectedValue);
                }
            }

            skipTextChanged = true;
        }


    }

    
}
