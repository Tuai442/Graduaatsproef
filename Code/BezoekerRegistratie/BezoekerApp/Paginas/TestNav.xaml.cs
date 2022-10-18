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

namespace BezoekerApp.Paginas
{
    /// <summary>
    /// Interaction logic for TestNav.xaml
    /// </summary>
    public partial class TestNav : Page
    {
        public EventHandler<Page> NavigeerHandler;

        public TestNav()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TestNav2 testNav = new TestNav2();
            NavigeerHandler.Invoke(this, testNav);
        }
    }
}
