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


        public IReadOnlyList<Afspraak> GeefAlleAfspraken()
        {
            List<Afspraak> afspraaks = _afspraakRepository.GeefAlleAfspraken();
            return afspraaks.AsReadOnly();
        }

        public void OpUpdateAfspraak(object? sender, object e)
        {
            // We kunnen de mapper hier niet gebruiken
            //Afspraak afspraak = (IAfspraak)e
            //_afspraakRepository.UpdateAfspraak(afspraak):
        }

        public IReadOnlyList<Afspraak> ZoekOp(string zoekText)
        {
           return _afspraakRepository.ZoekAfspraakOp(zoekText).AsReadOnly();
        }

        public void UpdateAfspraak(Afspraak afspraak)
        {
            _afspraakRepository.UpdateAfspraak(afspraak);
        }    
    }
}
