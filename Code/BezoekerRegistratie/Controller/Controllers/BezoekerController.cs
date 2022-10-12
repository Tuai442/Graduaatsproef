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

        public void SchrijfBezoekerUit(int bezoekerId)
        {
            Bezoeker bezoeker = _bezoekerRepository.GeefBezoekerOpId(bezoekerId);

        }

        public void MeldBezoekerAan(int bezoekerId)
        {
            Bezoeker bezoeker = _bezoekerRepository.GeefBezoekerOpId(bezoekerId);
        }

        public bool VoegBedrijfToe(string naam, string btw, string email, string adres, string tel)
        {
            
            Bedrijf bedrijf = new Bedrijf(naam, btw, adres, tel, email);
            _bedrijfRepository.VoegNieuwBedrijfToe(bedrijf);
            return true;
        }

        public bool RegistreerBezoeker(string voornaam, string achternaam, string email, string bedrijf, string nummerplaat)
        {
            return true;
        }

        public bool LogBezoekerIn(string voornaam, string achternaam, string ww="")
        {
            List<Bezoeker> bezoekers = _bezoekerRepository.GeefAlleBezoekers();
            foreach (Bezoeker bezoeker in bezoekers)
            {
                if(bezoeker.Voornaam == voornaam && bezoeker.Achternaam == achternaam)
                {
                    return true;
                }
            }
            return false;
        }

        public string GeefAfspraakInfoOpBezoekerId(int bezoekerId)
        {
            List<Afspraak> afspraken = _afspraakRepository.GeefAlleAfspraken();
            foreach(Afspraak afspraak in afspraken)
            {
                if (afspraak.Bezoeker.BezoekerId == bezoekerId)
                {
                    return afspraak.ToString();
                }
            }
            return "Geen afspraken gevonden";
        }

        public List<string> GeefAttributenVanBedrijf()
        {
            return Bedrijf.GeefAttributen();
        }

        public bool MaakNieuweAfspraak(string voornaam, string achternaam, DateTime datum,
            string bedrijfNaam, string contactPersoonVoornaam, string contactPersoonAchternaam)
        {
            Bezoeker bezoeker = (Bezoeker)_bezoekerRepository.GeefPersoonOpVolledigeNaam(voornaam, achternaam);
            Bedrijf bedrijf = _bedrijfRepository.GeefBedrijfOpNaam(bedrijfNaam);
            Werknemer Cpersson = (Werknemer)_werknemerRepository.GeefPersoonOpVolledigeNaam(contactPersoonVoornaam, contactPersoonAchternaam);

            _afspraakRepository.RegistreerAfspraak(bezoeker, bedrijf, Cpersson, DateTime.Now);
            return true;
        }

        public List<string> GeefAlleBedrijfsNamen()
        {
            throw new NotImplementedException();
        }
    }
}
