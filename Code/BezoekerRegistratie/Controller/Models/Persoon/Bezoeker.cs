using Controller.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Models
{
    public class Bezoeker: Persoon
    {
        
        private static int totalBezoekers = 0; // TODO: tijdelijk
        public int BezoekerId { get; set; }
        public string Nummerplaat { get; set; }
        public bool Aanwezig { get; private set; }
        public Bezoeker(string voornaam, string achternaam, string email, Bedrijf bedrijfVanBezoeker, string nummerplaat= "") : 
            base(voornaam, achternaam, email, bedrijfVanBezoeker)
        {
            BezoekerId = totalBezoekers;
            Nummerplaat = nummerplaat;
            totalBezoekers += 1;

        }

        public bool ControleNummerplaat(string nummerplaat)
        {
            // TODO: Controlleer de nummerplaat vie Regulire expresies.
            return true;
        }

        public override Dictionary<string, string> ToDictionary()
        {
            base.ToDictionary();
            Dictionary<string, string> result = base.ToDictionary();
            result.Add("Nummerplaat", Nummerplaat);
            result.Add("Aanwezig", Aanwezig.ToString());
            return result;
        }

        internal object GeefTabelData()
        {
            object result = new {
                BezoekerId = BezoekerId,
                Voornaam = Voornaam,
                Achternaam = Achternaam,
                Nummerplaat = Nummerplaat,
                Aanwezig = Aanwezig
                };
            return result;
            

        }

        public void MeldAan()
        {
            Aanwezig = true;
        }

        public void MeldAf()
        {
            Aanwezig = false;
        }
    }
}
