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
        Bezoeker GeefBezoekerOpId(int id);
        Bezoeker GeefBezoekerOpEmail(string email);
        Bezoeker GeefBezoekerOpNummerplaat(string nummerplaat);
        List<Bezoeker> GeefAlleBezoekers();
        void UpdateBezoeker(Bezoeker bezoeker);
        List<Bezoeker> GeefAlleAanwezigeBezoekers();
        Persoon GeefPersoonOpEmail(string email);
        List<Bezoeker> ZoekBezoekersOp(string zoekText);
    }
}
