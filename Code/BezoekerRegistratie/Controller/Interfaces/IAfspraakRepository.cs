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
        Afspraak GeefAfspraakOpBezoekerId(int bezoekerId);
        int GeefAfspraakOpDatum(DateTime datum);
        List<Afspraak> GeefAlleAfspraken();
        void RegistreerAfspraak(Afspraak afspraak);
        Afspraak GeefAfspraakOp(int? id, string? naam, DateTime? datum); // Op deze manier kunnen we één methode maken en filter op meerdere parameters.
        void UpdateAfspraak(int bezoekerId);
    }
}
