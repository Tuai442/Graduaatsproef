using Controller;
using Controller.Interfaces.Models;
using Controller.Managers;
using Controller.Models;
using Controllers;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
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
    public partial class AanmeldPagina : Page
    {
        DomeinController _domeinController;
        private BezoekerManager _bezoekerManger;
        public EventHandler<Page> NavigeerHandler;
        public AanmeldPagina(DomeinController bezoekerController)
        {
            InitializeComponent();
            _domeinController = bezoekerController;
            _bezoekerManger = _domeinController.GeefBezoekerManager();


            logInBtn.ButtonClick += LogIn;
            logUitBtn.ButtonClick += LogUit;

        }
        private void LogIn(object? sender, EventArgs e)
        {
            BedrijfSelecteren bs = new BedrijfSelecteren(_domeinController); // Zouden we dit nie beter op één pagina zetten?
            bs.AanmeldHandler += MeldBezoekerAan;
            NavigeerHandler.Invoke(this, bs);
        }
        private void LogUit(object? sender, EventArgs e)
        {
            string email = emailInvulveld.Text;

            try
            {
                _bezoekerManger.MeldBezoekerUit(email);
                MessageBox.Show("Prettige dag nog");
                LeegAlleVelden();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        private void MeldBezoekerAan(object? sender, Dictionary<string, Dictionary<string, string>> dict)
        {
            string email = emailInvulveld.Text;
            string voornaam = voornaamInvulveld.Text;
            string achternaam = achternaamInvulveld.Text;
            string bedrijfB = bedrijfInvulveld.Text;
            string contactPersoonEmail = dict["contact-persoon"]["value"];
            string bedrijfCp = dict["contact-persoon"]["naam"];

            try
            {
                _bezoekerManger.MeldBezoekerAan(voornaam, achternaam,
                    email, bedrijfB, contactPersoonEmail);
                MessageBox.Show("U bent succesvol ingelogd.");
                LeegAlleVelden();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Foute ingave", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            finally
            {
                NavigeerHandler.Invoke(this, this);
            }

        }


        private void LeegAlleVelden()
        {
            emailInvulveld.Text = "E-mail";
            voornaamInvulveld.Text = "Voornaam";
            achternaamInvulveld.Text = "Achternaam";
            bedrijfInvulveld.Text = "Bdrijf";
        }
        private void emailInvulveld_LostFocus(object sender, RoutedEventArgs e)
        {
            string email = emailInvulveld.Text;

            if (!string.IsNullOrEmpty(email))
            {
                Bezoeker bezoeker = _bezoekerManger.ZoekBezoekerOpEmail(email);
                if (bezoeker != null)
                {
                    achternaamInvulveld.Text = bezoeker.Achternaam;
                    voornaamInvulveld.Text = bezoeker.Voornaam;
                    bedrijfInvulveld.Text = bezoeker.Bedrijf;
                }

            }
            else if (emailInvulveld.Text == "")
            {
                emailInvulveld.Text = "E-mail";
            }
        }
        private void emailInvulveld_GotFocus(object sender, RoutedEventArgs e)
        {
            if (emailInvulveld.Text.Trim() == "E-mail")
                emailInvulveld.Clear();
        }
        private void bedrijfInvulveld_GotFocus(object sender, RoutedEventArgs e)
        {
            if (bedrijfInvulveld.Text.Trim() == "Bedrijf")
                bedrijfInvulveld.Clear();
        }
        private void voornaamInvulveld_GotFocus(object sender, RoutedEventArgs e)
        {
            if (voornaamInvulveld.Text.Trim() == "Voornaam")
                voornaamInvulveld.Clear();
        }
        private void achternaamInvulveld_GotFocus(object sender, RoutedEventArgs e)
        {
            if (achternaamInvulveld.Text.Trim() == "Achternaam")
                achternaamInvulveld.Clear();
        }
        private void achternaamInvulveld_LostFocus(object sender, RoutedEventArgs e)
        {
            if (achternaamInvulveld.Text == "")
            {
                achternaamInvulveld.Text = "Achternaam";
            }
        }
        private void voornaamInvulveld_LostFocus(object sender, RoutedEventArgs e)
        {
            if (voornaamInvulveld.Text == "")
            {
                voornaamInvulveld.Text = "Voornaam";
            }
        }
        private void bedrijfInvulveld_LostFocus(object sender, RoutedEventArgs e)
        {
            if (bedrijfInvulveld.Text == "")
            {
                bedrijfInvulveld.Text = "Bedrijf";
            }

        }

    }
}
