using Controller.Interfaces;
using Controller.Interfaces.Models;
using Controller.Models;
using System.Security.Cryptography;

namespace Controller
{
    public class Afspraak: IAfspraak
    {
        public int Id { get; set; }
        public Bezoeker Bezoeker { get; set; }
        public Werknemer Werknemer { get; set; }
        public DateTime StartTijd { get; set; }
        public DateTime? EindTijd { get; set; }
        public bool IsAanwezig { get; internal set; }

        // --------------
        public string BezoekerNaam 
        { 
            get { return Bezoeker.GeefVolledigeNaam(); }
           
        } 
        public string WerknemerNaam
        {
            get { return Bezoeker.GeefVolledigeNaam(); }

        }


        // Als een afspraak geen eindtijd heeft betekend dit dat de bezoeker nog aan wezig is.
        // 2 constructors voor als we uit de db afspraken willen halen die toch al een eindtijd hebben.
        public Afspraak(int id, Bezoeker bezoeker, Werknemer werknemer, DateTime startTijd)
        {
            Id = id;
            Bezoeker = bezoeker;
            Werknemer = werknemer;
            StartTijd = startTijd;
            EindTijd = null;
            IsAanwezig = true;
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
            EindTijd = DateTime.Now;
            IsAanwezig = false;
            
        }
       

        public object GeefItemSource()
        {
            //Dictionary<string, string> result = new Dictionary<string, string>()
            //{
            //    { "Voornaam" , Bezoeker.Voornaam },

            //};
            object result = new
            {
                Voornaam = Bezoeker.Voornaam,
                Achternaam = Bezoeker.Achternaam,
                Email = Bezoeker.Email,
                IsAanwezig = IsAanwezig,

                BedrijfBezoeker = Bezoeker.Bedrijf.ToString(),
                StartTijd = StartTijd,
                EindTijd = EindTijd,

                VoornaamContactPersoon = Werknemer.Voornaam,
                AchternaamContactPersoon = Werknemer.Achternaam,
                BedrijfContactPersoon = Werknemer.Bedrijf.ToString(),
            };
            return result;
        }

       
    }
}