using Controller.Exceptions;
using Controller.Managers;
using Controller.Models;
using Controllers;
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

namespace BeheerderApp.Windows
{
    /// <summary>
    /// Interaction logic for VoegBedrijfToe.xaml
    /// </summary>
    public partial class VoegBedrijfToe : Window
    {
        BedrijfManager _bedrijfManager;
        public VoegBedrijfToe(DomeinController controller)
        {
            try
            {
                _bedrijfManager = controller.GeefBedrijfManager();
                InitializeComponent();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string naam = naamTxtbox.Text;
            string email = emailTxtbox.Text;
            string btw = btwTxtbox.Text;
            string adres = adressTextbox.Text;
            string telefoon = telefoonTxtbox.Text;

            try
            {
                _bedrijfManager.VoegNieuwBedrijfToe(naam, btw, adres, telefoon, email);
                Close();
            }
            catch (ControleerException) { throw; }
            catch (Exception)
            {
                MessageBox.Show("Niet gelukt om bedrijf toe te voegen.");
            }
        }
    }
}
