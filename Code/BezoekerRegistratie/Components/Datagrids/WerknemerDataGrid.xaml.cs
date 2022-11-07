using Components.ViewModels;
using Controller.Models;
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

namespace Components.Datagrids
{
    /// <summary>
    /// Interaction logic for WerknemerDataGrid.xaml
    /// </summary>
    public partial class WerknemerDataGrid : UserControl
    {
        public EventHandler<string> OpZoekBalkVerandering;

        public WerknemerDataGrid()
        {
            InitializeComponent();
        }


        public void VerbindEventHanlder()
        {
            zoekbalk.OpZoekbalkVerandering += OpZoekBalkVerandering;

        }

        public void StelDataIn(List<WerknemerView> werknemerViews)
        {
            foreach (WerknemerView werknemer in werknemerViews)
            {
                dataGrid.Items.Add(werknemer);
            }
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dataGrid_CurrentCellChanged(object sender, EventArgs e)
        {

        }
    }
}
