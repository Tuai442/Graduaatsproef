
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
            if (string.IsNullOrWhiteSpace(p)) throw new BedrijfException("Ingave niet correct");
            return p;
        }

        public int Id { get; set; }
        public string Naam { get => naam; set => naam = SetStringParameters(value); }
        public string Btw { get => btw; set => btw = SetStringParameters(value); }
        public string Adres { get => adres; set => adres = SetStringParameters(value); }
        public string Telefoon { get => telefoon; set => telefoon = SetStringParameters(value); }
        public string Email { get => email; set => email = SetStringParameters(value); }


        // ListItems
        public string LabelNaam => Naam;

        public string Waarde => Email;

        //TODO: syntax met this
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