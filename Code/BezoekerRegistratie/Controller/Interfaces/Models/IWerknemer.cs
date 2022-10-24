using Controller.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Interfaces.Models
{
    public interface IWerknemer: IItemSource
    {
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public string Email { get; set; }
        public string Functie { get; set; }
        public int WerknemerId { get; set; }
        public Bedrijf Bedrijf { get; set; }
        public object GeefItemSource();
    }
}
