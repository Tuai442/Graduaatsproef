using Controller.Exceptions;
using Controller.Exceptions.Manager;
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
            try
            {
                List<Afspraak> afspraken = _afspraakRepository.GeefAlleAfspraken();
                return afspraken.AsReadOnly();
            }
            catch (Exception ex)
            {
                throw new AfspraakManagerException("GeefAlleAfspraken: " + ex.Message, ex);
            }
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
            try
            {
                if (string.IsNullOrWhiteSpace(zoekText)) throw new AfspraakException("AfspraakManager - ZoekOp");
                return _afspraakRepository.ZoekAfspraakOp(zoekText).AsReadOnly();
            }catch(Exception ex)
            {
                throw new AfspraakManagerException("ZoekOp: " + ex.Message, ex);
            }
        }

        public void UpdateAfspraak(Afspraak afspraak)
        {
            try
            {
                if (afspraak == null) throw new AfspraakException("AfspraakManager - UpdateAfspraak");
                _afspraakRepository.UpdateAfspraak(afspraak);
            }catch(Exception ex)
            {
                throw new AfspraakManagerException("UpdateAfspraak: " + ex.Message, ex);
            }
        }

        public List<Afspraak> GeefaAlleopenstaandeAfsprakenVoorSendEmail()
        {
            try
            {
                return _afspraakRepository.GeefOpenstaandeAfspraak();
            }catch(Exception ex)
            {
                throw new AfspraakManagerException("GeefaAlleopenstaandeAfsprakenVoorSendEmail: " + ex.Message, ex);
            }

        }

        //TODO: wordt niet gebruikt
        public void VerwijderAfspraak(int index)
        {
            throw new NotImplementedException();
        }
    }
}
