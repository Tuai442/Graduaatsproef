﻿using Controller.Interfaces;
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
        public BeheerController(IWerknemerRepository werknemerRepository, IBezoekerRepository bezoekerRepository, 
            IBedrijfRepository bedrijfRepository, IAfspraakRepository afspraakRepository)
        {
            _werknemerRepository = werknemerRepository;
            _bezoekerRepository = bezoekerRepository;
            _bedrijfRepository = bedrijfRepository;
            _afspraakRepository = afspraakRepository;
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

        public List<object> GeefAlleBezoekersInObjecten()
        {
            List<object> list = new List<object>(); 
            List<Bezoeker> bezoekers = _bezoekerRepository.GeefAlleBezoekers();
            foreach(Bezoeker bezoeker in bezoekers)
            {
                list.Add(bezoeker.GeefTabelData());
            }
            return list;
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


        
      
    }
}
