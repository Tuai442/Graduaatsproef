﻿using BezoekerApp.Paginas;
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

namespace BezoekerApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BezoekerController _bezoekerController;

        public MainWindow(BezoekerController bezoekerController )
        {
            _bezoekerController = bezoekerController;
            InitializeComponent();
            ToonHoofdMenu();
        }

        public void ToonHoofdMenu()
        {
            AanmeldPagina meldBezoekerAan = new AanmeldPagina(_bezoekerController);
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
