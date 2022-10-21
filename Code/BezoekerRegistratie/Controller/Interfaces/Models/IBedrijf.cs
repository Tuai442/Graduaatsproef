using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Interfaces.Models
{
    public interface IBedrijf: IItemSource
    {
        public string Naam { get; set; }
        public string Btw { get; set; }
        public string Adres { get; set; }
        public string telefoon { get; set; }
        public string email { get; set; }
        public object GeefItemSource();



    }
}
