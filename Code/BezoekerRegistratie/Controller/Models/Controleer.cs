using Controller.Exceptions;
using CountryValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Controller.Models
{
    public static class Controleer
    {
        public static void ControleIsBezoekerAlAanwezig(Bezoeker bezoeker)
        {
            if (!bezoeker.Aanwezig) throw new ControleerException("ControleBezoekerAlAanwezig");
        }

        public static string BtwNummerControle(string btw)
        {
            if (string.IsNullOrWhiteSpace(btw)) throw new ControleerException("Controle BTW - geen geldige invoer");
            string btwControle = btw.Replace(" ", "").Replace(".", "").ToUpper();

            // uitleg over VAT-validator class: https://github.com/anghelvalentin/CountryValidator
            CountryValidator validator = new CountryValidator();
            var Landen = Enum.GetValues(typeof(Country)).Cast<Country>();
            var EUlanden = Enum.GetValues(typeof(Europa)).Cast<Europa>();
            string BTWletters = btwControle.Substring(0, 2);
            
            foreach (var land in Landen)
            {
                foreach(var EUland in EUlanden)
                {
                    string landWoord = land.ToString();
                    string euLandWoord = EUland.ToString();

                    if(landWoord == euLandWoord && landWoord == BTWletters)
                    {
                        Country country = (Country)land;
                        ValidationResult validationResult = validator.ValidateVAT(btwControle, country);
                        if (validationResult.IsValid)
                        {
                            return btwControle;
                        }
                    }
                }
            }
            throw new ControleerException("BTW nummer niet correct");
        }
        public static string ControleEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) throw new ControleerException("ControleEmail");
            string regexString = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex regex = new Regex(regexString);
            if (!regex.IsMatch(email)) throw new ControleerException("ControleEmail - geen geldige regex");
            return email;
        }
        public static string ControleTelefoon(string telefoon)
        {

            if (string.IsNullOrWhiteSpace(telefoon)) throw new ControleerException("ControleTelefoon - IsNullOrWhiteSpace");
            telefoon = telefoon.Replace(" ", "");// zelfde als trim()?

            string regexString = @"^(((\+32|0|0032)4){1}[1-9]{1}[0-9]{7})$";
            Regex regex = new Regex(regexString);

            //voor dummy data
            string regexString2 = @"^(([0-9]{3}-){2}[0-9]{4})$";
            Regex regex2 = new Regex(regexString2);

            if (!regex.IsMatch(telefoon) && !regex2.IsMatch(telefoon)) throw new ControleerException("ControleTelefoon - geen geldige regex");
            return telefoon;
        }

        public static void ControleIsAfspraakAlAfgesloten(Afspraak afspraak)
        {
            // Een bezoeker kan niet uitloggen als hij nooit was ingelogd.
            if (afspraak is null) throw new ControleerException("We konden je niet vinden in het systeem, was je ingelogd?");
            if (afspraak.EindTijd != null) throw new ControleerException("Je kan niet uitloggen als je was nooit ingelogd.");

        }

        public static void LegeVelden(string vnBezoeker, string anBezoeker, string email, string bedrijfBezoeker, string emailContactPersoon)
        {
            if (string.IsNullOrWhiteSpace(vnBezoeker)) throw new ControleerException("Leeg veld - Voornaam");
            if (string.IsNullOrWhiteSpace(anBezoeker)) throw new ControleerException("Leeg veld - Achternaam");
            ControleEmail(email);
            if (string.IsNullOrWhiteSpace(bedrijfBezoeker)) throw new ControleerException("Leeg veld - Bedrijfbezoeker");
            //TODO: is controle nodig?
            ControleEmail(emailContactPersoon);
        }

        public static void BezoekerIsAlAangemeld(Bezoeker bezoekerMetId)
        {
            if (bezoekerMetId.Aanwezig) throw new ControleerException("Je bent al aanwezig");
        }
        public static string SetStringParameters(string p)
        {
            if (string.IsNullOrWhiteSpace(p)) throw new ControleerException("SetStringParamerters -  Ingave niet correct");
            return p;
        }

        //TODO: regex is momenteel enkel voor belgische nummerplaten
        public static string ControleNummerplaat(string nummerplaat)
        {
            if (string.IsNullOrWhiteSpace(nummerplaat)) throw new ControleerException("Controle nummerplaat - geen geldige ingave");
            string regexString = @"^((1|2)-)?(([A-Z]){3}-([0-9]){3}?)$";
            Regex regex = new Regex(regexString);
            if (!regex.IsMatch(nummerplaat)) throw new ControleerException("Controle nummerplaat - geen geldige regex");
            return nummerplaat;
        }
    }
}
