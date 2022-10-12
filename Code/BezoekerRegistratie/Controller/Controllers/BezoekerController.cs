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

        public bool MeldBezoekerAan(string vnBezoeker, string anBezoeker, string vnContactP, string anContactP, string bedrijfsNaam)
        {
            Bezoeker bezoeker = (Bezoeker)_bezoekerRepository.GeefPersoonOpVolledigeNaam(vnBezoeker, anBezoeker);
            Werknemer contactPersoon = (Werknemer)_werknemerRepository.GeefPersoonOpVolledigeNaam(vnContactP, anContactP);
            Bedrijf bedrijf = _bedrijfRepository.GeefBedrijfOpNaam(bedrijfsNaam);

            if (Controleer.ControleIsBezoekerAlAanwezig(bezoeker))
            {
                return false;
            }

            bezoeker.MeldAan();
            Afspraak afspraak = new Afspraak(bezoeker, contactPersoon, bedrijf, DateTime.Now);
            _bezoekerRepository.UpdateBezoeker(bezoeker);
            _afspraakRepository.RegistreerAfspraak(afspraak);
            return true;
        }

        public void MeldBezoekerUit(int bezoekerId)
        {
            Bezoeker bezoeker = _bezoekerRepository.GeefBezoekerOpId(bezoekerId);
            Controleer.ControleIsBezoekerNietAanwezig(bezoeker);
            bezoeker.MeldAf();
            _bezoekerRepository.UpdateBezoeker(bezoeker);
        }

        public void VoegBedrijfToe(string naam, string btw, string email, string adres, string tel)
        {
            Controleer.BtwNummerControle(btw);
            Controleer.EmailControle(email);
            Bedrijf bedrijf = new Bedrijf(naam, btw, adres, tel, email);
            _bedrijfRepository.VoegNieuwBedrijfToe(bedrijf);
        }

        public string GeefAfspraakInfoOpBezoekerId(int bezoekerId)
        {

            Afspraak afspraak = _afspraakRepository.GeefAfspraakOp(id: bezoekerId, naam: null, datum: null);
            return afspraak.ToString();
        }

        
    }
}
