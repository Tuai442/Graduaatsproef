using Controller.Exceptions;
using Controller.Interfaces;
using System.Text.RegularExpressions;
﻿using Controller.Interfaces;
using Controller.Interfaces.Models;

namespace Controller.Models
{
    public class Bedrijf : IBedrijf, ILijstItem
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
        public Bedrijf(int id, string naam, string btw, string adres, string telefoon, string email)
        {
            Id = id;
            Naam = naam;
            Btw = btw;
            Adres = adres;
            Telefoon = telefoon;
            Email = email;
        }

        //public bool ControleTelefoon(string telefoon)
        //{
        //    if (string.IsNullOrWhiteSpace(telefoon)) return false;
        //    telefoon = telefoon.Replace(" ","");
        //    string regexString = @"^(((\+32|0|0032)4){1}[1-9]{1}[0-9]{7})$";
        //    Regex regex = new Regex(regexString);
        //    if (regex.IsMatch(telefoon)) return true;
        //    return false;
        //}

        //public bool ControleBTW(string btw)
        //{
        //    if (string.IsNullOrWhiteSpace(btw)) return false;
        //    btw = btw.Replace(" ", "").ToLower();
        //    string regexString = @"^(be0([0-9]{3}.){2}[0-9]{3})$";
        //    Regex regex = new Regex(regexString);
        //    if (regex.IsMatch(btw)) return true;
        //    return false;
        //}

        //public bool ControleEmail(string email) // We kunnen kijken voor dit anders aan te pakken want bij de Bezoeker moet er ook gecontroleerd worden op een email.
        //{
        //    if (string.IsNullOrWhiteSpace(email)) return false;
        //    string regexString = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
        //    Regex regex = new Regex(regexString);
        //    if (regex.IsMatch(email)) return true;
        //    return false;
        //}

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

        public object GeefItemSource()
        {
            object result = new
            {
                Naam = Naam,
                Btw = Btw,
                Adres = Adres,
                telefoon = Telefoon,
                email = Email
            };
            return result;
        }
        public override string? ToString()
        {
            return Naam;
        }
    }
}