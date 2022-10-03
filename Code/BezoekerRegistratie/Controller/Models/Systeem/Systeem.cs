using Controller.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Models.Systeem
{
    public class Systeem
    {
        private IWerknemerRepository _werknemerRepository;
        private IBezoekerRepository _bezoekerRepository;
        private static List<Bezoeker> _bezoekers;

        public Systeem(IWerknemerRepository werknemerRepository, IBezoekerRepository bezoekerRepository)
        {
            _werknemerRepository = werknemerRepository;
            _bezoekerRepository = bezoekerRepository;
        }

        public bool ControleBestaatBezoeker(Bezoeker bezoeker)
        {
            // TODO: Controleer via repo of bezoeker al in systeem zit
            return true;
        }

        public void RegistreerBezoeker(Bezoeker bezoeker)
        {
            // TODO: Registreer een bezoeker
            throw new NotImplementedException();
        }

        public List<Bezoeker> GeefAlleBezoekers()
        {

            return _bezoekers;
        }

        public void MeldBezoekerAan(Bezoeker bezoeker)
        {
            // TODO: Meld een bezoeker aan. Miss Controlle uitvoeren ???
            throw new NotImplementedException();
        }

        public void SchrijfBezoekerUit(Bezoeker bezoeker)
        {
            // TODO: Schrijf een bezoeker uti.
            throw new NotImplementedException();
        }

        public List<Bezoeker> GeefAlleAangemeldeBezoekers()
        {
            List<Bezoeker> aangemeldeBezoekers = new List<Bezoeker>();
            foreach (var bezoeker in _bezoekers)
            {
                if (bezoeker.Aanwezig)
                {
                    aangemeldeBezoekers.Add(bezoeker);
                }
            }
            return aangemeldeBezoekers;
        }
    }
}
