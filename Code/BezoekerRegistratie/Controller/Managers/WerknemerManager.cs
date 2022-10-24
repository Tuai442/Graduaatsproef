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
    public class WerknemerManager
    {
        private IWerknemerRepository _werknemerRepository;

        public WerknemerManager(IWerknemerRepository werknemerRepository)
        {
            _werknemerRepository = werknemerRepository;
        }
        public List<IWerknemer> GeefAlleWerknemers()
        {
            List<Werknemer> werknemers = _werknemerRepository.GeefAlleWerknemers();
            return werknemers.Select(x => (IWerknemer)x).ToList();
        }

        public void UpdateWerknemer(object obj)
        {

        }

        public List<IWerknemer> ZoekOp(string zoekText)
        {
            List<Werknemer> werknemers = _werknemerRepository.ZoekOpWerknemers(zoekText);
            return werknemers.Select(x => (IWerknemer)x).ToList();
        }
    }
}
