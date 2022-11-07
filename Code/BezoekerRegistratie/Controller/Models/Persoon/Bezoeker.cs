using Controller.Interfaces;
using Controller.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Models
{
    public class Bezoeker : Persoon
    {
        public int Id;

        public string Nummerplaat { get; set; }
        public bool Aanwezig { get; set; }
        public string Bedrijf { get; set; }
        //(voornaam,achternaam,email,bedrijfId,nummerplaat,aanwezig)
        public Bezoeker(int id, string voornaam, string achternaam, string email, string bedrijf, bool aanwezig = true, string nummerplaat = "") :
            base(voornaam, achternaam, email)
        {
            Id = id;
            Nummerplaat = nummerplaat;
            Bedrijf = bedrijf;
            Aanwezig = aanwezig;
        }

        public Bezoeker(string voornaam, string achternaam, string email, string bedrijf, bool aanwezig, string nummerplaat=null) :
            base(voornaam, achternaam, email)
        {
            Nummerplaat = nummerplaat;
            Aanwezig = aanwezig;
            Bedrijf = bedrijf;
        }


        //TODO: BedrijfID is moeilijk aan te spreken omdat bedrijf eens tring is
        //public Bezoeker(string voornaam, string achternaam, string email, string bedrijf, string nummerplaat, bool aanwezig):
        //    base(voornaam, achternaam, email)
        //{
        //    Nummerplaat = nummerplaat;
        //    Aanwezig = aanwezig;
        //    Bedrijf = bedrijf;
        //    //BedrijfId = bedrijfId;

        //}


        public void MeldAan()
        {
            Aanwezig = true;
        }

        public void MeldAf()
        {
            Aanwezig = false;
        }

        public Bezoeker DeepCopy()
        {
            Bezoeker bezoekerCopy = (Bezoeker)this.MemberwiseClone();
            return bezoekerCopy;
        }
    }
}
