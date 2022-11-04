using Components.Models;
using Controller.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Components.ViewModels
{
    public class BezoekerViewModel
    {
        [Hoofding("Voornaam")]
        public string Voornaam { get; set; }

        [Hoofding("Achternaam")]
        public string Achternaam { get; set; }

        [Hoofding("Email")]
        public string Email { get; set; }

        [Hoofding("Nummerplaat")]
        public string Nummerplaat { get; set; }

        [Hoofding("Is Aanwezig")]
        public bool Aanwezig { get; set; }

        [Hoofding("Bedrijf")]
        public string Bedrijf { get; set; }

 
    }
}
