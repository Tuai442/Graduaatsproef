
using BezoekerRegistratie.Paginas;
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

namespace BezoekerRegistratie
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BezoekerController _bezoekerController;
        private BeheerController _beheerController;
        
        public MainWindow(BezoekerController bezoekerController, BeheerController beheerController)
        {
            _bezoekerController = bezoekerController;
            _beheerController = beheerController;
            InitializeComponent();
            ToonHoofdMenu();
        }

        public void ToonHoofdMenu()
        {
            HoofdMenu hoofdMenu = new HoofdMenu(_beheerController, _bezoekerController);
            hoofdMenu.NavigeerHandler += NavigeerNaarPagina;
            mainFrame.Navigate(hoofdMenu);
        }

        // Alle navigatie worden via deze methode gedaan.
        private void NavigeerNaarPagina(object? sender, Page? page)
        {
            mainFrame.Navigate(page);
        }

        



    }
}
