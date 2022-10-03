using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Models
{
    public class Werknemer: Persoon
    {
        private static int totalWerknemers = 0;

        public string Functie { get; set; }
        public int WerknemerId { get; set; }

        public Werknemer(string voornaam, string achternaam, string email, string functie, Bedrijf bedrijf) : base(voornaam, achternaam, email, bedrijf)
        {
            totalWerknemers += 1;
            WerknemerId = totalWerknemers;
            Functie = functie;
        }
    }
}
