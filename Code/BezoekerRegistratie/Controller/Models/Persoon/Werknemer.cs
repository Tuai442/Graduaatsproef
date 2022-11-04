using Controller.Interfaces;
using Controller.Interfaces.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Models
{
    public class Werknemer: Persoon
    {
        public string Functie { get; set; }
        public Bedrijf Bedrijf { get; set; }
        public int Id { get; set; }

        public Werknemer(int id, string voornaam, string achternaam, string email, string functie, Bedrijf bedrijf) 
            : base(voornaam, achternaam, email)
        {
            Id = id;
            Functie = functie;
            Bedrijf = bedrijf;
        }

       

        public override string? ToString()
        {
            return GeefVolledigeNaam();
        }
    }
}
