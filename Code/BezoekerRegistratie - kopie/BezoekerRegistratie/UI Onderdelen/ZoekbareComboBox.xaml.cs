using BezoekerRegistratie.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

        // Using a DependencyProperty as the backing store for Height.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HeightProperty =
            DependencyProperty.Register("Height", typeof(int), typeof(ZoekbareComboBox), new PropertyMetadata(null));


        public string searchText;
        private List<string> _alleItems;

        public ZoekbareComboBox()
        {
            InitializeComponent();
        }

        public void InitItems(List<string> items)
        {
            comboBox.Items.Clear();
            _alleItems = items;
            foreach(string item in items)
            {
                comboBox.Items.Add(item);
            }
        }

       

        private void cb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            comboBox.IsDropDownOpen = true;
            string text = e.Text;
            
            List<string> zoekRezultaten = ZoekMachine.ZoekWoordInLijst(text, _alleItems);
            RefreshItems(zoekRezultaten);
        }

        private void RefreshItems(List<string> items)
        {
            comboBox.Items.Clear();
            foreach (string item in items)
            {
                comboBox.Items.Add(item);
            }
        }

        private void comboBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(comboBox.Text))
            {
                InitItems(_alleItems);
            }
        }
    }
}
