using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class Rij
    {
        public string ColomNaam { get; set; }
        public string Waarde { get; set; }

        public Rij(string colomNaam, string waarde)
        {
            ColomNaam = colomNaam;
            Waarde = waarde;
        }
    }
}
