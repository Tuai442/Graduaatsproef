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

            Bezoeker bezoekerMetId = null;
            try
            {
                Controleer.LegeVelden(vnBezoeker, anBezoeker, email, bedrijfBezoeker, emailContactPersoon);
                Controleer.ControleEmail(email);
                Controleer.ControleEmail(emailContactPersoon);

                bezoekerMetId = _bezoekerRepository.GeefBezoekerOpEmail(email);
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
                    _bezoekerRepository.MeldBezoekerAan(bezoekerMetId);
                }

                Werknemer werknemer = _werknemerRepository.GeefWerknemerOpEmail(emailContactPersoon); 
                Afspraak afspraak = new Afspraak(bezoekerMetId, werknemer, DateTime.Now);
                _afspraakRepository.VoegAfspraakToe(afspraak);
            }
            catch (Exception ex)
            {
                if(bezoekerMetId!= null)
                {
                    _bezoekerRepository.MeldBezoekerAf(bezoekerMetId);
                }
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

                afspraak.Bezoeker.MeldAf();
                afspraak.EindeAfspraak();

                _afspraakRepository.EindeAfspraak(afspraak);

            }
            catch (ControleerException) { throw; }
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
            try
            {
                _bezoekerRepository.ZetBezoekerNonActief(bezoeker);
            }
            catch (Exception ex)
            {
                throw new BedrijfManagerException("Kan bezoeker niet updaten.", ex);
            }
          

        }

    }
}
