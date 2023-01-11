using Controller.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Interfaces
{
    public interface IBezoekerRepository
    {
        void VoegBezoekerToe(Bezoeker bezoeker);
       // void VerwijderBezoeker(int index);
        Bezoeker GeefBezoekerOpEmail(string email);
        void ZetBezoekerNonActief(Bezoeker bezoeker);
        List<Bezoeker> GeefAlleAanwezigeBezoekers();
        List<Bezoeker> ZoekBezoekersOp(string zoekText);
        void MeldBezoekerAf(Bezoeker bezoekerMetId);
        void MeldBezoekerAan(Bezoeker bezoeker);
        
        }
    }
