using Controller.Interfaces;
using Controller.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Models
{
    public class Bezoeker : Persoon, IBezoeker
    {
        public string Nummerplaat { get; set; }

        // TODO: aanwezig moet private set worden 
        public bool Aanwezig { get; set; }
        public string Bedrijf { get; set; }
        //(voornaam,achternaam,email,bedrijfId,nummerplaat,aanwezig)
        public Bezoeker(string voornaam, string achternaam, string email, string bedrijf, bool aanwezig = true, string nummerplaat = "") :
            base(voornaam, achternaam, email)
        {
            Nummerplaat = nummerplaat;
            Bedrijf = bedrijf;
            Aanwezig = aanwezig;

        }

<<<<<<< HEAD
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

=======
>>>>>>> 1b67baa0074e533919432dca745046b6189630fe
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
    }
}
