using Controller.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Models
{
    public static class Controleer
    {
        public static void ControleIsBezoekerAlAanwezig(Bezoeker bezoeker)
        {
            
        }

        internal static void ControleEmail(string email)
        {
            if (string.IsNullOrEmpty(email)) throw new EmailException("Email veld mag niet leeg zijn.");
            //TODO: regex maken van een email en daarop controle doen
            if (false) throw new EmailException("Geen geldig email adres.");
        }

        public static void BtwNummerControle(string btw)
        {
            
            // TODO controle btw nummer
            if (false) throw new BedrijfException("BTW-nummer is niet gelding.");
        }

       

        internal static void ControleIsBezoekerNietAanwezig(Bezoeker bezoeker)
        {
            if (!bezoeker.Aanwezig) throw new BezoekerException("Bezoeker bestaat al.");

        }

        internal static void ControleIsAfspraakAlAfgesloten(Afspraak afspraak)
        {
            // Een bezoeker kan niet uitloggen als hij nooit was ingelogd.
            if (afspraak is null) throw new UitLogException("We konden je niet vinden in het systeem, was je ingelogd?");
            if (afspraak.EindTijd != null) throw new UitLogException("Je kan niet uitloggen als je was nooit ingelogd.");

        }
    }
}
