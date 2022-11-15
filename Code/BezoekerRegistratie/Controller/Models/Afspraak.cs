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
        //public Bezoeker Bezoeker { get; set; }
        //public Werknemer Werknemer { get; set; }
        public DateTime StartTijd { get; set; }
        public DateTime? EindTijd { get; set; }
        public bool IsAanwezig = false;
        //public bool IsAanwezig { get; internal set; }

        public string BezoekerVoornaam { get; set; }
        public string BezoekerAchternaam { get; set; }
        public string BezoekerEmail { get; set; }
        public string WerknemerVoornaam { get; set; }
        public string WerknemerAchternaam { get; set; }
        public string WerknemerEmail { get; set; }

        public string Bedrijf { get; set; }

        //public string BezoekerNaam 
        //{ 
        //    get { return Bezoeker.GeefVolledigeNaam(); }

        //} 
        //public string WerknemerNaam
        //{
        //    get { return Bezoeker.GeefVolledigeNaam(); }

        //}

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

        public Afspraak(Bezoeker bezoeker, Werknemer werknemer, DateTime startTijd, DateTime? eindTijd) 
        {
            //Bezoeker = bezoeker;
            //Werknemer = werknemer;
            //StartTijd = startTijd;
            EindTijd = eindTijd;
            if (eindTijd is null)
            {
                IsAanwezig = true;
            }
        }

        public Afspraak(int id, string bVoornaam, string bAchternaam, string bEmail, string wVoornaam, string wAchternaam, string wEmail, string bedrijf,
            DateTime startTijd, DateTime? eindTijd) : this(bVoornaam, bAchternaam, bEmail, wVoornaam, wAchternaam, wEmail, bedrijf, startTijd, eindTijd)
        {
            Id = id;
            
        }



        ////Afspraak (string) , (DateTime)dataReader["startTijd"], (DateTime)dataReader["eindTijd"],(int)dataReader["werknemerId"],(int)dataReader["bezoekerId"];


        //// Als een afspraak geen eindtijd heeft betekend dit dat de bezoeker nog aan wezig is.
        //// 2 constructors voor als we uit de db afspraken willen halen die toch al een eindtijd hebben.

        //--------------------
        ////public Afspraak(int id, Bezoeker bezoeker, Werknemer werknemer, DateTime startTijd)
        ////{
        ////    Id = id;
        ////    Bezoeker = bezoeker;
        ////    Werknemer = werknemer;
        ////    StartTijd = startTijd;
        ////    //TODO: eindtijd kan  iet null zijn want een datetime is een non nullable value type!
        ////    EindTijd = null;
        ////    IsAanwezig = true;
        ////}
       //----------------------------
        //public Afspraak(int id, Bezoeker bezoeker, Werknemer werknemer, DateTime startTijd)
        //{
        //    Id = id;
        //    Bezoeker = bezoeker;
        //    Werknemer = werknemer;
        //    StartTijd = startTijd;
        //    //TODO: eindtijd kan  iet null zijn want een datetime is een non nullable value type!
        //    EindTijd = null;
        //    IsAanwezig = true;
        //}
        //_---------------------
        //public Afspraak(Bezoeker bezoeker, Werknemer werknemer, DateTime startTijd)
        //{
        //    Bezoeker = bezoeker;
        //    Werknemer = werknemer;
        //    StartTijd = startTijd;
        //    EindTijd = null;
        //    IsAanwezig = true;
        //}


        //public Afspraak(int id, Bezoeker bezoeker, Werknemer werknemer, DateTime startTijd, DateTime? eindTijd)
        //{
        //    Id = id;
        //    Bezoeker = bezoeker;
        //    Werknemer = werknemer;
        //    StartTijd = startTijd;
        //    EindTijd = eindTijd;
        //    IsAanwezig = false;
        //    if (eindTijd is null)
        //    {
        //        IsAanwezig = true;
        //    }

        //}



        //Afspraak((string)dataReader["voornaamBezoeker"], (string)dataReader["achternaamBezoeker"], (string)dataReader["bezoekerBedrijfsnaam"], (string)dataReader["email"], (DateTime)dataReader["startTijd"], (DateTime)dataReader["eindTijd"],(int)dataReader["werknemerId"]);
        /*public Afspraak(Bezoeker bezoeker, Werknemer werknemer, DateTime startTijd, DateTime? eindTijd, bool isAanwezig) : this(id, bezoeker, werknemer, startTijd, eindTijd)
        {
            IsAanwezig = isAanwezig;
        }*/

        public void EindeAfspraak()
        {
            EindTijd = DateTime.Now;
            
            
        }
       

    }
}