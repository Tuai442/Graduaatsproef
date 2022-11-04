using Controller.Exceptions;
using Controller.Interfaces;
using Controller.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class BezoekerController
    {

        // is hetzelfde als manager!
        private IWerknemerRepository _werknemerRepository;
        private IBezoekerRepository _bezoekerRepository;
        private IBedrijfRepository _bedrijfRepository;
        private IAfspraakRepository _afspraakRepository;


        
        public BezoekerController(IWerknemerRepository werknemerRepository, IBezoekerRepository bezoekerRepository,
            IBedrijfRepository bedrijfRepository, IAfspraakRepository afspraakRepository)
        {
            _werknemerRepository = werknemerRepository;
            _bezoekerRepository = bezoekerRepository;
            _bedrijfRepository = bedrijfRepository;
            _afspraakRepository = afspraakRepository;
        }


        // Deze methode gaan we dubbel hebben beter met abstract class werken
        public List<string> GeefAlleBedrijven()
        {
            List<Bedrijf> bedrijfList = _bedrijfRepository.GeefAlleBedrijven();
            List<string> result = new List<string>();
            foreach(Bedrijf bedrijf in bedrijfList)
            {
                result.Add(bedrijf.Naam);
            }
            return result;
        }
        // Deze methode gaan we dubbel hebben beter met abstract class werken
        public List<string> GeefAlleWerknemers()
        {
            List<Werknemer> werknemers = _werknemerRepository.GeefAlleWerknemers();
            List<string> result = new List<string>();
            foreach (Werknemer werknemer in werknemers)
            {
                result.Add(werknemer.Voornaam);
            }
            return result;
        }

        public void MeldBezoekerAan(string vnBezoeker, string anBezoeker, string email, 
            string bedrijfsNaam, string contactPEmail)
        {
            // TODO: Unit test

            // TODO: Betere controle uitvoren
            //Controleer.LegeVelden(vnBezoeker, anBezoeker, email, contactPEmail);
            if (!string.IsNullOrEmpty(vnBezoeker))
            {
                Bezoeker bezoeker = new Bezoeker(vnBezoeker, anBezoeker, email, bedrijfsNaam);
                bezoeker.MeldAan();
                Werknemer werknemer = _werknemerRepository.GeefWerknemerOpEmail(contactPEmail);
                Afspraak afspraak = new Afspraak(bezoeker, werknemer, DateTime.Now);
                _bezoekerRepository.UpdateBezoeker(bezoeker);
                _afspraakRepository.VoegAfspraakToe(afspraak);

            }
        }

        public bool MeldBezoekerUit(string email)
        {
            // TODO: Unit test
            Afspraak afspraak = _afspraakRepository.GeefAfspraakOpEmail(email);
            if(afspraak is not null)
            {
                // TODO: kunnen we geen Messega class maken en dit terug sturen??
                if (afspraak.IsAanwezig)
                {
                    afspraak.Bezoeker.MeldAf();
                    _afspraakRepository.UpdateAfspraak(afspraak);
                    return true;
                }
            }
            
            return false;
        }

        public void VoegBedrijfToe(string naam, string btw, string email, string adres, string tel)
        {
            // TODO: Unit test
            try
            {
                Controleer.BtwNummerControle(btw);

            }
            catch (Exception ex)
            {
                throw new BedrijfException(ex.Message);
            }

            try
            {
                Controleer.ControleEmail(email);
            }
            catch (Exception ex)
            {
                throw new BedrijfException(ex.Message);
            }

            try
            {
                Controleer.ControleTelefoon(tel);
            }
            catch (Exception ex)
            {
                throw new BedrijfException(ex.Message);
            }

            Bedrijf bedrijf = new Bedrijf(naam, btw, adres, tel, email);
            _bedrijfRepository.VoegNieuwBedrijfToe(bedrijf);
        }

    }
}
