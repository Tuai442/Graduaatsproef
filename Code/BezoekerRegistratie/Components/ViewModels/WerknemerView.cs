using Controller.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Components.ViewModels
{
    public class WerknemerView
    {
        public Werknemer werknemer;

        [Hoofding("Voornaam")]
        public string Voornaam { get; set; }

        [Hoofding("Achternaam")]
        public string Achternaam { get; set; }

        [Hoofding("Email")]
        public string Email { get; set; }

        [Hoofding("Functie")]
        public string Functie { get; set; }

        [Hoofding("Bedrijf")]
        public string Bedrijf { get; set; }

        public WerknemerView(Werknemer werknemer)
        {
            werknemer = werknemer;
            Voornaam = werknemer.Voornaam;
            Achternaam = werknemer.Achternaam;
            Email = werknemer.Email;
            Functie = werknemer.Functie;
            Bedrijf = werknemer.Bedrijf.ToString();
        }

        
    }
}
