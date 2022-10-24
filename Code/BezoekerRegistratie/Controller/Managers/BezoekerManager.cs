using Controller.Exceptions;
using Controller.Interfaces;
using Controller.Interfaces.Models;
using Controller.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Managers
{
    public class BezoekerManager
    {
        // TODO: nog een kijke of het wel goed is om geen BezoekerRepo te hebben.
        private IBezoekerRepository _bezoekerRepository;
        private IAfspraakRepository _afspraakRepository;
        public BezoekerManager(IBezoekerRepository bezoekerRepository, IAfspraakRepository afspraakRepository)
        {
            _bezoekerRepository = bezoekerRepository;
            _afspraakRepository = afspraakRepository;
        }

        public List<IBezoeker> GeefAlleAanwezigeBezoekers()
        {
            // TODO: Vraag,  veel overbodig omzettingen:
            //  - Afspraken -> Bezoekers -> IBezoekers -> Objecten

            //List<Bezoeker> bezoekers = _bezoekerRepository.GeefAlleBezoekers();           
            //return bezoekers.Select(x => (IBezoeker)x).ToList();
            List<Afspraak> afspraken = _afspraakRepository.GeefAlleAfspraken();

            //TODO:  Id is bij bezoeker niet echt van belang.
            List<Bezoeker> bezoekers = afspraken.Select(x => 
                new Bezoeker(0, x.VoornaamBezoeker, x.AchternaamBezoeker, x.Email, x.Bedrijf)).ToList();

            return bezoekers.Select(x => (IBezoeker)x).ToList();
        }

        public List<IBezoeker> ZoekOp(string zoekText)
        {
            List<Bezoeker> bezoekers = _bezoekerRepository.ZoekBezoekersOp(zoekText);
            return bezoekers.Select(x => (IBezoeker)x).ToList();
        }

        public void MeldBezoekerAan(string vnBezoeker, string anBezoeker, string email, string vnContactP,
            string anContactP, string bedrijfsNaam)
        {
            // TODO: Unit test
            Controleer.ControleEmail(email);
            // Controleer.ControleIsBezoekerAlAanwezig(bezoeker);  <--- Moet er gecontroleerd worden of de bezoeker nog niet aanwezig is ???

            Afspraak afspraak = new Afspraak(email, vnBezoeker, anBezoeker,
                vnContactP, anContactP, bedrijfsNaam);
            _afspraakRepository.VoegAfspraakToe(afspraak);
        }

        public void MeldBezoekerUit(string email)
        {
            // TODO: Unit test
            Afspraak afspraak = _afspraakRepository.GeefAfspraakOpEmail(email);
            Controleer.ControleIsAfspraakAlAfgesloten(afspraak);
            afspraak.EindeAfspraak();
            _afspraakRepository.UpdateAfspraak(afspraak);
        }
    }
}
