
﻿using Controller.Exceptions;
using Controller.Interfaces;
using System.Text.RegularExpressions;
﻿using Controller.Interfaces;
using Controller.Interfaces.Models;


namespace Controller.Models
{
    public class Bedrijf
    {
        public int Id { get; private set; }
        public string  Naam { get; private set; }
        public string Btw { get; private set; }
        public string Adres { get; private set; }
        public string Telefoon { get; private set; }
        public string Email { get; private set; }

        public Bedrijf(string naam, string btw, string adres, string telefoon, string email)
        {
            Naam = naam;
            Adres = adres;
            Btw = btw;
            Telefoon = telefoon;
            Email = email;
        }
        public Bedrijf(int id, string naam, string btw, string adres, string telefoon, string email)
        {
            Id = id;
            Naam = naam;
            Btw = btw;
            Adres = adres;
            Telefoon = telefoon;
            Email = email;
        }



        public static List<string> GeefAttributen()
        {
            return new List<string>
            {
                "Naam",
                "Btw",
                "Adres",
                "Telefoon",
                "Email",
                "Parking Contract"
            };
        }

    
        public override string? ToString()
        {
            return Naam;
        }
    }
}