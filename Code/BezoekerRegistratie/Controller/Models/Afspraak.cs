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

        // --------------
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


        //Afspraak (string) , (DateTime)dataReader["startTijd"], (DateTime)dataReader["eindTijd"],(int)dataReader["werknemerId"],(int)dataReader["bezoekerId"];


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

    

        //Afspraak((string)dataReader["voornaamBezoeker"], (string)dataReader["achternaamBezoeker"], (string)dataReader["bezoekerBedrijfsnaam"], (string)dataReader["email"], (DateTime)dataReader["startTijd"], (DateTime)dataReader["eindTijd"],(int)dataReader["werknemerId"]);
        /*public Afspraak(Bezoeker bezoeker, Werknemer werknemer, DateTime startTijd, DateTime? eindTijd, bool isAanwezig) : this(id, bezoeker, werknemer, startTijd, eindTijd)
        {
            IsAanwezig = isAanwezig;
        }*/

        public void EindeAfspraak()
        {
            EindTijd = DateTime.Now;
            IsAanwezig = false;
            
        }
       

       

       
    }
}