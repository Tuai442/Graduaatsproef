using Controller.Interfaces;
using Controller.Interfaces.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Models
{
    public class Werknemer: Persoon, IWerknemer
    {
        private static int totalWerknemers = 0;
        public string Functie { get; set; }
        public int WerknemerId { get; set; }
        public Bedrijf Bedrijf { get; set; }

        public Werknemer(string voornaam, string achternaam, string email, string functie, Bedrijf bedrijf) : base(voornaam, achternaam, email)
        {
            totalWerknemers += 1;
            WerknemerId = totalWerknemers;
            Functie = functie;
            Bedrijf = bedrijf;
        }

        public object GeefItemSource()
        {
            object result = new
            {
                WerknemerId = WerknemerId,
                Voornaam = Voornaam,
                Achternaam = Achternaam,
                Functie = Functie,
                Bedrijf = Bedrijf.Naam,
            };
            return result;
        }

        public override string? ToString()
        {
            return GeefVolledigeNaam();
        }
    }
}
