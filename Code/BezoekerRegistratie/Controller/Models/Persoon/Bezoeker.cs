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
        public int BezoekerId { get; set; }
        public string Nummerplaat { get; set; }
        
        // TODO: aanwezig moet private set worden 
        public bool Aanwezig { get; set; }
        public string Bedrijf { get; set; }
        //(voornaam,achternaam,email,bedrijfId,nummerplaat,aanwezig)
        public Bezoeker(int id, string voornaam, string achternaam, string email, string bedrijf, bool aanwezig = true, string nummerplaat= "") : 
            base(id, voornaam, achternaam, email)
        {
            Nummerplaat = nummerplaat;
            Bedrijf = bedrijf;
            Aanwezig = aanwezig;

        }

        public Bezoeker(int id, string voornaam, string achternaam, string email, string nummerplaat, bool aanwezig ):
            base(id, voornaam, achternaam, email)
        {
            Nummerplaat = nummerplaat;
            Aanwezig = aanwezig;
            
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
                Voornaam = Voornaam,
                Achternaam = Achternaam,
                Nummerplaat = Nummerplaat,
            };
            return result;
        }
        public override string? ToString()
        {
            return GeefVolledigeNaam();
        }
    }
}
