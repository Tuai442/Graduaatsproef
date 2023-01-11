using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BezoekerRegistratie.Tabellen
{
    struct BezoekerTabel
    {
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public string Email { get; set; }
        public string Bedrijf { get; set; }
        public int BezoekerId { get; set; }
        public string Nummerplaat { get; set; }
        public bool Aanwezig { get; set; }
    }
}
