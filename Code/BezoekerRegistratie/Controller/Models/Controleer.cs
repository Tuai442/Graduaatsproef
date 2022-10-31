using Controller.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Controller.Models
{
    public static class Controleer
    {
        public static void ControleIsBezoekerAlAanwezig(Bezoeker bezoeker)
        {
            if (!bezoeker.Aanwezig) throw new BezoekerException("ControleAanwezigheid - Bezoeker niet aanwezig");
        }

        //TODO: mss extra controle op effectief bestaan van het btw nummer
        public static void ControleBTW(string btw)
        {
            if (string.IsNullOrWhiteSpace(btw)) throw new BedrijfException("Controle BTW - geen geldige invoer");
            btw = btw.Replace(" ", "").ToLower();
            string regexString = @"^(be0([0-9]{3}.){2}[0-9]{3})$";
            Regex regex = new Regex(regexString);
            if (!regex.IsMatch(btw)) throw new BedrijfException("Controle BTW - geen geldige regex");
        }

        public static void ControleEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) throw new BedrijfException("Controle email - geen geldige ingave");
            string regexString = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex regex = new Regex(regexString);
            if (!regex.IsMatch(email)) throw new BedrijfException("Controle email - geen geldige regex");
        }

        public static void ControleTelefoon(string telefoon)
        {
            if (string.IsNullOrWhiteSpace(telefoon)) throw new BedrijfException("ControleTelefoon - geen geldige ingave");
            telefoon = telefoon.Replace(" ", "");
            string regexString = @"^(((\+32|0|0032)4){1}[1-9]{1}[0-9]{7})$";
            Regex regex = new Regex(regexString);
            if (!regex.IsMatch(telefoon)) throw new BedrijfException("ControleTelefoon - geen geldige regex");
        }
    }
}
