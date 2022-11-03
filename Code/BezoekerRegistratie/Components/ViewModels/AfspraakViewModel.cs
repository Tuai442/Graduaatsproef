using Controller;
using Controller.Interfaces;
using Controller.Interfaces.Models;
using Controller.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Components.Models;

namespace Components.ViewModels
{
    public class  AfspraakViewModel
    {
        [Hoofding("Bezoeker Naam")]
        public string BezoekerNaam { get; set ; }

        [Hoofding("Werknemer Naam")]
        public string WerknemerNaam { get; set ; }

        [Hoofding("Start Tijd")]
        public DateTime StartTijd { get; set; }

        [Hoofding("Eind Tijd")]
        public DateTime? EindTijd { get; set; }

    }
}
