using Controller.Exceptions;
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

        public void VoegWerknemerToe(string voornaam, string achternaam, string email, string functie,
            Bedrijf bedrijf)
        {
            //TODO - controle gegevens
            try
            {
                Controleer.ControleEmail(bedrijf.Email);
                Controleer.SetStringParameters(bedrijf.Naam);
                Controleer.BtwNummerControle(bedrijf.Btw);
                Controleer.SetStringParameters(bedrijf.Adres);
                Controleer.ControleTelefoon(bedrijf.Telefoon);

                Controleer.ControleEmail(email);
                Controleer.SetStringParameters(voornaam);
                Controleer.SetStringParameters(achternaam);
                Controleer.SetStringParameters(functie);

                Werknemer werknemer = new Werknemer(voornaam, achternaam, email, functie, bedrijf);
                _werknemerRepository.VoegWerknemerToe(werknemer);
            }
            catch (Exception ex)
            {

                throw new ControleerException(ex.Message);
            }


        }

        public IReadOnlyList<Werknemer> ZoekOp(string zoekText)
        {
            return _werknemerRepository.ZoekOpWerknemers(zoekText);
        }
    }
}
