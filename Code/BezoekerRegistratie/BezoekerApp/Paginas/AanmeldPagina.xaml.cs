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

namespace BezoekerApp.Paginas
{
    /// <summary>
    /// Interaction logic for AanmeldPagina.xaml
    /// </summary>
    public partial class AanmeldPagina : UserControl
    {
        BezoekerController _bezoekerController;
        public EventHandler<Page> NavigeerHandler;

        public AanmeldPagina(BezoekerController bezoekerController)
        {
            _bezoekerController = bezoekerController;
            InitializeComponent();

            logInBtn.ButtonClick += LogIn;
        }

        private void LogIn(object? sender, EventArgs e)
        {
            string vn = voornaam.Text.ToString();
            string an = achternaam.Text.ToString();
            bool gelukt = _bezoekerController.MeldBezoekerAan(vn, an, "", "", "");

            string text = "";

            // TODO: betere melding
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
