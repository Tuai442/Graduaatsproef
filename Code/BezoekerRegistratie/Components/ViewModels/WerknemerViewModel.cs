using Components.Models;
using Controller.Interfaces;
using Controller.Interfaces.Models;
using Controller.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Components.ViewModels
{
    public class WerknemerViewModel: ILijstItem
    {
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public string Email { get; set; }
        public string Functie { get; set; }
        public Bedrijf Bedrijf { get; set; }

        // ILijstIterface
        public string LabelNaam => $"{Voornaam} {Achternaam}";
        public string Waarde => Email;
    }
}
