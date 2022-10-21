using Controller.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Models
{
    public class WerknemerView: Persoon
    {
        private static int totalWerknemers = 0;
        public string Functie { get; set; }
        public int WerknemerId { get; set; }
        public Bedrijf Bedrijf { get; set; }

        public WerknemerView(string voornaam, string achternaam, string email, string functie, Bedrijf bedrijf) : base(voornaam, achternaam, email)
        {
            totalWerknemers += 1;
            WerknemerId = totalWerknemers;
            Functie = functie;
            Bedrijf = bedrijf;
        }

        public object GeefTabelData()
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
    }
}
