using Controller.Interfaces;
using Controller.Models;

namespace Controller
{
    public class Afspraak: ITabelData
    {
        public Bezoeker Bezoeker { get; set; }
        public string ContactPersoon { get; set; }

        public string Bedrijf { get; set; }
        public DateTime StartTijd { get; set; }
        public DateTime EindTijd { get; set; }

        public Afspraak(Bezoeker bezoeker, string contactPersoon, string bedrijf)
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
                $"Contact persoon: {ContactPersoon}\n" +
                $"Datum: {StartTijd.ToString()}\n" +
                $"Bedrijf: {Bedrijf}";
        }

        public object GeefTabelData()
        {
            object result = new
            {
                Bezoeker = Bezoeker.GeefVolledigeNaam(),
                ContactPersoon = ContactPersoon,
                Bedrijf = Bedrijf,
                StartTijd = StartTijd,
                EindTijd = EindTijd
            };
            return result;


        }
    }
}