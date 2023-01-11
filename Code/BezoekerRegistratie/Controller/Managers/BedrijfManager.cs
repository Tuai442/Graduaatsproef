using Controller.Exceptions;
using Controller.Exceptions.Manager;
using Controller.Interfaces;
using Controller.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Managers
{
    public class BedrijfManager
    {
        private IBedrijfRepository _bedrijfRepository;

        public BedrijfManager(IBedrijfRepository bedrijfRepository)
        {
            _bedrijfRepository = bedrijfRepository;
        }

        public void VoegNieuwBedrijfToe(string naam, string btw, string adres, string telefoon, string email)
        {
            try
            {
                Controleer.SetStringParameters(naam);
                Controleer.SetStringParameters(adres);
                Controleer.BtwNummerControle(btw);
                Controleer.ControleTelefoon(telefoon);
                Controleer.ControleEmail(email);

                Bedrijf bedrijf = new Bedrijf(naam, btw, adres, telefoon, email);
                _bedrijfRepository.VoegNieuwBedrijfToe(bedrijf);
            }
            catch (Exception ex)
            {
                throw new BedrijfManagerException("Kan bedrijf niet toevoegen.", ex);
            }
        }

        public IReadOnlyList<Bedrijf> GeefAlleBedrijven()
        {
            try
            {
                return _bedrijfRepository.GeefAlleBedrijven().AsReadOnly();
            }
            catch (Exception ex)
            {
                throw new BedrijfManagerException("Kan bedrijven niet ophalen", ex);
            }

        }

        public IReadOnlyList<Bedrijf> ZoekOp(string zoekText)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(zoekText)) throw new BedrijfException("BM - ZoekOp");
                return _bedrijfRepository.ZoekBedrijfOp(zoekText).AsReadOnly();
            }
            catch (BedrijfException) { throw; }
            catch (Exception ex)
            {
                throw new BedrijfManagerException("Kan bedrijf niet opzoeken", ex);
            }


        }

        //TODO: dubbele methode
        //public void VoegBedrijfToe(string naam, string btw, string email, string adres, string tel)
        //{
        //    // TODO: Unit test
        //    Controleer.BtwNummerControle(btw);
        //    Controleer.ControleEmail(email);
        //    Bedrijf bedrijf = new Bedrijf(naam, btw, adres, tel, email);
        //    _bedrijfRepository.VoegNieuwBedrijfToe(bedrijf);
        //}

        public IReadOnlyList<Bedrijf> GeefBedrijvenOpEmailWerknemer(string email)
        {
            try
            {
                Controleer.ControleEmail(email);
                return _bedrijfRepository.GeefBedrijvenOpWerknemerEmail(email).AsReadOnly();
            }
            catch (Exception ex)
            {
                throw new BedrijfManagerException("Kan bedrijf op email van werknemer niet vinden", ex);
            }

        }

        //TODO: dubbel opslaan en niet updaten
        public void UpdateBedrijf(Bedrijf bedrijf)
        {
            try
            {
                if (bedrijf == null) throw new BedrijfException("BM - UpdateBedrijf");
                
                _bedrijfRepository.UpdateBedrijf(bedrijf);
            }
            catch (BedrijfException) { throw; }
            catch (Exception ex)
            {
                throw new BedrijfManagerException("Kan bedrijf niet updaten", ex);
            }

        }

        public Bedrijf GeefBedrijfOpEmail(string email)
        {
            try
            {
                return _bedrijfRepository.GeefBedrijfOpEmail(email);
            }
            catch (Exception ex)
            {
                throw new BedrijfManagerException("Kan bedrijf niet op email geven", ex);
            }

        }

        public Bedrijf GeefBedrijfViaNaam(string value)
        {
            try
            {
                return _bedrijfRepository.GeefBedrijfViaNaam(value);
            }
            catch (Exception ex)
            {
                throw new BedrijfManagerException("Kan bedrijf niet via naam geven", ex);
            }
        }

        //TODO: wordt niet gebruikt / wel 1 ref?
        public void VerwijderBedrijf(int id)
        {
            try
            {
                _bedrijfRepository.ZetBedrijfNonActiefBedrijf(id);
            }
            catch (Exception ex)
            {
                throw new BedrijfManagerException("Kan bedrijf niet verwijderen", ex);
            }
        }
    }
}
