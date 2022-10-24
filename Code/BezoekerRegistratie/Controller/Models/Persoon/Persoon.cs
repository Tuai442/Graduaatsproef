using Controller.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Models
{
    public class Persoon 
    {
        public int Id { get; set; }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public string Email { get; set; }
        

        public Persoon(int id, string voornaam, string achternaam, string email)
        {
            Id = id;
            Voornaam = voornaam;
            Achternaam = achternaam;
            Email = email;
        }

        public string GeefVolledigeNaam()
        {
            return Voornaam + " " + Achternaam;
        }

        public virtual Dictionary<string, string> ToDictionary()
        {
            Dictionary<string, string> result = new Dictionary<string, string>()
            {
                {"Voornaam", Voornaam},
                {"Achternaam", Achternaam},
                {"Email", Email},
                
            };
            return result;
        }

      
    }
}
