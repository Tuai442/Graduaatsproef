using Controller.Interfaces;
using Controller.Interfaces.Models;
using Controller.Models;
using DebounceThrottle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Managers
{
    public class WerknemerManager
    {
        private IWerknemerRepository _werknemerRepository;

        public WerknemerManager(IWerknemerRepository werknemerRepository)
        {
            _werknemerRepository = werknemerRepository;
        }
        public IReadOnlyList<Werknemer> GeefAlleWerknemers()
        {
            return _werknemerRepository.GeefAlleWerknemers().AsReadOnly();
        }

        public IReadOnlyList<Werknemer> GeefWerknemersOpEmailBedrijf(string value)
        {
            return _werknemerRepository.GeefWerknemersOpEmailBedrijf(value).AsReadOnly();
        }

        public void UpdateWerknemer(Werknemer werknemer)
        {
            _werknemerRepository.UpdateWerknemer(werknemer);
        }

        public void VoegWerknemerToe(string voornaam, string achternaam, string email, string funttie,
            Bedrijf bedrijf)
        {
            //TODO - controle gegevens
            Werknemer werknemer = new Werknemer(voornaam, achternaam, email, funttie, bedrijf);
            _werknemerRepository.VoegWerknemerToe(werknemer);
        }

        public IReadOnlyList<Werknemer> ZoekOp(string zoekText)
        {
           return _werknemerRepository.ZoekOpWerknemers(zoekText);
        }
    }
}
