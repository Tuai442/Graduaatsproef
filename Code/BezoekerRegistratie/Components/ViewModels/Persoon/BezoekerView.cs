using Controller.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Models
{
    public class BezoekerView: Persoon
    {
        public int BezoekerId { get; set; }
        
        public string Nummerplaat { get; set; }
        public bool Aanwezig { get; private set; }
        public string Bedrijf { get; set; }
        public BezoekerView(string voornaam, string achternaam, string email, string bedrijf, string nummerplaat= ""):
            base(voornaam, achternaam, email)
           
        {
            BezoekerId = BezoekerId;
            Voornaam = voornaam;
            Achternaam = achternaam;
            Email = email;
            Bedrijf = bedrijf;

        }

    }
}
