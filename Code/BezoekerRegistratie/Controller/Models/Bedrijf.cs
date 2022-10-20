using Controller.Interfaces;

namespace Controller.Models
{
    public class Bedrijf: ITabelData
    {
        public string  Naam { get; set; }
        public string Btw { get; set; }
        public string Adres { get; set; }
        public string telefoon { get; set; }
        public string email { get; set; }
        public ParkingContract ParkingContract { get; set; }

        public Bedrijf(string naam, string btw, string adres, string telefoon, string email)
        {
            Naam = naam;
            Btw = btw;
            Adres = adres;
            this.telefoon = telefoon;
            this.email = email;
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

        public object GeefTabelData()
        {
            object result = new
            {
                Naam = Naam,
                Btw = Btw,
                Adres = Adres,
                telefoon = telefoon,
                email = email
            };
            return result;


        }
    }
}