using Controller.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Components.ViewModels
{
    public class BedrijfView
    {
        [Hoofding("Naam")]
        public string Naam { get; set; }
        [Hoofding("BTW-Nummer")]
        public string Btw { get ; set; }
        [Hoofding("Adres")]
        public string Adres { get; set ; }
        [Hoofding("Telefoon Nummer")]
        public string Telefoon { get ; set; }
        [Hoofding("Email")]
        public string Email { get; set; }

        public Bedrijf Bedrijf;

        public BedrijfView(Bedrijf bedrijf)
        {
            Bedrijf = bedrijf;
            Naam = bedrijf.Naam;
            Btw = bedrijf.Btw;
            Adres = bedrijf.Adres;
            Telefoon = bedrijf.Telefoon;
            Email = bedrijf.Email;

        }
    }
}
