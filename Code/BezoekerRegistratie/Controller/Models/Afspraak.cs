using Controller.Interfaces;
using Controller.Interfaces.Models;
using Controller.Models;

namespace Controller
{
    public class Afspraak: IAfspraak
    {
        public string Email { get; set; }
        public string ContactPersoon { get; set; }
        public string Naam { get; set; }
        public string Bedrijf { get; set; }
        public DateTime StartTijd { get; set; }
        public DateTime EindTijd { get; set; }

        public Afspraak(string email, string naam, string contactPersoon, string bedrijf)
        {
            Email = email;
            Naam = naam;
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
            return $"Naam: {Naam}\n" +
                    $"Contact persoon: {ContactPersoon}\n" +
                    $"Datum: {StartTijd.ToString()}\n" +
                    $"Bedrijf: {Bedrijf}";
        }

        public object GeefItemSource()
        {
            object result = new
            {
                Naam = Naam,
                Email = Email,
                ContactPersoon = ContactPersoon,
                Bedrijf = Bedrijf,
                StartTijd = StartTijd,
                EindTijd = EindTijd
            };
            return result;
        }
    }
}