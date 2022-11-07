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

namespace Components
{
    /// <summary>
    /// Interaction logic for ZoekbareComboBox.xaml
    /// </summary>
    public partial class ZoekbareComboBox : UserControl
    {

        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register("ItemsSource", typeof(IEnumerable), typeof(ZoekbareComboBox), new PropertyMetadata(new PropertyChangedCallback(OnItemsSourcePropertyChanged)));

        private static void OnItemsSourcePropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var control = sender as ZoekbareComboBox;
            if (control != null)
                control.OnItemsSourceChanged((IEnumerable)e.OldValue, (IEnumerable)e.NewValue);
        }

        private void OnItemsSourceChanged(IEnumerable oldValue, IEnumerable newValue)
        {
            // Remove handler for oldValue.CollectionChanged
            var oldValueINotifyCollectionChanged = oldValue as INotifyCollectionChanged;

            if (null != oldValueINotifyCollectionChanged)
            {
                oldValueINotifyCollectionChanged.CollectionChanged -= new NotifyCollectionChangedEventHandler(newValueINotifyCollectionChanged_CollectionChanged);
            }
            // Add handler for newValue.CollectionChanged (if possible)
            var newValueINotifyCollectionChanged = newValue as INotifyCollectionChanged;
            if (null != newValueINotifyCollectionChanged)
            {
                newValueINotifyCollectionChanged.CollectionChanged += new NotifyCollectionChangedEventHandler(newValueINotifyCollectionChanged_CollectionChanged);
            }

        }

        void newValueINotifyCollectionChanged_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            //Do your stuff here.
        }




        // Using a DependencyProperty as the backing store for Height.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HeightProperty =
            DependencyProperty.Register("Height", typeof(int), typeof(ZoekbareComboBox), new PropertyMetadata(null));


        public EventHandler<string> GeSelecteerd;

        public string SelectedValue { get; private set; }

        public string SelectedLabel { get; private set; }

        private List<ILijstItems> _alleItems;

        private bool _skipSelectionChangedEvent = false;
        public ZoekbareComboBox()
        {
            InitializeComponent();
            comboBox.IsDropDownOpen = true;

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

        private void listItemSelected(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        //private void FilterLijst(List<ILijstItem> items)
        //{
        //    _skipSelectionChangedEvent = true;
        //    comboBox.ItemsSource = null; // Dit roept ook het selectionChanged event op daarom tijdelijke oplossing/
        //    _skipSelectionChangedEvent = false;
        //    foreach (ILijstItem item in items)
        //    {
        //        comboBox.Items.Add(item.LabelNaam);
        //    }
        //}
      
        private void comboBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //if (string.IsNullOrWhiteSpace(comboBox.Text))
            //{
            //    FilterLijst(_alleItems);
            //}
            //else
            //{
            //    comboBox.IsDropDownOpen = true;
            //    string text = comboBox.Text;
            //    FilterLijst(FilterOp(text));
            //}
                
        }

        //private List<ILijstItem> FilterOp(string zoekwoord)
        //{
        //    List<ILijstItem> result = new List<ILijstItem>();
        //    foreach(ILijstItem w in _alleItems)
        //    {
        //        string woord = w.LabelNaam;
        //        bool gevonden = true;
        //        if (zoekwoord.Length <= woord.Length)
        //        {
        //            for (int i = 0; i < zoekwoord.Length; i++)
        //            {
        //                if (Char.ToLower(zoekwoord[i]) == Char.ToLower(woord[i]))
        //                {
        //                    gevonden = true;
        //                }
        //                else
        //                {
        //                    gevonden = false;
        //                    break;
        //                }
        //            }
        //            if (gevonden)
        //            {
        //                result.Add(w);
        //            }
        //        }
        //    }
        //    return result;
        //}

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // TODO: elke keer als het SelectionChanged event wordt aangroepen wordt het comboBox_TextChanged ook aangeroepen
            // die dan opnieuw de SelectionChanged aaroept waarop dan een error volgt, momeneteel tijdelijk oplossing (_skipSelectionChangedEvent).
            // zie debugger voor meer info.
            if (!_skipSelectionChangedEvent && (comboBox.SelectedIndex > 0))
            {
                int SelectedIndex = comboBox.SelectedIndex;
                SelectedValue = _alleItems[SelectedIndex].Id;
                SelectedLabel = _alleItems[SelectedIndex].ItemNaam;
                GeSelecteerd.Invoke(this, SelectedValue);
            }
            


        }


    }

    
}
