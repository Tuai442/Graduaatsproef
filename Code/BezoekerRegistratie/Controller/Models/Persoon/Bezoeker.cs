using Controller.Interfaces;
using Controller.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Models
{
    public class Bezoeker: Persoon, IBezoeker
    {
        
        private static int totalBezoekers = 0; // TODO: tijdelijk
        public int BezoekerId { get; set; }
        public string Nummerplaat { get; set; }
        
        // TODO: aanwezig moet private set worden 
        public bool Aanwezig { get; set; }
        public string Bedrijf { get; set; }
        public Bezoeker(string voornaam, string achternaam, string email, string bedrijf, bool aanwezig = false, string nummerplaat= "") : 
            base(voornaam, achternaam, email)
        {
            BezoekerId = totalBezoekers;
            Nummerplaat = nummerplaat;
            totalBezoekers += 1;
            Bedrijf = bedrijf;
            Aanwezig = aanwezig;

        }

        public bool ControleNummerplaat(string nummerplaat)
        {
            // TODO: Controlleer de nummerplaat vie Regulire expresies.
            return true;
        }

        public void MeldAan()
        {
            Aanwezig = true;
        }

        public void MeldAf()
        {
            Aanwezig = false;
        }

        public object GeefItemSource()
        {
            object result = new
            {
                BezoekerId = BezoekerId,
                Voornaam = Voornaam,
                Achternaam = Achternaam,
                Nummerplaat = Nummerplaat,
                Aanwezig = Aanwezig
            };
            return result;
        }
        public override string? ToString()
        {
            return GeefVolledigeNaam();
        }
    }
}
