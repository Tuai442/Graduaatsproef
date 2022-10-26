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
        int GeefAfspraakOpDatum(DateTime datum);
        List<Afspraak> GeefAlleAfspraken();
        void VoegAfspraakToe(Afspraak afspraak);
        void UpdateAfspraak(Afspraak afspraak);
        List<Afspraak> ZoekAfspraakOp(string zoekText);
        Afspraak GeefAfspraakOpEmail(string email);
        List<Afspraak> GeefAlleAanwezigeAfspraken();
    }
}
