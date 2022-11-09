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
    /// Interaction logic for Zoekbalk.xaml
    /// </summary>
    public partial class Zoekbalk : UserControl
    {
        public EventHandler<string> OpZoekbalkVerandering;
        public Zoekbalk()
        {
            InitializeComponent();
        }

        private void zoekBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            OpZoekbalkVerandering?.Invoke(sender, zoekBar.Text);
        }
    }
}
