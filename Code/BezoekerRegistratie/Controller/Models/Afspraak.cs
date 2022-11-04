using Controller.Interfaces;
using Controller.Interfaces.Models;
using Controller.Models;
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

        public string V1 { get; }
        public string V2 { get; }
        public string V3 { get; }
        public string V4 { get; }
        public DateTime DateTime1 { get; }
        public DateTime DateTime2 { get; }
        public int V5 { get; }

        //Afspraak((string)dataReader["voornaamBezoeker"], (string)dataReader["achternaamBezoeker"], (string)dataReader["bezoekerBedrijfsnaam"], (string)dataReader["email"], (DateTime)dataReader["startTijd"], (DateTime)dataReader["eindTijd"],(int)dataReader["werknemerId"]);


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

        public Afspraak(string v1, string v2, string v3, string v4, DateTime dateTime1, DateTime dateTime2, int v5)
        {
            V1 = v1;
            V2 = v2;
            V3 = v3;
            V4 = v4;
            DateTime1 = dateTime1;
            DateTime2 = dateTime2;
            V5 = v5;
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