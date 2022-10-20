using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Models
{
    public class Bericht
    {
        public bool Status { get; set; }
        public string Inhoud { get; set; }
        public Bericht(string inhoud, bool status)
        {
            Status = status;
            Inhoud = inhoud;
        }

        
    }
}
