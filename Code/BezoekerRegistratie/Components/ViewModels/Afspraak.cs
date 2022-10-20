using Controller.Interfaces;
using Controller.Models;
using System;

namespace Controller
{
    public class Afspraak: ITabelData
    {
        public Bezoeker Bezoeker { get; set; }
        public Werknemer ContactPersoon { get; set; }

        public Bedrijf Bedrijf { get; set; }
        public DateTime StartTijd { get; set; }
        public DateTime EindTijd { get; set; }

        public Afspraak(Bezoeker bezoeker, Werknemer contactPersoon, Bedrijf bedrijf)
        {
            Bezoeker = bezoeker;
            ContactPersoon = contactPersoon;
            Bedrijf = bedrijf;
            StartTijd = DateTime.Now;
        }
       
        public void EindeAfspraak()
        {
            EindTijd = DateTime.Now;
        }
        public override string? ToString()
        {
            return $"{Bezoeker.GeefVolledigeNaam()}\n" +
                $"Contact persoon: {ContactPersoon.GeefVolledigeNaam()}\n" +
                $"Datum: {StartTijd.ToString()}\n" +
                $"Bedrijf: {Bedrijf.Naam}";
        }

        public object GeefTabelData()
        {
            object result = new
            {
                Bezoeker = Bezoeker.GeefVolledigeNaam(),
                ContactPersoon = ContactPersoon.GeefVolledigeNaam(),
                Bedrijf = Bedrijf,
                StartTijd = StartTijd,
                EindTijd = EindTijd
            };
            return result;


        }
    }
}