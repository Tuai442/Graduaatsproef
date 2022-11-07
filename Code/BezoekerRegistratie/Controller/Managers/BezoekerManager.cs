using Controller.Exceptions;
using Controller.Interfaces;
using Controller.Interfaces.Models;
using Controller.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Managers
{
    public class BezoekerManager
    {
        private IBezoekerRepository _bezoekerRepository;
        private IAfspraakRepository _afspraakRepository;
        private IWerknemerRepository _werknemerRepository;
        private IBedrijfRepository _bedrijfRepository;


        public BezoekerManager(IBezoekerRepository bezoekerRepository, IAfspraakRepository afspraakRepository,
            IWerknemerRepository werknemerRepository, IBedrijfRepository bedrijfRepository)
        {
            _bezoekerRepository = bezoekerRepository;
            _afspraakRepository = afspraakRepository;
            _werknemerRepository = werknemerRepository;
            _bedrijfRepository = bedrijfRepository;
        }

        public IReadOnlyList<Bezoeker> GeefAlleAanwezigeBezoekers()
        {
            //List<Afspraak> afspraken =  _afspraakRepository.GeefAlleAanwezigeAfspraken();
            //return afspraken.Select(x => x.Bezoeker).ToList().AsReadOnly();
            List<Bezoeker> bezoekers = _bezoekerRepository.GeefAlleBezoekers();
            return bezoekers.AsReadOnly();
        }

        public IReadOnlyList<Bezoeker> ZoekOp(string zoekText)
        {
            return _bezoekerRepository.ZoekBezoekersOp(zoekText).AsReadOnly();
        }

        public void MeldBezoekerAan(string vnBezoeker, string anBezoeker, string email, 
            string bedrijfBezoeker, string emailContactPersoon)
        {
            Controleer.LegeVelden(vnBezoeker, anBezoeker, email, emailContactPersoon, bedrijfBezoeker);
            Controleer.ControleEmail(email);
            // TODO: controler is bezoeker al aanwezig

            Bezoeker bezoeker = new Bezoeker(vnBezoeker, anBezoeker, email, bedrijfBezoeker, true);
            Werknemer werknemer = _werknemerRepository.GeefWerknemerOpEmail(emailContactPersoon);
            Afspraak afspraak = new Afspraak(bezoeker, werknemer, DateTime.Now);
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

        public Bezoeker ZoekBezoekerOpEmail(string email)
        {
            // https://stackoverflow.com/questions/3550161/c-sharp-readonly-object
            // TODO: Vraag 1 - We kunnen geen readonly object doorsturen ?
            Afspraak afspraak = _afspraakRepository.GeefAfspraakOpEmail(email);
            if(afspraak != null)
            {
                return afspraak.Bezoeker;

            }
            return null;
        }

        public void UpdateBezoeker(Bezoeker bezoeker)
        {
            // Een update van een bezoeker gebeurt er eigelijk niet omdat we
            // in de afspraken de email adressen wille behouden, daarom bij elke verandering 
            // wordt er een nieuwe bezoeker toegevoegd
            
            _bezoekerRepository.UpdateBezoeker(bezoeker);

        }

        public void VoegNieweBezoekerToe(Bezoeker nieuweBezoeker)
        {
        }
    }
}
