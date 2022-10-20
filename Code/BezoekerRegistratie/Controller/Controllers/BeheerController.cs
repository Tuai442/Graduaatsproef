using Controller.Interfaces;
using Controller.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class BeheerController
    {
        private IWerknemerRepository _werknemerRepository;
        private IBezoekerRepository _bezoekerRepository;
        private IBedrijfRepository _bedrijfRepository;
        private IAfspraakRepository _afspraakRepository;
        private IAlgemeneRepository _algemeneRepository;
        public BeheerController(IWerknemerRepository werknemerRepository, IBezoekerRepository bezoekerRepository, 
            IBedrijfRepository bedrijfRepository, IAfspraakRepository afspraakRepository, IAlgemeneRepository algemeneRepository)
        {
            _werknemerRepository = werknemerRepository;
            _bezoekerRepository = bezoekerRepository;
            _bedrijfRepository = bedrijfRepository;
            _afspraakRepository = afspraakRepository;
            _algemeneRepository = algemeneRepository;
        }

        public List<string> GeefAlleWerknemers()
        {
            return new List<string>();
        }

        public void UpdateGebruiker(int bezoekerId, string naam=null, string achternaam=null, string email=null, string nummerplaat=null, string bedrijfVanGebruiker=null)
        {
            // TODO: update bezoeker.
            Bezoeker bezoeker = _bezoekerRepository.GeefBezoekerOpId(bezoekerId);
        }

        public void VoegNieuwBedrijfToe(string naam, string btw, string adress, string telefoon, string email)
        {
            Bedrijf bedrijf = new Bedrijf(naam, btw, adress, telefoon, email);
            _bedrijfRepository.VoegNieuwBedrijfToe(bedrijf);
        }

        public List<Dictionary<string, string>> GeefAlleBezoekersNamen()
        {
            List<Bezoeker> bezoekers = _bezoekerRepository.GeefAlleBezoekers();
            List<Dictionary<string, string>> result = new List<Dictionary<string, string>>();   
            foreach (Bezoeker bezoeker in bezoekers)
            {
                result.Add(bezoeker.ToDictionary());
            }
            return result;
        }

        public List<string> GeefAlleAanwezigen()
        {
            List<Bezoeker> bezoekers = _bezoekerRepository.GeefAlleBezoekers();
            List<string> aanwezigen = new List<string>();
            foreach(Bezoeker bezoeker in bezoekers)
            {
                if (bezoeker.Aanwezig)
                {
                    aanwezigen.Add(bezoeker.ToString());
                }
            }
            return aanwezigen;
        }

        public List<object> GeefAlleData()
        {
            List<ITabelData> data = _algemeneRepository.GetAll();
            List<object> tabelData = new List<object>();

            foreach(ITabelData d in data)
            {
                tabelData.Add(d.GeefTabelData());
            }
            return tabelData;

        }


        // TabelData
        public List<object> GeefAlleAanwezigeBezoekersInTabelData()
        {
            List<object> list = new List<object>();
            List<Bezoeker> bezoekers = _bezoekerRepository.GeefAlleAanwezigeBezoekers();
            foreach (Bezoeker bezoeker in bezoekers)
            {
                list.Add(bezoeker);
            }
            return list;
        }

        public List<object> GeefAlleBedrijvenInTabelData()
        {
            List<object> list = new List<object>();
            List<Bedrijf> bedrijven = _bedrijfRepository.GeefAlleBedrijven();
            foreach (Bedrijf bedrijf in bedrijven)
            {
                list.Add(bedrijf.GeefTabelData());
            }
            return list;
        }

        public List<object> GeefAlleWerknemersInTabelData()
        {
            List<object> list = new List<object>();
            List<Werknemer> werknemers = _werknemerRepository.GeefAlleWerknemers();
            foreach (Werknemer werknemer in werknemers)
            {
                list.Add(werknemer.GeefTabelData());
            }
            return list;
        }

        public List<object> GeefAlleBezoekersInTabelData()
        {
            List<object> list = new List<object>();
            List<Bezoeker> bezoekers = _bezoekerRepository.GeefAlleBezoekers();
            foreach (Bezoeker bezoeker in bezoekers)
            {
                list.Add(bezoeker);
            }
            return list;
        }

        public List<object> GeefAlleAfsprakenInTabelData()
        {
            List<object> list = new List<object>();
            List<Afspraak> afspraaks = _afspraakRepository.GeefAlleAfspraken();
            foreach (Afspraak afspraak in afspraaks)
            {
                list.Add(afspraak.GeefTabelData());
            }
            return list;
        }


        // Updates
        public void UpdateBezoeker(object obj)
        {
            Bezoeker bezoeker = (Bezoeker)obj;
            _bezoekerRepository.UpdateBezoeker(bezoeker);
        }
        public void UpdateWerknemer(object obj)
        {
            
        }
    }
}
