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
        public Bezoeker Bezoeker { get; set; }
        public Werknemer Werknemer { get; set; }
        public DateTime StartTijd { get; set; }
        public DateTime? EindTijd { get; set; }
        public bool IsAanwezig { get; internal set; }

        public string BezoekerNaam
        {
            get { return Bezoeker.GeefVolledigeNaam(); }

        }
        public string WerknemerNaam
        {
            get { return Bezoeker.GeefVolledigeNaam(); }

        }

        public Afspraak(Bezoeker bezoeker, Werknemer werknemer, DateTime startTijd, DateTime? eindTijd)
        {
            Bezoeker = bezoeker;
            Werknemer = werknemer;
            EindTijd = eindTijd;
            StartTijd = startTijd;
        }

        public Afspraak(Bezoeker bezoeker, Werknemer werknemer, DateTime startTijd)
        {
            Bezoeker = bezoeker;
            Werknemer = werknemer;
            StartTijd = startTijd;
            EindTijd = null;
            IsAanwezig = true;
        }
        public Afspraak(int id, Bezoeker bezoeker, Werknemer werknemer, DateTime startTijd, DateTime? eindTijd)
        {
            Id = id;
            Bezoeker = bezoeker;
            Werknemer = werknemer;
            StartTijd = startTijd;
            EindTijd = eindTijd;
            IsAanwezig = false;
            if (eindTijd is null)
            {
                IsAanwezig = true;
            }

        }


        public void EindeAfspraak()
        {
            
                Bezoeker.MeldAf();
                EindTijd = DateTime.Now;
                IsAanwezig = false;
            

        }

        public override string? ToString()
        {

            return $"{Bezoeker} - {Werknemer} - {Werknemer.Bedrijf}";  
        }
       
    }
}