using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Interfaces.Models
{
    public interface IBezoeker: IItemSource
    {
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public string Email { get; set; }

        public int BezoekerId { get; set; }
        public string Nummerplaat { get; set; }
        public bool Aanwezig { get;  set; }
        public string Bedrijf { get; set; }
    }
}
