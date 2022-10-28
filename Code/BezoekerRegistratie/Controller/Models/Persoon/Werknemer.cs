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
    public class Werknemer: Persoon, IWerknemer, ILijstItem
    {
        public string Functie { get; set; }
        public Bedrijf Bedrijf { get; set; }
        public int Id { get; set; }

        // TODO: Vraag 3 - Elk object dat waarvan we een drop down lijst willen moet deze interface inmpl. (Ilijst interface)
        public string LabelNaam => GeefVolledigeNaam();
        public string Waarde => Email;

        public Werknemer(int id, string voornaam, string achternaam, string email, string functie, Bedrijf bedrijf) 
            : base(voornaam, achternaam, email)
        {
            Id = id;
            Functie = functie;
            Bedrijf = bedrijf;
        }

        public object GeefItemSource()
        {
            object result = new
            {
                Voornaam = Voornaam,
                Achternaam = Achternaam,
                Email = Email,
                Functie = Functie,
                Bedrijf = Bedrijf.Naam,
            };
            return result;
        }

        public override string? ToString()
        {
            return GeefVolledigeNaam();
        }
    }
}
