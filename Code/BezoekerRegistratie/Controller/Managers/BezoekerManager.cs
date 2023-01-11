using Controller.Exceptions;
using Controller.Exceptions.Manager;
using Controller.Interfaces;
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
            try
            {
                List<Bezoeker> bezoekers = _bezoekerRepository.GeefAlleAanwezigeBezoekers();
                return bezoekers.AsReadOnly();
            }

            catch (Exception ex)
            {
                throw new BezoekerManagerException("Kan aanwezige bezoekers niet vinden.", ex);
            }
        }

        public IReadOnlyList<Bezoeker> ZoekOp(string zoekText)
        {
            try
            {
                return _bezoekerRepository.ZoekBezoekersOp(zoekText).AsReadOnly();
            }

            catch (Exception ex)
            {
                throw new BezoekerManagerException("Kan bezoeker niet vinden.", ex);
            }
          

        }


        public void MeldBezoekerAan(string vnBezoeker, string anBezoeker, string email,
            string bedrijfBezoeker, string emailContactPersoon)
        {
           
            try
            {
                Controleer.LegeVelden(vnBezoeker, anBezoeker, email, bedrijfBezoeker, emailContactPersoon);
                Controleer.ControleEmail(email);
                Controleer.ControleEmail(emailContactPersoon);

                Bezoeker bezoekerMetId = _bezoekerRepository.GeefBezoekerOpEmail(email);
                if (bezoekerMetId == null)
                {
                    // Opgelet hier maken we een nieuwe bezoeker aan ZONDER id mee te geven.
                    Bezoeker bezoeker = new Bezoeker(vnBezoeker, anBezoeker, email, bedrijfBezoeker, true);
                    _bezoekerRepository.VoegBezoekerToe(bezoeker);
                    bezoekerMetId = _bezoekerRepository.GeefBezoekerOpEmail(email);
                }
                else
                {
                    Controleer.BezoekerIsAlAangemeld(bezoekerMetId);
                    bezoekerMetId.MeldAan();
                    _bezoekerRepository.ZetBezoekerNonActief(bezoekerMetId);
                }

                Werknemer werknemer = _werknemerRepository.GeefWerknemerOpEmail(emailContactPersoon); // TODO: controle bestaat werknemer
                Afspraak afspraak = new Afspraak(bezoekerMetId, werknemer, DateTime.Now);
                _afspraakRepository.VoegAfspraakToe(afspraak);
            }
            catch (Exception ex)
            {
                throw new BedrijfManagerException("Kan bezoeker niet aanmelden.", ex);
            }
        }

        public void MeldBezoekerUit(string email)
        {
            try
            {
                Bezoeker bezoeker = _bezoekerRepository.GeefBezoekerOpEmail(email);
                Controleer.ControleIsBezoekerAlAanwezig(bezoeker);

                Afspraak afspraak = _afspraakRepository.GeefOpenstaandeAfspraakOpBezoekerEmail(email);
                Controleer.ControleIsAfspraakAlAfgesloten(afspraak);

                afspraak.EindeAfspraak();
                _afspraakRepository.UpdateAfspraak(afspraak);
            }
            catch (Exception ex)
            {
                throw new BedrijfManagerException("Niet gelukt om de bezoeker af te melden.", ex);
            }
        }

        public Bezoeker ZoekBezoekerOpEmail(string email)
        {
            try
            {
                Bezoeker bezoeker = _bezoekerRepository.GeefBezoekerOpEmail(email);
                if (bezoeker != null)
                {
                    if (bezoeker.Aanwezig)
                    {
                        return bezoeker;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new BedrijfManagerException("Kan bezoeker niet vinden op email.", ex);
            }
           
        }

        public void UpdateBezoeker(Bezoeker bezoeker)
        {
            //TODO: als naar de methode gekeken wordt in repo wordt er wel degelijk een update uitgevoerd en niet
            //=>
            // Een update van een bezoeker gebeurt er eigelijk niet omdat we
            // in de afspraken de email adressen wille behouden, daarom bij elke verandering 
            // wordt er een nieuwe bezoeker toegevoegd
            try
            {
                _bezoekerRepository.ZetBezoekerNonActief(bezoeker);
            }
            catch (Exception ex)
            {
                throw new BedrijfManagerException("Kan bezoeker niet updaten.", ex);
            }
          

        }

       /* public void VerwijderBezoeker(int index)
        {
            try
            {
                
                _bezoekerRepository.VerwijderBezoeker(index);
            }
            catch (Exception ex)
            {
                throw new BedrijfManagerException("Kan bezoeker niet verwijderen.", ex);
            }
        }*/
    }
}
