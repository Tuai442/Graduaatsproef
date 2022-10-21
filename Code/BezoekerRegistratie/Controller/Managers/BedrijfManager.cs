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
            Bedrijf bedrijf = new Bedrijf(naam, btw, adress, telefoon, email);
            _bedrijfRepository.VoegNieuwBedrijfToe(bedrijf);
        }

        public List<IBedrijf> GeefAlleBedrijven()
        {
            List<Bedrijf> bedrijven = _bedrijfRepository.GeefAlleBedrijven();
            return bedrijven.Select(x => (IBedrijf)x).ToList();
        }

        public List<IBedrijf> ZoekOp(string zoekText)
        {
            List<Bedrijf> bedrijf = _bedrijfRepository.ZoekBedrijfOp(zoekText);
            return bedrijf.Select(x => (IBedrijf)x).ToList();
        }

        public void VoegBedrijfToe(string naam, string btw, string email, string adres, string tel)
        {
            // TODO: Unit test
            Controleer.BtwNummerControle(btw);
            Controleer.ControleEmail(email);
            Bedrijf bedrijf = new Bedrijf(naam, btw, adres, tel, email);
            _bedrijfRepository.VoegNieuwBedrijfToe(bedrijf);
        }

    }
}
