using Controller.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Models
{
    public static class Controleer
    {
        public static bool ControleIsBezoekerAlAanwezig(Bezoeker bezoeker)
        {
            if (bezoeker.Aanwezig) throw new BezoekerException("Bezoeker bestaat al.");
            return true;
            
        }

        public static void BtwNummerControle(string btw)
        {
            // TODO controle btw nummer
            if (false) throw new BedrijfException("BTW-nummer is niet gelding.");
        }

        internal static void EmailControle(string email)
        {
            // TODO controle email
            if (false) throw new EmailException("Geen geldig email adres.");
        }

        internal static void ControleIsBezoekerNietAanwezig(Bezoeker bezoeker)
        {
            if (!bezoeker.Aanwezig) throw new BezoekerException("Bezoeker bestaat al.");

        }
    }
}
