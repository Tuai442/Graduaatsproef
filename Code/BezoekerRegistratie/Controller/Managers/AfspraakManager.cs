using Controller.Exceptions;
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
            List<Afspraak> afspraken = _afspraakRepository.GeefAlleAfspraken();
            return afspraken.AsReadOnly();
        }


        //TODO: methode uitwerken
        public void OpUpdateAfspraak(object? sender, object e)
        {
            // We kunnen de mapper hier niet gebruiken
            //Afspraak afspraak = (IAfspraak)e
            //_afspraakRepository.UpdateAfspraak(afspraak):
        }

        public IReadOnlyList<Afspraak> ZoekOp(string zoekText)
        {

            if (string.IsNullOrWhiteSpace(zoekText)) throw new AfspraakException("AfspraakManager - ZoekOp");
            return _afspraakRepository.ZoekAfspraakOp(zoekText).AsReadOnly();
        }

        public void UpdateAfspraak(Afspraak afspraak)
        {
            if (afspraak == null) throw new AfspraakException("AfspraakManager - UpdateAfspraak");
            _afspraakRepository.UpdateAfspraak(afspraak);
        }    

        public void sendEmail()
        {

            throw null;



        }

        
    }
}
