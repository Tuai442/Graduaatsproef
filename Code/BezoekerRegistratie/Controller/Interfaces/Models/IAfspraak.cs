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
        public int Id { get; set; }
        public string Email { get; set; }
        public string VoornaamBezoeker { get; set; }
        public string AchternaamBezoeker { get; set; }
        public string VoornaamContactPersoon { get; set; }
        public string AchternaamContactPersoon { get; set; }
        public string Bedrijf { get; set; }
        public DateTime StartTijd { get; set; }
        public DateTime EindTijd { get; set; }

        public object GeefItemSource();
    }
}
