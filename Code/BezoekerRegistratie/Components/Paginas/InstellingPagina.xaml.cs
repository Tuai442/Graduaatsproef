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

namespace Components.Paginas
{
    /// <summary>
    /// Interaction logic for InstellingPagina.xaml
    /// </summary>
    public partial class InstellingPagina : Page
    {



        public SolidColorBrush achtergrond
        {
            get { return (SolidColorBrush)GetValue(achtergrondProperty); }
            set { SetValue(achtergrondProperty, value); }
        }

        // Using a DependencyProperty as the backing store for achtergrond.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty achtergrondProperty =
            DependencyProperty.Register("achtergrond", typeof(SolidColorBrush), typeof(InstellingPagina), new PropertyMetadata(new SolidColorBrush(Colors.LightSteelBlue)));


        public EventHandler<Page> NavigeerHandler;
        public InstellingPagina()
        {
            InitializeComponent();
        }
    }
}
