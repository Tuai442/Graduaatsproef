using Controller.Models;

namespace Controller
{
    public class Afspraak
    {
        public Bezoeker Bezoeker { get; set; }
        public Werknemer ContactPersoon { get; set; }

        public Bedrijf Bedrijf { get; set; }
        public DateTime StartTijd { get; set; }

        public Afspraak(Bezoeker bezoeker, Werknemer contactPersoon, Bedrijf bedrijf, DateTime startTijd)
        {
            Bezoeker = bezoeker;
            ContactPersoon = contactPersoon;
            Bedrijf = bedrijf;
            StartTijd = startTijd;
        }
        public bool ControleStartTijd(DateTime startTijd)
        {
            // TODO: Contole start datum geldig datum
            return true;
        }

        public override string? ToString()
        {
            return $"{Bezoeker.GeefVolledigeNaam()}\n" +
                $"Contact persoon: {ContactPersoon.GeefVolledigeNaam()}\n" +
                $"Datum: {StartTijd.ToString()}\n" +
                $"Bedrijf: {Bedrijf.Naam}";
        }
    }
}