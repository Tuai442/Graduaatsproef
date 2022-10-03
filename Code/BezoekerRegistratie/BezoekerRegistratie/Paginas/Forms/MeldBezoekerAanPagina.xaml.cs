using Controller;
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

namespace BezoekerRegistratie.Paginas
{
    /// <summary>
    /// Interaction logic for MeldBezoekerAanPagina.xaml
    /// </summary>
    public partial class MeldBezoekerAanPagina : Page
    {
        BezoekerController _bezoekerController;
        public MeldBezoekerAanPagina(BezoekerController bezoekerController)
        {
            _bezoekerController = bezoekerController;   
            InitializeComponent();
            logInBtn.ButtonClick += LogIn;
        }

        private void LogIn(object? sender, EventArgs e)
        {
            string vn = voornaam.Text.ToString() ;
            string an = achternaam.Text.ToString();
            string ww = "";
            bool gelukt = _bezoekerController.LogBezoekerIn(vn, an, ww);

            string text = "";
            if (gelukt) 
            {
                text = "Je ben ingelogt";
            }
            else
            {
                text = "Je kan niet inloggen";
            }
            MessageBox.Show(text, "/", MessageBoxButton.OK, MessageBoxImage.Information);
            
            
        }
    }
}
