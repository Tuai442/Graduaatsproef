using Controller.Interfaces;
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

        public void GenereerTable(List<object> data)
        {
            if(data.Count != 0)
            {
                _dataGrid.ItemsSource = new List<object>();

                _dataGrid.ItemsSource = data;
            }


        }
    }
}
