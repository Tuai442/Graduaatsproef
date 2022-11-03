﻿using Controller.Exceptions;
using Controller.Interfaces;
using Controller.Interfaces.Models;
using Controller.Models;
using System;
using System.Collections.Generic;
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
            List<Afspraak> afspraken =  _afspraakRepository.GeefAlleAanwezigeAfspraken();
            return afspraken.Select(x => x.Bezoeker).ToList().AsReadOnly();
        }

        public IReadOnlyList<Bezoeker> ZoekOp(string zoekText)
        {
            return _bezoekerRepository.ZoekBezoekersOp(zoekText).AsReadOnly();
        }

        public void MeldBezoekerAan(string vnBezoeker, string anBezoeker, string email, 
            string bedrijfBezoeker, string emailContactPersoon)
        {
            // TODO: Unit test
            Controleer.LegeVelden(vnBezoeker, anBezoeker, email, emailContactPersoon, bedrijfBezoeker);
            Controleer.ControleEmail(email);
            // Controleer.ControleIsBezoekerAlAanwezig(bezoeker);  <--- Moet er gecontroleerd worden of de bezoeker nog niet aanwezig is ???

            Bezoeker bezoeker = new Bezoeker(vnBezoeker, anBezoeker, email, bedrijfBezoeker);
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
    }
}
