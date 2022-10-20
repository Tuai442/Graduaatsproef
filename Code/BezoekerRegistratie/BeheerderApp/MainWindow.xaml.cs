using BeheerderApp.Paginas;
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

namespace BeheerderApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BeheerController _beheerController;

        public MainWindow(BeheerController beheerController)
        {
            _beheerController = beheerController;
            InitializeComponent();
            ToonHoofdMenu();
        }

        public void ToonHoofdMenu()
        {
            StartSchermBeheerder meldBezoekerAan = new StartSchermBeheerder(_beheerController);
            meldBezoekerAan.NavigeerHandler += NavigeerNaarPagina;
            mainFrame.Navigate(meldBezoekerAan);
        }

        // Alle navigatie worden via deze methode gedaan.
        private void NavigeerNaarPagina(object? sender, Page? page)
        {
            mainFrame.Navigate(page);
        }
    }
}
