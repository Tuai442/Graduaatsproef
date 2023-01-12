using Controller.Exceptions;
using Controller.Exceptions.Manager;
using Controller.Interfaces;
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
            try
            {
                return _werknemerRepository.GeefAlleWerknemers().AsReadOnly();
            }
            catch(Exception ex)
            {
                throw new WerknemerManagerException("Kan werknemers niet geven", ex);
            }
        }

        public IReadOnlyList<Werknemer> GeefWerknemersOpEmailBedrijf(string value)
        {
            try
            {
                return _werknemerRepository.GeefWerknemersOpEmailBedrijf(value).AsReadOnly();
            }
            catch (Exception ex)
            {
                throw new WerknemerManagerException("Kan werknemers niet op email van bedrijf geven", ex);
            }

        }

        public void UpdateWerknemer(Werknemer werknemer)
        {
            try
            {
                if (!_werknemerRepository.HeeftWerknemer(werknemer.Id)) throw new WerknemerManagerException("Update Werknemer - kan werknemer niet vinden.");
                Werknemer werkemerDB = _werknemerRepository.GeefWerknemerOpId(werknemer.Id);
                if (werknemer == werkemerDB) throw new WerknemerManagerException("Update Werknemer - Geen veranderingen gemaakt.");
                _werknemerRepository.UpdateWerknemer(werknemer);
              
            }
            catch (WerknemerManagerException) { throw; }
            catch (Exception ex)
            {
                throw new WerknemerManagerException("Kan werknemers niet updaten", ex);
            }
           
        }

        public void VerwijderWerknemer(int id)
        {
            try
            {
                if (!_werknemerRepository.HeeftWerknemer(id)) throw new WerknemerManagerException("Verwijder Werknemer - kan werknemer niet vinden.");
                _werknemerRepository.ZetNonActiefWerknemer(id);
            }
            catch(WerknemerManagerException) { throw; }
            catch (Exception ex)
            {
                throw new WerknemerManagerException("Kan werknemers niet verwijderen", ex);
            }
        }

        public void VoegWerknemerToe(string voornaam, string achternaam, string email, string functie, Bedrijf bedrijf)
        {
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
            catch(ControleerException) { throw; }
            catch (Exception ex)
            {

                throw new WerknemerManagerException("Kan geen werknemer toevoegen", ex);
            }


        }

        public IReadOnlyList<Werknemer> ZoekOp(string zoekText)
        {
            try
            {
                return _werknemerRepository.ZoekOpWerknemers(zoekText);

            }
            catch (Exception ex)
            {
                throw new WerknemerManagerException("Kan geen werknemers niet vinden", ex);

            }
        }
    }
}
