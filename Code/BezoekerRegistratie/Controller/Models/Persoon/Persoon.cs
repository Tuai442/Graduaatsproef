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
        private string email;

        public string Voornaam { get => voornaam; set => voornaam = Controleer.SetStringParameters(value); }
        public string Achternaam { get => achternaam; set => achternaam = Controleer.SetStringParameters(value); }
        public string Email { get => email; set => email = Controleer.ControleEmail(value); }

        public Persoon(string voornaam, string achternaam, string email)
        {
            Voornaam = voornaam;
            Achternaam = achternaam;
            Email = email;
        }

        public string GeefVolledigeNaam()
        {
            return $"Voornaam : {voornaam} -  achternaam: {achternaam}";
        }

    }
}
