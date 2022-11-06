using Controller;
using Controller.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Components.ViewModels
{
    public class AfspraakView
    {

        public int Id { get; set; }

        [Hoofding("Start Tijd")]
        public DateTime StartTijd { get; set; }

        [Hoofding("Eind Tijd")]
        public DateTime? EindTijd { get; set; }

        [Hoofding("Is aanwezig")]
        public bool IsAanwezig { get; internal set; }

        // --------------
        [Hoofding("Bezoekers Naam")]
        public string BezoekerNaam
        {
            get { return Afspraak.Bezoeker.GeefVolledigeNaam(); }
            set { }
        }
        [Hoofding("Werknemer Naam")]
        public string WerknemerNaam
        {
            get { return Afspraak.Werknemer.GeefVolledigeNaam(); }
            set { }
        }

        public Afspraak Afspraak { get; set; }
        public AfspraakView(Afspraak afspraak)
        {
            Afspraak = afspraak;

            StartTijd = Afspraak.StartTijd;
            EindTijd = Afspraak.EindTijd;
            IsAanwezig = Afspraak.IsAanwezig;
            BezoekerNaam = Afspraak.BezoekerNaam;
            WerknemerNaam = Afspraak.WerknemerNaam;
        }
    }
}
