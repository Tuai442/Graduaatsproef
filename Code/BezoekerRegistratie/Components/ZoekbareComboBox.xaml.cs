using Accessibility;
using Components.Models;
using Controller.Interfaces;
using Newtonsoft.Json.Linq;
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

namespace Components
{
    /// <summary>
    /// Interaction logic for ZoekbareComboBox.xaml
    /// </summary>
    public partial class ZoekbareComboBox : UserControl
    {
        public int Width
        {
            get { return (int)GetValue(WidthProperty); }
            set { SetValue(WidthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Width.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WidthProperty =
            DependencyProperty.Register("Width", typeof(int), typeof(ZoekbareComboBox), new PropertyMetadata(null));

        public int Height
        {
            get { return (int)GetValue(HeightProperty); }
            set { SetValue(HeightProperty, value); }
        }
        
        public bool ListItemSelected { get; private set; }

        // Using a DependencyProperty as the backing store for Height.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HeightProperty =
            DependencyProperty.Register("Height", typeof(int), typeof(ZoekbareComboBox), new PropertyMetadata(null));


        public EventHandler<string> GeSelecteerd;

        public string SelectedValue { get; private set; }

        public string SelectedLabel { get; private set; }

        private List<ILijstItem> _alleItems;

        private bool _skipSelectionChangedEvent = false;
        public ZoekbareComboBox()
        {
            InitializeComponent();
            comboBox.IsDropDownOpen = true;

        }

        public void VoegLijstToe(List<ILijstItem> items)
        {
            // Itemsource wordt gebruik zodat bij het filteren van data de index steeds overeenkomt.
            comboBox.ItemsSource = null;
            if (comboBox.Items.Count > 0)
            {
                comboBox.Items.Clear();
            }
            comboBox.ItemsSource = items.Select(x => x.LabelNaam);
            _alleItems = items;
        }

        private void listItemSelected(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void FilterLijst(List<ILijstItem> items)
        {
            _skipSelectionChangedEvent = true;
            comboBox.ItemsSource = null; // Dit roept ook het selectionChanged event op daarom tijdelijke oplossing/
            _skipSelectionChangedEvent = false;
            foreach (ILijstItem item in items)
            {
                comboBox.Items.Add(item.LabelNaam);
            }
        }
      
        private void comboBox_TextChanged(object sender, TextChangedEventArgs e)
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

        private List<ILijstItem> FilterOp(string zoekwoord)
        {
            List<ILijstItem> result = new List<ILijstItem>();
            foreach(ILijstItem w in _alleItems)
            {
                string woord = w.LabelNaam;
                bool gevonden = true;
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
            if (!_skipSelectionChangedEvent)
            {
                int SelectedIndex = comboBox.SelectedIndex;
                SelectedValue = _alleItems[SelectedIndex].Waarde;
                SelectedLabel = _alleItems[SelectedIndex].LabelNaam; 
                GeSelecteerd.Invoke(this, SelectedValue);
            }
            


        }


    }
}
