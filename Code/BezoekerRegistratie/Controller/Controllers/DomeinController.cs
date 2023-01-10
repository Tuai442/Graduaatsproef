using Controller.Interfaces;
using Controller.Interfaces.Models;
using Controller.Managers;
using Controller.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public class DomeinController
    {
        //private IWerknemerRepository _werknemerRepository;
        //private IBezoekerRepository _bezoekerRepository;
        //private IBedrijfRepository _bedrijfRepository;
        //private IAfspraakRepository _afspraakRepository;
        //private IAlgemeneRepository _algemeneRepository;

        private BedrijfManager _bedrijfManager;
        private AfspraakManager _afspraakManager;
        private WerknemerManager _werknemerManager;
        private BezoekerManager _bezoekerManger;
        private EmailManager _emailManager;

        public DomeinController(IWerknemerRepository werknemerRepository, IBezoekerRepository bezoekerRepository,
            IBedrijfRepository bedrijfRepository, IAfspraakRepository afspraakRepository)
        {
            _bedrijfManager = new BedrijfManager(bedrijfRepository);
            _afspraakManager = new AfspraakManager(afspraakRepository);
            _werknemerManager = new WerknemerManager(werknemerRepository);
            _bezoekerManger = new BezoekerManager(bezoekerRepository, afspraakRepository, werknemerRepository, bedrijfRepository);
            _emailManager = new EmailManager();
        }

        public AfspraakManager GeefAfspraakManager()
        {
            return _afspraakManager;
        }

        public BedrijfManager GeefBedrijfManager()
        {
            return _bedrijfManager;
        }

        public BezoekerManager GeefBezoekerManager()
        {
            return _bezoekerManger;
        }

        public WerknemerManager GeefWerknemerManager()
        {
            return _werknemerManager;
        }
        public void SendEmail()
        {
            _emailManager.SendEmail(_afspraakManager.GeefaAlleopenstaandeAfsprakenVoorSendEmail());
        }

    }
}
