using Controller.Exceptions;
using Controller.Interfaces;
using System.Text.RegularExpressions;

namespace Controller.Models
{
    public class Bedrijf: ITabelData
    {
        public string  Naam { get; private set; }
        public string Btw { get; private set; }
        public string Adres { get; private set; }
        public string Telefoon { get; private set; }
        public string Email { get; private set; }
        public ParkingContract ParkingContract { get; set; }

        public Bedrijf(string naam, string btw, string adres, string telefoon, string email)
        {
            Naam = naam;
            Adres = adres;
            Btw = btw;
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

        public object GeefTabelData()
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
    }
}