using Controller;
using Controller.Interfaces;
using Controller.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class TestMapper : IAfspraakRepository, IBedrijfRepository,
        IBezoekerRepository, IWerknemerRepository
    {

        public List<Bezoeker> bezoekers { get; set; }
        public List<Afspraak> afspraken { get; set; }

        public List <Bedrijf> bedrijven { get; set; }
        public List<Werknemer> werknemers { get; set; }
        public TestMapper()
        {

            bedrijven = new List<Bedrijf>
            {
                new Bedrijf("INEO Fenol", "btw", "getn", "99999", "ineoemail"),
                new Bedrijf("OLEON", "btw", "getn", "99999", "oldif"),
                new Bedrijf("test", "Btw", "testadress", "0000", "bedrijf.testemail")
            };

            bezoekers = new List<Bezoeker>
            {
                new Bezoeker("Jan", "Jansen", "janjansen@email", bedrijven[2]),
                new Bezoeker("Jaap", "Jansen", "janjansen@email", bedrijven[1])
            };
           

            werknemers = new List<Werknemer>
            {
                new Werknemer("Ben", "Tensen", "benemial", "Loodgieter", bedrijven[0]),
                new Werknemer("Rudy", "...", "rudy@email.com", "Suprivisor", bedrijven[1])
            };
        
            afspraken = new List<Afspraak>
            {
                new Afspraak(bezoekers[0], werknemers[1], bedrijven[0], new DateTime(2022, 11, 5) )
            };
        }

        public int GeefAfspraakOpBezoekerId(int bezoekerId)
        {
            throw new NotImplementedException();
        }

        public int GeefAfspraakOpDatum(DateTime datum)
        {
            throw new NotImplementedException();
        }

        public Bedrijf GeefBedrijfOpNaam(string bedrijfVanGebruiker)
        {
            throw new NotImplementedException();
        }

        public Bezoeker GeefBezoekerOpEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Bezoeker GeefBezoekerOpId(int id)
        {
            throw new NotImplementedException();
        }

        public Bezoeker GeefBezoekerOpNummerplaat(string nummerplaat)
        {
            throw new NotImplementedException();
        }

        public Bezoeker GeefBezoekerOpVolledigeNaam(string naam, string achternaam)
        {
            throw new NotImplementedException();
        }

        public List<Bezoeker> GeefAlleBezoekers()
        {
            return bezoekers;
        }

        public List<Afspraak> GeefAlleAfspraken()
        {
            return afspraken;
        }

        public List<Bedrijf> GeefAlleBedrijven()
        {
            return bedrijven;
        }

        public void VoegNieuwBedrijfToe(Bedrijf bedrijf)
        {
            bedrijven.Add(bedrijf);
        }

        public void VoegAfspraakToe(Bezoeker bezoeker, Werknemer contactPersoon, Bedrijf bedrijf, DateTime datum)
        {
            afspraken.Add(new Afspraak(bezoeker, contactPersoon, bedrijf, datum));

        }

        public Werknemer GeefWerknemerOpNaam(string contactPersoon)
        {
            throw new NotImplementedException();
        }

        public Werknemer GeefWerknemerOpId(int id)
        {
            
            foreach(Werknemer werknemer in werknemers)
            {
                if(werknemer.WerknemerId == id)
                {
                    return werknemer;
                }
            }
            return null;
        }

        public List<Werknemer> GeefAlleWerknemers()
        {
            return werknemers;
        }

        public Bedrijf GeefBedrijfOpId(int bedrijfNaam)
        {
            throw new NotImplementedException();
        }

        public Persoon GeefPersoonOpVolledigeNaam(string naam, string achternaam)
        {
            throw new NotImplementedException();
        }

        public void RegistreerAfspraak(Bezoeker bezoeker, Bedrijf bedrijf, Werknemer cpersson, DateTime now)
        {
            throw new NotImplementedException();
        }

        public void RegistreerAfspraak(Afspraak afspraak)
        {
            throw new NotImplementedException();
        }

        public Afspraak GeefAfspraakOp(int? id, string? naam, DateTime? datum)
        {
            throw new NotImplementedException();
        }

        public void UpdateBezoeker(Bezoeker bezoeker)
        {
            throw new NotImplementedException();
        }
    }
}
