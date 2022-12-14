using Components.ViewModels;
using Components.ViewModels.overige;
using Controller;
using Controller.Interfaces.Models;
using Controller.Models;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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
    public partial class ZoekbaarDataGrid : UserControl, INotifyPropertyChanged
    {
        public int GridHeight
        {
            get { return (int)GetValue(GridHeightProperty); }
            set { SetValue(GridHeightProperty, value); }
        }

        // Using a DependencyProperty as the backing store for GridHeight.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GridHeightProperty =
            DependencyProperty.Register("GridHeight", typeof(int), typeof(ZoekbaarDataGrid), new PropertyMetadata(null));

        private IEnumerable _data;
        public ZoekbaarDataGrid()
        {
            InitializeComponent();
            _data = new List<object>();
            dataGrid.ItemsSource = _data;
            

        }

        public EventHandler<object> OpDataVerandering;

        public EventHandler<string> OpDataFiltering;

        public event PropertyChangedEventHandler? PropertyChanged;

        public void StelDataIn<T>(IEnumerable viewModel, bool readOnly= false, IEnumerable extraInfo = null)
        {
            _data = viewModel;
            dataGrid.ItemsSource = null;
            MaakHoofding<T>(viewModel, extraInfo);
            dataGrid.ItemsSource = viewModel;
            dataGrid.IsReadOnly = true;
           
        }

        private void MaakHoofding<T>(IEnumerable viewModel, IEnumerable extraInfo = null)
        {
            dataGrid.Columns.Clear();
            Dictionary<string, string> hoofding = HoofdingManager.GeefHoofding<T>();
            Dictionary<string, CellType> cellTypes = CellManager.GeefCellType<T>();
            foreach (string key in hoofding.Keys)
            {
                if (cellTypes.ContainsKey(key))
                {
                    DataGridComboBoxColumn dataGridComboBoxColumn = new DataGridComboBoxColumn();
                    dataGridComboBoxColumn.Header = hoofding[key];

                    dataGridComboBoxColumn.ItemsSource = extraInfo;
                    dataGridComboBoxColumn.TextBinding = new Binding(key);
                    dataGridComboBoxColumn.DisplayMemberPath = "Naam";
                    dataGridComboBoxColumn.SelectedValuePath = "Naam";
                    dataGrid.Columns.Add(dataGridComboBoxColumn);

                }
                else
                {
                    DataGridTextColumn c = new DataGridTextColumn();
                    c.Header = hoofding[key];
                    c.Binding = new Binding(key);
                    dataGrid.Columns.Add(c);
                }
                
        
            }
            dataGrid.AutoGenerateColumns = false;
        }


        // Dit wordt opgeroepen vanaf er een verandering in de zoekbalk gebeurt.
        private void zoekBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Hier kunnen we ons datagrid filter op het huidige zoekwoord.
            string zoekText = zoekBar.Text;
            OpDataFiltering.Invoke(sender, zoekText);

        }

       
    }
}

