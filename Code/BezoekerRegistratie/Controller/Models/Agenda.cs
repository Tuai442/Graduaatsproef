using Controller.Interfaces;
using Controller.Models;

namespace Controller
{
    internal class Agenda
    {
        private IAfspraakRepository _afspraakRepository;

        public Agenda(IAfspraakRepository afspraakRepository)
        {
            _afspraakRepository = afspraakRepository;
        }

        internal void VerwijderAfspraak(int afspraakId)
        {
            throw new NotImplementedException();
        }

        internal void UpdateAfspraak()
        {
            throw new NotImplementedException();
        }

        internal void MaakAfspraak(Bezoeker bezoeker, Werknemer contactPersoon, Bedrijf bedrijf, DateTime datum)
        {
            // TODO: controle afspraken mogen niet overlappen, afspraken mogen niet inhet verleden zijn.
            _afspraakRepository.VoegAfspraakToe(bezoeker, contactPersoon, bedrijf, datum);
        }

        private void HerlaadAgenda()
        {
        }
    }
}