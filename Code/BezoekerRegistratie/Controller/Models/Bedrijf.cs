using Controller.Interfaces;
using Controller.Interfaces.Models;

namespace Controller.Models
{
    public class Bedrijf: IBedrijf, ILijstItem
    {
        public int Id { get; set; }
        public string  Naam { get; set; }
        public string Btw { get; set; }
        public string Adres { get; set; }
        public string Telefoon { get; set; }
        public string Email { get; set; }


        // ListItems
        public string LabelNaam => Naam;

        public string Waarde => Email;


        public Bedrijf(string naam, string btw, string adres, string telefoon, string email)
        {
            Naam = naam;
            Btw = btw;
            Adres = adres;
            Telefoon = telefoon;
            Email = email;
        }
        public Bedrijf(int id, string naam, string btw, string adres, string telefoon, string email)
        {
            Id = id;
            Naam = naam;
            Btw = btw;
            Adres = adres;
            Telefoon = telefoon;
            Email = email;
        }

        public bool ControleTelefoon(string telefoon)
        {
            // TODO: Controlleer telfoon nr door regulire expresies;
            return true;
        }

        public bool ControleBTW(string btw)
        {
            // TODO: Controlleer BTW door regulire expresies;
            return true;
        }
        public bool ControleEmail(string email) // We kunnen kijken voor dit anders aan te pakken want bij de Bezoeker moet er ook gecontroleerd worden op een email.
        {
            // TODO: Controlleer BTW door regulire expresies;
            return true;
        }

        public static List<string> GeefAttributen()
        {
            return new List<string>
            {
                "Naam",
                "Btw",
                "Adres",
                "Telefoon",
                "Email",
                "Parking Contract"
            };
        }

        public object GeefItemSource()
        {
            object result = new
            {
                Naam = Naam,
                Btw = Btw,
                Adres = Adres,
                telefoon = Telefoon,
                email = Email
            };
            return result;
        }
        public override string? ToString()
        {
            return Naam;
        }
    }
}