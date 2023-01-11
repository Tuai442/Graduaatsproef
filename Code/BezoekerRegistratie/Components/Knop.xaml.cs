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
    /// Interaction logic for Knop.xaml
    /// </summary>
    public partial class Knop : UserControl
    {

        //TODO: hoe werkt dit?
        #region Opmaak
        public int Breedte
        {
            get { return (int)GetValue(BreedteProperty); }
            set { SetValue(BreedteProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Breedte.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BreedteProperty =
            DependencyProperty.Register("Breedte", typeof(int), typeof(Knop), new PropertyMetadata(null));
        public int Hoogte
        {
            get { return (int)GetValue(HoogteProperty); }
            set { SetValue(HoogteProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Hoogte.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HoogteProperty =
            DependencyProperty.Register("Hoogte", typeof(int), typeof(Knop), new PropertyMetadata(null));
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(Knop), new PropertyMetadata(null));
        #endregion

        public EventHandler<EventArgs> ButtonClick;

        public Knop()
        {
            InitializeComponent();
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            ButtonClick.Invoke(this, new EventArgs());
        }
        //public static implicit operator Knop(Knop v)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
