using Controller.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Interfaces
{
    public interface IWerknemerRepository: IPersoonRepository
    {
        Werknemer GeefWerknemerOpNaam(string contactPersoon);
        Werknemer GeefWerknemerOpId(int id);
        List<Werknemer> GeefAlleWerknemers();
        List<Werknemer> ZoekOpWerknemers(string zoekText);
        Werknemer GeefWerknemerOpEmail(string email);
        List<Werknemer> GeefWerknemersOpEmailBedrijf(string value);
        void UpdateWerknemer(Werknemer werknemer);
    }
}
