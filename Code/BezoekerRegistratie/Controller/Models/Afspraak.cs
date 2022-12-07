using Controller.Interfaces;
using Controller.Interfaces.Models;
using Controller.Models;
using System.ComponentModel;
using System.Security.Cryptography;

namespace Controller
{
    public class Afspraak
    {
        public int Id { get; set; }
        public DateTime StartTijd { get; set; }
        public DateTime? EindTijd { get; set; }
        public bool IsAanwezig = false;

        public string BezoekerVoornaam { get; set; }
        public string BezoekerAchternaam { get; set; }
        public string BezoekerEmail { get; set; }
        public string WerknemerVoornaam { get; set; }
        public string WerknemerAchternaam { get; set; }
        public string WerknemerEmail { get; set; }
        public string Bedrijf { get; set; }

        public Afspraak(string bVoornaam, string bAchternaam, string bEmail, string wVoornaam, string wAchternaam, string wEmail, string bedrijf,
            DateTime startTijd, DateTime? eindTijd)
        {
            
            BezoekerVoornaam = bVoornaam;
            BezoekerAchternaam = bAchternaam;
            BezoekerEmail = bEmail;
            WerknemerVoornaam = wVoornaam;
            WerknemerAchternaam = wAchternaam;
            WerknemerEmail = wEmail;
            Bedrijf = bedrijf;

        }

        public Afspraak(int id, string bVoornaam, string bAchternaam, string bEmail, string wVoornaam, string wAchternaam, string wEmail, string bedrijf,
            DateTime startTijd, DateTime? eindTijd) : this(bVoornaam, bAchternaam, bEmail, wVoornaam, wAchternaam, wEmail, bedrijf, startTijd, eindTijd)
        {
            Id = id;
            
        }

        public void EindeAfspraak()
        {
            EindTijd = DateTime.Now;
            
            
        }
       

    }
}