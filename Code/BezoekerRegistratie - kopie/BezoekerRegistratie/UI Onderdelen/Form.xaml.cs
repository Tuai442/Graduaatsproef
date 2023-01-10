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

namespace BezoekerRegistratie.UI_Onderdelen
{
    /// <summary>
    /// Interaction logic for Form.xaml
    /// </summary>
    public partial class Form : UserControl
    {



        public string Titel
        {
            get { return (string)GetValue(TitelProperty); }
            set { SetValue(TitelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Titel.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitelProperty =
            DependencyProperty.Register("Titel", typeof(string), typeof(Form), new PropertyMetadata(null));




        public string Verzenden
        {
            get { return (string)GetValue(VerzendenProperty); }
            set { SetValue(VerzendenProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Verzenden.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty VerzendenProperty =
            DependencyProperty.Register("Verzenden", typeof(string), typeof(Form), new PropertyMetadata(null));

       
        public Form()
        {
            InitializeComponent();
        }

      
    }
}
