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
    /// Interaction logic for BezoekersDataGrid.xaml
    /// </summary>
    public partial class BezoekersDataGrid : UserControl
    {
        public EventHandler<string> OpZoekBalkVerandering;
        public BezoekersDataGrid()
        {
            InitializeComponent();

        }

        public void VerbindEventHanlder()
        {

        }

        public void StelDataIn(IReadOnlyList<Bezoeker> bezoekers)
        {
            foreach (Bezoeker bezoeker in bezoekers)
            {
                dataGrid.Items.Add(bezoeker);
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
