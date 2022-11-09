using Components.Interfaces;
using Controller.Managers;
using Controller.Models;
using Controllers;
using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Reflection;
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

namespace BeheerderApp.Windows
{
    /// <summary>
    /// Interaction logic for VoegWerknemerToeWindow.xaml
    /// </summary>
    public partial class VoegWerknemerToeWindow : Window
    {
        DomeinController _controller;
        BedrijfManager _bedrijfManager;
        WerknemerManager _werknemerManager;
        public List<ILijstItems> Bedrijven;
        public VoegWerknemerToeWindow(DomeinController controller, List<ILijstItems> bedrijven)
        {
            _controller = controller;
            _bedrijfManager = controller.GeefBedrijfManager();
            _werknemerManager = controller.GeefWerknemerManager();

            Bedrijven = bedrijven;
            InitializeComponent();
            bedrijfCombobox.VoegLijstToe(bedrijven);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            string voornaam = voornaamTxtbox.Text;
            string achternaam = achternaamTxtbox.Text;
            string functie =  functieTxtbox.Text;
            string bedrijfEmail = (string)bedrijfCombobox.SelectedValue; // email ??
            string email = emailTxtbox.Text;

            try
            {
                Bedrijf bedrijf = _bedrijfManager.GeefBedrijfOpEmail(bedrijfEmail);
                _werknemerManager.VoegWerknemerToe(voornaam, achternaam, email, functie, bedrijf);
                Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            


        }
        
    }
}
