using Controller.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Interfaces
{
    public interface IAfspraakRepository
    {
        int GeefAfspraakOpBezoekerId(int bezoekerId);
        int GeefAfspraakOpDatum(DateTime datum);
        List<Afspraak> GeefAlleAfspraken();
        void VoegAfspraakToe(Bezoeker bezoeker, Werknemer contactPersoon, Bedrijf bedrijf, DateTime datum);
        void RegistreerAfspraak(Bezoeker bezoeker, Bedrijf bedrijf, Werknemer cpersson, DateTime now);
    }
}
