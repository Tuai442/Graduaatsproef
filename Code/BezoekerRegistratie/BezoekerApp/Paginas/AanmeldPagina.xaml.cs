using Controller;
using Controller.Models;
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
        BezoekerController _bezoekerController;
        private static System.Timers.Timer _timer;

        public EventHandler<Page> NavigeerHandler;

        public AanmeldPagina(BezoekerController bezoekerController)
        {
            _bezoekerController = bezoekerController;
            InitializeComponent();

            logInBtn.ButtonClick += LogIn;
            logUitBtn.ButtonClick += LogUit;

        }

        private void LogIn(object? sender, EventArgs e)
        {
            BedrijfSelecteren bs = new BedrijfSelecteren(_bezoekerController); // Zouden we dit nie beter op één pagina zetten?
            bs.AanmeldHandler += MeldBezoekerAan;
            NavigeerHandler.Invoke(this, bs);
        }

        private void MeldBezoekerAan(object? sender, Dictionary<string, string> e)
        {
            string email = emailInvulveld.Text; // vanaf deze is ingevuld een controle laten gebeuren. kijken in databank of er op dit moment iemand aanwezig is met dit email om de gegvens automatis aan te vullen zodat afmelden vlotter kan verlopen.
            string voornaam = voornaamInvulveld.Text;
            string achternaam = achternaamInvulveld.Text;
            string bedrijf = e["bedrijf"];
            string contactPersoon = e["contact-persoon"];


            Bericht bericht = _bezoekerController.MeldBezoekerAan(voornaam, achternaam, email,
                contactPersoon, contactPersoon, bedrijf);

            MessageBox.Show(bericht.Inhoud);
            if (bericht.Status)
            {
                LeegAlleVelden();
            }
            NavigeerHandler.Invoke(this, this);
        }

        private void LogUit(object? sender, EventArgs e)
        {
            string email = emailInvulveld.Text;
            bool gelukt = _bezoekerController.MeldBezoekerUit(email);

            if (gelukt)
            {
                MessageBox.Show("Je bent afgemeld.");
                LeegAlleVelden();
            }
            else
            {
                MessageBox.Show("Je was niet aanwezig, dus kunnen we je niet afmelden");
            }
            


        }

        private void LeegAlleVelden()
        {
            emailInvulveld.Text = ""; 
            voornaamInvulveld.Text = "";
            achternaamInvulveld.Text = "";
        }
    }
}
