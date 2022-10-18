using Controller.Interfaces;
using Controller.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class Controller
    {
        protected IWerknemerRepository _werknemerRepository;
        protected IBezoekerRepository _bezoekerRepository;
        protected IBedrijfRepository _bedrijfRepository;
        protected IAfspraakRepository _afspraakRepository;


        protected Controller(IWerknemerRepository werknemerRepository, IBezoekerRepository bezoekerRepository,
            IBedrijfRepository bedrijfRepository, IAfspraakRepository afspraakRepository)
        {
            _werknemerRepository = werknemerRepository;
            _bezoekerRepository = bezoekerRepository;
            _bedrijfRepository = bedrijfRepository;
            _afspraakRepository = afspraakRepository;
        }

        public int GeefBezoekersId(string naam = null, string achternaam = null, string email = null, string nummerplaat = null)
        {
            // TODO: Moet beter, wat als je wilt zoeken op naam en nummerplaat of achtenaam en nummerplaat.
            // return 0 als niks gevonden is;

            Bezoeker bezoeker = null;
            if (!string.IsNullOrEmpty(naam) && !string.IsNullOrEmpty(achternaam))
            {
                bezoeker = (Bezoeker)_bezoekerRepository.GeefPersoonOpVolledigeNaam(naam, achternaam);
            }
            else if (!string.IsNullOrEmpty(email))
            {
                bezoeker = (Bezoeker)_bezoekerRepository.GeefBezoekerOpEmail(email);
            }
            else if (!string.IsNullOrEmpty(nummerplaat))
            {
                bezoeker = (Bezoeker)_bezoekerRepository.GeefBezoekerOpNummerplaat(nummerplaat);
            }
            if (bezoeker != null)
            {
                return bezoeker.BezoekerId;
            }
            return 0;
        }

        //public int GeefAfspaarkId(int bezoekerId = 0, DateTime datum = new DateTime())
        //{
        //    // TODO: Moet beter, wat als je wilt zoeken op naam en datum ...
        //    // return 0 als niks gevonden is;
        //    //int id = 0;
        //    //if (bezoekerId != null)
        //    //{
        //    //    id = _afspraakRepository.GeefAfspraakOpBezoekerId(bezoekerId);
        //    //}
        //    //else if (datum != null)
        //    //{
        //    //    id = _afspraakRepository.GeefAfspraakOpDatum(datum);
        //    //}
        //    //return id;
        //}

        public Dictionary<string, int> GeefAlleGelijkbareNamen(string totaleWoord)
        {

            Dictionary<string, int> naamList = new Dictionary<string, int>();
            foreach (Bezoeker bezoeker in _bezoekerRepository.GeefAlleBezoekers())
            {
                string naam = bezoeker.Voornaam + " " + bezoeker.Achternaam;
                int matchedKarakters = 0;
                for (int i = 0; i < totaleWoord.Length; i++)
                {
                    if (i < naam.Length)
                    {
                        if (Char.ToLower(totaleWoord[i]) == Char.ToLower(naam[i]))
                        {
                            matchedKarakters ++;
                        }
                        else
                        {
                            matchedKarakters = 0;
                        }
                    }
                    else
                    {
                        matchedKarakters = 0;
                    }
                }

                if (matchedKarakters > 0)
                {
                    naamList.Add(naam, matchedKarakters);
                }
            }
            return naamList;
            
        }

        protected List<Bezoeker> GeefAlleBezoekers()
        {
            return _bezoekerRepository.GeefAlleBezoekers();
        }

        public List<string> GeefAlleContactPersonen()
        {
            List<Werknemer> bedrijfList = _werknemerRepository.GeefAlleWerknemers();
            List<string> result = new List<string>();
            foreach (Werknemer werknemer in bedrijfList)
            {
                result.Add(werknemer.GeefVolledigeNaam());
            }
            return result;
        }

        public List<string> GeefAlleBedrijfsNamen()
        {
            List<Bedrijf> bedrijven = _bedrijfRepository.GeefAlleBedrijven();
            List<string> result = new List<string>();
            foreach (Bedrijf bezoeker in bedrijven)
            {
                result.Add(bezoeker.Naam);
            }
            return result;
        }


    }
}
