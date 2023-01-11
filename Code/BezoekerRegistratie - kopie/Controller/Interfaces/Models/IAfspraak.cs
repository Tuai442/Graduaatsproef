using Controller.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Interfaces.Models
{
    public interface IAfspraak: IItemSource
    {
        public string BezoekerNaam { get; }
        public string WerknemerNaam { get; }

        public DateTime StartTijd { get; set; }
        public DateTime? EindTijd { get; set; }

        public object GeefItemSource();

    }
}
