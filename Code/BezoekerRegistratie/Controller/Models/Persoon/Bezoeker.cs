using Controller.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Models
{
    public class Bezoeker: Persoon, ITabelObject
    {
        private static int totalBezoekers = 0;
        public int BezoekerId { get; set; }
        public string Nummerplaat { get; set; }
        public bool Aanwezig { get; set; }
        public Bezoeker(string voornaam, string achternaam, string email, Bedrijf bedrijfVanBezoeker, string nummerplaat= "") : 
            base(voornaam, achternaam, email, bedrijfVanBezoeker)
        {
            totalBezoekers += 1;
            BezoekerId = totalBezoekers;
            Nummerplaat = nummerplaat;
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

        public object GeefDataInfo()
        {

            return new object()
            {
            };
        } 


    }
}
