
﻿using Controller.Exceptions;
using Controller.Interfaces;
using System.Text.RegularExpressions;
﻿using Controller.Interfaces;
using Controller.Interfaces.Models;

namespace Controller.Models
{
    public class Bedrijf 
    {
        private string naam;
        private string btw;
        private string adres;
        private string telefoon;
        private string email;


        private string SetStringParameters(string p)
        {
            //if (string.IsNullOrWhiteSpace(p)) throw new BedrijfException("Ingave niet correct");
            return p;

        }


        public int Id { get; set; }
        public string Naam { get => naam; set => naam = Controleer.SetStringParameters(value); }
        public string Btw { get => btw; set => btw = Controleer.BtwNummerControle(value); }
        public string Adres { get => adres; set => adres = Controleer.SetStringParameters(value); }
        public string Telefoon { get => telefoon; set => telefoon = Controleer.ControleTelefoon(value); }
        public string Email { get => email; set => email = Controleer.ControleEmail(value); }

        public Bedrijf(string naam, string btw, string adres, string telefoon, string email)
        {
            Naam = naam;
            Adres = adres;
            Btw = btw;
            Telefoon = telefoon;
            Email = email;

        }
        public Bedrijf(int id, string naam, string btw, string adres, string telefoon, string email): this(naam, btw, adres, telefoon, email)
        {

            Id = id;

        }

        public override string? ToString()
        {
            return Naam;
        }
    }
}