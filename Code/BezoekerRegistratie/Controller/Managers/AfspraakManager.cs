using Controller.Interfaces;
using Controller.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Managers
{
    public class AfspraakManager
    {
        private IAfspraakRepository _afspraakRepository;

        public AfspraakManager(IAfspraakRepository afspraakRepository)
        {
            _afspraakRepository = afspraakRepository;
        }

        public List<IAfspraak> GeefAlleAfspraken()
        {
            List<Afspraak> afspraaks = _afspraakRepository.GeefAlleAfspraken();
            return afspraaks.Select(x => (IAfspraak)x).ToList();

        }

        public List<IAfspraak> ZoekOp(string zoekText)
        {
            List<Afspraak> afspraaks = _afspraakRepository.ZoekAfspraakOp(zoekText);
            return afspraaks.Select(x => (IAfspraak)x).ToList();
        }
    }
}
