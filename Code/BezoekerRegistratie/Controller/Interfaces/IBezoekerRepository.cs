using Controller.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Interfaces
{
    public interface IBezoekerRepository : IPersoonRepository
    {
        void VoegBezoekerToe(Bezoeker bezoeker);
        void VerwijderBezoeker(Bezoeker bezoeker);
        Bezoeker GeefBezoekerOpEmail(string email);
        List<Bezoeker> GeefAlleBezoekers();
        void UpdateBezoeker(Bezoeker bezoeker);
        List<Bezoeker> GeefAlleAanwezigeBezoekers();
        List<Bezoeker> ZoekBezoekersOp(string zoekText);
    }
}
