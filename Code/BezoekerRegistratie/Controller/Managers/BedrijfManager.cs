using Controller.Exceptions;
using Controller.Interfaces;
using Controller.Interfaces.Models;
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

        public void VoegNieuwBedrijfToe(string naam, string btw, string adress, string telefoon, string email)
        {
            try
            {
                Controleer.BtwNummerControle(btw);
                Controleer.ControleTelefoon(telefoon);
                Controleer.ControleEmail(email);
            }
            catch(Exception ex)
            {
                throw new BedrijfException("VoegBedrijfToe", ex);
            }

            Bedrijf bedrijf = new Bedrijf(naam, btw, adress, telefoon, email);
            _bedrijfRepository.VoegNieuwBedrijfToe(bedrijf);
        }

        public IReadOnlyList<Bedrijf> GeefAlleBedrijvenInLijstItems()
        {
            return _bedrijfRepository.GeefAlleBedrijven().AsReadOnly();   
        }

        public IReadOnlyList<Bedrijf> GeefAlleBedrijven()
        {
            return _bedrijfRepository.GeefAlleBedrijven().AsReadOnly();
        }

        public IReadOnlyList<Bedrijf> ZoekOp(string zoekText)
        {
            // if (string.IsNullOrWhiteSpace(zoekText)) throw new BedrijfException("BM - ZoekOp");
            return _bedrijfRepository.ZoekBedrijfOp(zoekText).AsReadOnly();
            
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
            Controleer.ControleEmail(email);
            return _bedrijfRepository.GeefBedrijvenOpWerknemerEmail(email).AsReadOnly();
        }

        public void UpdateBedrijf(Bedrijf bedrijf)
        {
            if (bedrijf == null) throw new BedrijfException("BM - UpdateBedrijf");
            _bedrijfRepository.VoegNieuwBedrijfToe(bedrijf);
        }
    }
}
