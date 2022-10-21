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

        private IBezoekerRepository _bezoekerRepository;
        private IAfspraakRepository _afspraakRepository;
        public BezoekerManager(IBezoekerRepository bezoekerRepository, IAfspraakRepository afspraakRepository)
        {
            _bezoekerRepository = bezoekerRepository;
            _afspraakRepository = afspraakRepository;
        }

        public void UpdateGebruiker(int bezoekerId, string naam = null, string achternaam = null, string email = null, string nummerplaat = null, string bedrijfVanGebruiker = null)
        {
            // TODO: update bezoeker.
            Bezoeker bezoeker = _bezoekerRepository.GeefBezoekerOpId(bezoekerId);
        }

        public List<Dictionary<string, string>> GeefAlleBezoekersNamen()
        {
            List<Bezoeker> bezoekers = _bezoekerRepository.GeefAlleBezoekers();
            List<Dictionary<string, string>> result = new List<Dictionary<string, string>>();
            foreach (Bezoeker bezoeker in bezoekers)
            {
                result.Add(bezoeker.ToDictionary());
            }
            return result;
        }

        public List<string> GeefAlleAanwezigen()
        {
            List<Bezoeker> bezoekers = _bezoekerRepository.GeefAlleBezoekers();
            List<string> aanwezigen = new List<string>();
            foreach (Bezoeker bezoeker in bezoekers)
            {
                if (bezoeker.Aanwezig)
                {
                    aanwezigen.Add(bezoeker.ToString());
                }
            }
            return aanwezigen;
        }

        public List<object> GeefAlleAanwezigeBezoekersInTabelData()
        {
            List<object> list = new List<object>();
            List<Bezoeker> bezoekers = _bezoekerRepository.GeefAlleAanwezigeBezoekers();
            foreach (Bezoeker bezoeker in bezoekers)
            {
                list.Add(bezoeker);
            }
            return list;
        }

        public List<IBezoeker> GeefAlleBezoekers()
        {
            List<Bezoeker> bezoekers = _bezoekerRepository.GeefAlleBezoekers();           
            return bezoekers.Select(x => (IBezoeker)x).ToList();
        }

        public void UpdateBezoeker(object obj)
        {
            Bezoeker bezoeker = (Bezoeker)obj;
            _bezoekerRepository.UpdateBezoeker(bezoeker);
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

            Afspraak afspraak = new Afspraak(email, ($"{vnBezoeker} {anBezoeker}"),
                ($"{vnContactP} {anContactP}"), bedrijfsNaam);
            _afspraakRepository.RegistreerAfspraak(afspraak);
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
