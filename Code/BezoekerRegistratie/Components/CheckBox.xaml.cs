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

namespace Components
{
    /// <summary>
    /// Interaction logic for CheckBox.xaml
    /// </summary>
    public partial class CheckBox : UserControl
    {
        public int X
        {
            get { return (int)GetValue(XProperty); }
            set { SetValue(XProperty, value); }
        }

        // Using a DependencyProperty as the backing store for X.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty XProperty =
            DependencyProperty.Register("X", typeof(int), typeof(CheckBox), new PropertyMetadata(null));

        public int Y
        {
            get { return (int)GetValue(YProperty); }
            set { SetValue(YProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Y.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty YProperty =
            DependencyProperty.Register("Y", typeof(int), typeof(CheckBox), new PropertyMetadata(null));

        // Using a DependencyProperty as the backing store for Height.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HeightProperty =
            DependencyProperty.Register("Height", typeof(int), typeof(CheckBox), new PropertyMetadata(null));

        public string TText
        {
            get { return (string)GetValue(TTextProperty); }
            set { SetValue(TTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TTextProperty =
            DependencyProperty.Register("TText", typeof(string), typeof(CheckBox), new PropertyMetadata(null));


       

        public string Value
        {
            get { return (string)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(string), typeof(CheckBox), new PropertyMetadata(null));

        
        public EventHandler<bool> Checked;
        public bool IsActief { get; set; }
        public SolidColorBrush defautlColor { get; set; }
        public SolidColorBrush checkedColor { get; set; }
        public CheckBox()
        {
            IsActief = false;
            defautlColor = new SolidColorBrush(Colors.LightSteelBlue);
            checkedColor = new SolidColorBrush(Colors.CadetBlue);
            InitializeComponent();
            bgColor.Background = defautlColor;

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (IsActief)
            {
                bgColor.Background = defautlColor;
                IsActief = false;
                Checked.Invoke(this, IsActief);
            }
            else
            {
                bgColor.Background = checkedColor;
                IsActief = true;
                Checked.Invoke(this, IsActief);
            }
        }

        public void DeActiveer()
        {
            IsActief = false;
            bgColor.Background = defautlColor;
        }

        public void Activeer()
        {
            IsActief = true;
            bgColor.Background = checkedColor;
        }
    }
}
