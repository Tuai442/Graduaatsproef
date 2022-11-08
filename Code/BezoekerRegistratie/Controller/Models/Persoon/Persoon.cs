using Controller.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Models
{
    public class Persoon
    {
        private string voornaam;
        private string achternaam;

        public string Voornaam { get => voornaam; set => voornaam = Controleer.SetStringParameters(value); }
        public string Achternaam { get => achternaam; set => achternaam = Controleer.SetStringParameters(value); }
        public string Email { get; set; }

        public Persoon(string voornaam, string achternaam, string email)
        {
            Voornaam = voornaam;
            Achternaam = achternaam;
            Email = email;
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

            };
            return result;
        }


    }
}
