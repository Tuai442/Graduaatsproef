using Controller.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Models
{
    public class Bezoeker: Persoon, ITabelData
    {
        
        private static int totalBezoekers = 0; // TODO: tijdelijk
        public int BezoekerId { get; set; }
        public string Nummerplaat { get; set; }
        public bool Aanwezig { get; private set; }
        public string Bedrijf { get; set; }
        public int BedrijfId { get; set; }
        //(voornaam,achternaam,email,bedrijfId,nummerplaat,aanwezig)
        public Bezoeker(string voornaam, string achternaam, string email, string bedrijf, bool aanwezig = false, string nummerplaat= "") : 
            base(voornaam, achternaam, email)
        {
            BezoekerId = totalBezoekers;
            Nummerplaat = nummerplaat;
            totalBezoekers += 1;
            Bedrijf = bedrijf;
            Aanwezig = aanwezig;

        }

        public Bezoeker(string voornaam, string achternaam, string email,int bedrijfId, string nummerplaat, bool aanwezig ):
            base(voornaam, achternaam, email)
        {
            Nummerplaat = nummerplaat;
            Aanwezig = aanwezig;
            BedrijfId = bedrijfId;
        }

        //TODO: in controleer klasse
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

        public object GeefTabelData()
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
    }
}
