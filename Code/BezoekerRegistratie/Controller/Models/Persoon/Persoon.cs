using Controller.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Models
{
    public class Persoon: IUIConverter
    {
        
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public string Email { get; set; }
        public Bedrijf Bedrijf { get; set; }

        public Persoon(string voornaam, string achternaam, string email, Bedrijf bedrijf)
        {
            Voornaam = voornaam;
            Achternaam = achternaam;
            Email = email;
            Bedrijf = bedrijf;
        }

        public string GeefVolledigeNaam()
        {
            return Voornaam + " " + Achternaam;
        }

        public virtual Dictionary<string, string> ToDictionary()
        {
            Dictionary<string, string> result = new Dictionary<string, string>()
            {
                {"Voornaam", Voornaam},
                {"Achternaam", Achternaam},
                {"Email", Email},
                {"Bedrijf", Bedrijf.Naam }
            };
            return result;
        }
    }
}
