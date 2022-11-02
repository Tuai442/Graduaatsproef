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

        public Bericht MeldBezoekerAan(string vnBezoeker, string anBezoeker, string email, string vnContactP, 
            string anContactP, string bedrijfsNaam)
        {
            // TODO: Unit test

            // TODO: Betere controle uitvoren
            if (!string.IsNullOrEmpty(vnBezoeker))
            {
                Bezoeker bezoeker = (Bezoeker)_bezoekerRepository.GeefPersoonOpEmail(email);

                if (bezoeker == null)
                {
                    // Als bezoeker nog niet bestaat.
                    bezoeker = new Bezoeker(vnBezoeker, anBezoeker, email, bedrijfsNaam);
                }
                if (!Controleer.ControleIsBezoekerAlAanwezig(bezoeker))
                {
                    return new Bericht("Je ben al aanwezig en kan dus niet meer inloggen", false); ;
                }

                bezoeker.MeldAan();
                Afspraak afspraak = new Afspraak(bezoeker, (vnContactP + anContactP), bedrijfsNaam);
                _bezoekerRepository.UpdateBezoeker(bezoeker);
                _afspraakRepository.RegistreerAfspraak(afspraak);
                return new Bericht("Je bent ingelogt", true);
            }
            return new Bericht("Niet alle velden zijn ingevuld", false);

            
        }

        public bool MeldBezoekerUit(string email)
        {
            // TODO: Unit test
            Bezoeker bezoeker = _bezoekerRepository.GeefBezoekerOpEmail(email);
            if(bezoeker is not null)
            {
                // TODO: kunnen we geen Messega class maken en dit terug sturen??
                if (bezoeker.Aanwezig)
                {
                    bezoeker.MeldAf();
                    _afspraakRepository.UpdateAfspraak(bezoeker.BezoekerId);
                    _bezoekerRepository.UpdateBezoeker(bezoeker);
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
                Controleer.ControleBTW(btw);

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
