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
            logUitBtn.ButtonClick += LogUit;
            
        }
<<<<<<< HEAD
        
            
       

        private void LogIn(object? sender, EventArgs e)
        {
            //bool gelukt = _bezoekerController.MeldBezoekerAan(vn, an, "", "", ""); ???
=======

        private void LogUit(object? sender, EventArgs e)
        {
            TestNav test = new TestNav();
            test.NavigeerHandler = NavigeerHandler;
            NavigeerHandler.Invoke(this, test);
        }

        private void LogIn(object? sender, EventArgs e)
        {
            string vn = voornaam.Text.ToString();
            string an = achternaam.Text.ToString();
            bool gelukt = _bezoekerController.MeldBezoekerAan(vn, an, "", "", "", "");
>>>>>>> b083086f91a4ea7331bd1880c8a7011491f175ce

            string email = emailInvulveld.Text.ToString(); // vanaf deze is ingevuld een controle laten gebeuren. kijken in databank of er op dit moment iemand aanwezig is met dit email om de gegvens automatis aan te vullen zodat afmelden vlotter kan verlopen.
            string voornaam = voornaamInvulveld.Text.ToString();
            string achternaam = achternaamInvulveld.Text.ToString();
            string bedrijf = bedrijfInvulveld.Text.ToString();
            
          

            BedrijfSelecteren bs = new BedrijfSelecteren();
            NavigeerHandler.Invoke(this, bs);
        }

        private void voornaam_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void LogUit(object? sender, EventArgs e)
        {
            // controle indien alle gegevens ingevuld werden en gecontroleerd of deze persoon oorspronkelijk aanwezig was 
            MessageBox.Show("Beste bezoeker u bent succesvol afgemeld. Fijne dag nog!");

            // alle velden legen (mss een methode voor schrijven)


        }

    }
}
