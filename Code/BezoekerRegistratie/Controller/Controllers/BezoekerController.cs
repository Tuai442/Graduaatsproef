using Controller.Interfaces;
using Controller.Models;
using Controller.Models.Systeem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class BezoekerController: Controller
    {
        private Agenda _agenda;

        public BezoekerController(IWerknemerRepository werknemerRepository, IBezoekerRepository bezoekerRepository,
            IBedrijfRepository bedrijfRepository, IAfspraakRepository _afspraakRepository) :
           base(werknemerRepository, bezoekerRepository, bedrijfRepository, _afspraakRepository)
        {
            _agenda = new Agenda(_afspraakRepository);
        }

        public void SchrijfBezoekerUit(int bezoekerId)
        {
            Bezoeker bezoeker = _bezoekerRepository.GeefBezoekerOpId(bezoekerId);
            _systeem.SchrijfBezoekerUit(bezoeker);

        }

        public void MeldBezoekerAan(int bezoekerId)
        {
            Bezoeker bezoeker = _bezoekerRepository.GeefBezoekerOpId(bezoekerId);
            _systeem.MeldBezoekerAan(bezoeker);
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
            List<Bezoeker> bezoekers = GeefAlleBezoekers();
            foreach (Bezoeker bezoeker in bezoekers)
            {
                if(bezoeker.Voornaam == voornaam && bezoeker.Achternaam == achternaam)
                {
                    return true;
                }
            }
            return false;
        }

        public void VerwijderAfspraak(int afspraakId)
        {
            _agenda.VerwijderAfspraak(afspraakId);
        }

        public void UpdateAfspraak()
        {
            // TODO: update afpraak.
            _agenda.UpdateAfspraak();
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
            _agenda.MaakAfspraak(bezoeker, Cpersson, bedrijf, datum);
            return true;
        }
    }
}
