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
using System.Windows.Shapes;

namespace BezoekerRegistratie.Windows
{
    /// <summary>
    /// Interaction logic for VoegBedrijfToeWindow.xaml
    /// </summary>
    public partial class VoegBedrijfToeWindow : Window
    {
        private BezoekerController _bezoekerController;
        public VoegBedrijfToeWindow(BezoekerController bezoekerController)
        {
            _bezoekerController = bezoekerController;
            InitializeComponent();
            voegBedrijfToe.ButtonClick += VoegBedrijfToe;
        }

        private void VoegBedrijfToe(object? sender, EventArgs e)
        {
            // TODO: form methode maken, dynamishe correctie. 
            string n = naam.Text;
            string b = btw.Text;
            string em = email.Text;
            string ad = adres.Text;
            string tel = telefoon.Text;

            bool gelukt = _bezoekerController.VoegBedrijfToe(n, b, em, ad, tel);

            string bericht = "";
            if (gelukt)
            {
                bericht = "Bedrijf is toegevoegd.";
            }
            else
            {
                bericht = "ER is iets fout gegaan.";
            }
            MessageBox.Show(bericht, "/", MessageBoxButton.OK, MessageBoxImage.Information);
            Close();//TODO: niet sluiten als er een foute input is.

        }
    }
}
