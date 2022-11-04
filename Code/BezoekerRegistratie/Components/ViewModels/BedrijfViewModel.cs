using Components.Models;
using Controller.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Components.ViewModels
{
    public class BedrijfViewModel: ILijstItem
    {
        public string Naam { get; private set; }

        [Hoofding("BTW Nummer")]
        public string Btw { get; private set; }

        
        public string Adres { get; private set; }

        public string Telefoon { get; private set; }

        public string Email { get; private set; }

        // ILijstIterface
        public string LabelNaam => Naam;
        public string Waarde => Email;
    }
}
