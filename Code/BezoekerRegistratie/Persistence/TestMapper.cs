//using Controller;
//using Controller.Interfaces;
//using Controller.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Persistence
//{
//    public class TestMapper : IAfspraakRepository, IBedrijfRepository,
//        IBezoekerRepository, IWerknemerRepository, IAlgemeneRepository
//    {
//        private string dummyDataBezoekerPath = @"Bezoekers.csv";
//        private string dummyDataWerknemerPath = @"werknemers.csv";
//        public List<Bezoeker> bezoekers { get; set; }
//        public List<Afspraak> afspraken { get; set; }

//        public List <Bedrijf> bedrijven { get; set; }
//        public List<Werknemer> werknemers { get; set; }
//        public TestMapper()
//        {
//            bezoekers = new List<Bezoeker>();
//            afspraken = new List<Afspraak>();
//            bedrijven = new List<Bedrijf>();
//            werknemers = new List<Werknemer>();
//            LaadDummyData();
            
            
//        }

//        private void LaadDummyData()
//        {
//            // Laad Bezoekers
//            using (StreamReader sr = new StreamReader(dummyDataBezoekerPath))
//            {
//                string line;
//                bool skipHeader = true;
//                while ((line = sr.ReadLine()) != null)
//                {
//                    if (!skipHeader)
//                    {
//                        var split = line.Split(",");
//                        string voornaam = split[2];
//                        string achternaam = split[3];
//                        string bedrijf = split[6];
//                        bool aanwezig = bool.Parse(split[7]);

//                        if (voornaam != "")
//                        {
//                            Bezoeker bezoeker = new Bezoeker(voornaam, achternaam, $"{voornaam}.{achternaam}@email.com", bedrijf, aanwezig);
//                            bezoekers.Add(bezoeker);
//                        }
                           
//                    }
//                    skipHeader = false;


//                }
//            }

//            // Laad Werknemers
//            using (StreamReader sr = new StreamReader(dummyDataWerknemerPath))
//            {
//                string line;
//                bool skipHeader = true;
//                while ((line = sr.ReadLine()) != null)
//                {
//                    if (!skipHeader)
//                    {
//                        var split = line.Split(",");
//                        string voornaam = split[1];
//                        string achternaam = split[2];
//                        string email = $"{voornaam}.{achternaam}@email.com";
//                        string functie = split[3];
//                        string bedrijf = split[5];
//                        Bedrijf bedrijf1 = new Bedrijf(bedrijf, "0000", "/", "/", $"{bedrijf}@email.com");
//                        bedrijven.Add(bedrijf1);
//                        if(voornaam != "")
//                        {
//                            Werknemer werknemer = new Werknemer(voornaam, achternaam, email, functie, bedrijf1);
//                            werknemers.Add(werknemer);
//                        }
                        
//                    }
//                    skipHeader = false;


//                }
//            }
//        }

//        public Afspraak GeefAfspraakOpBezoekerId(int bezoekerId)
//        {
//            return null;
//        }

//        public int GeefAfspraakOpDatum(DateTime datum)
//        {
//            throw new NotImplementedException();
//        }

//        public Bedrijf GeefBedrijfOpNaam(string bedrijfVanGebruiker)
//        {
//            foreach(Bedrijf bedrijf in bedrijven)
//            {
//                if(bedrijfVanGebruiker == bedrijf.Naam)
//                {
//                    return bedrijf;
//                }
//            }
//            return null;
//        }

//        public Bezoeker GeefBezoekerOpEmail(string email)
//        {
//            foreach(Bezoeker bezoeker in bezoekers)
//            {
//                if(bezoeker.Email == email)
//                {
//                    return bezoeker;
//                }
//            }
//            return null;
//        }

//        public Bezoeker GeefBezoekerOpId(int id)
//        {
//            throw new NotImplementedException();
//        }

//        public Bezoeker GeefBezoekerOpNummerplaat(string nummerplaat)
//        {
//            throw new NotImplementedException();
//        }

//        public Bezoeker GeefBezoekerOpVolledigeNaam(string naam, string achternaam)
//        {
//            throw new NotImplementedException();
//        }

//        public List<Bezoeker> GeefAlleBezoekers()
//        {
//            return bezoekers;
//        }

//        public List<Afspraak> GeefAlleAfspraken()
//        {
//            return afspraken;
//        }

//        public List<Bedrijf> GeefAlleBedrijven()
//        {
//            return bedrijven;
//        }

//        public void VoegNieuwBedrijfToe(Bedrijf bedrijf)
//        {
//            bedrijven.Add(bedrijf);
//        }

//        public void VoegAfspraakToe(Bezoeker bezoeker, Werknemer contactPersoon, Bedrijf bedrijf, DateTime datum)
//        {
            

//        }

//        public Werknemer GeefWerknemerOpNaam(string contactPersoon)
//        {
//            throw new NotImplementedException();
//        }

//        public Werknemer GeefWerknemerOpId(int id)
//        {
            
//            foreach(Werknemer werknemer in werknemers)
//            {
//                if(werknemer.WerknemerId == id)
//                {
//                    return werknemer;
//                }
//            }
//            return null;
//        }

//        public List<Werknemer> GeefAlleWerknemers()
//        {
//            return werknemers;
//        }

//        public Bedrijf GeefBedrijfOpId(int bedrijfNaam)
//        {
//            throw new NotImplementedException();
//        }

//        public Persoon GeefPersoonOpVolledigeNaam(string naam, string achternaam)
//        {
//            foreach(Bezoeker bezoeker in bezoekers)
//            {
//                if(bezoeker.GeefVolledigeNaam() == (naam + achternaam))
//                {
//                    return bezoeker;
//                }
//            }
//            foreach (Werknemer werknemer in werknemers)
//            {
//                if (werknemer.GeefVolledigeNaam() == (naam + achternaam))
//                {
//                    return werknemer;
//                }
//            }
//            return null;
//        }

//        public void RegistreerAfspraak(Bezoeker bezoeker, Bedrijf bedrijf, Werknemer cpersson, DateTime now)
//        {
//            throw new NotImplementedException();
//        }

//        public void RegistreerAfspraak(Afspraak afspraak)
//        {
          
//        }

//        public Afspraak GeefAfspraakOp(int? id, string? naam, DateTime? datum)
//        {
//            throw new NotImplementedException();
//        }

//        public void UpdateBezoeker(Bezoeker bezoeker)
//        {
//            List<Bezoeker> temp = new List<Bezoeker>(bezoekers);
//            for(int i = 0; i < temp.Count; i++)
//            {
//                Bezoeker b = temp[i];
//                if (bezoeker.Email == b.Email)
//                {
//                    bezoekers[i] = bezoeker;
//                }
//            }
            
//        }

//        public List<Bezoeker> GeefAlleAanwezigeBezoekers()
//        {
//            List<Bezoeker> result = new List<Bezoeker>();
//            foreach(Bezoeker bezoeker in bezoekers)
//            {
//                if (bezoeker.Aanwezig)
//                {
//                    result.Add(bezoeker);
//                }
                
//            }
//            return result;
//        }

//        //public List<ITabelData> GetAll()
//        //{
//        //    List<ITabelData> tabelData = new List<ITabelData>();
//        //    foreach(Bezoeker bezoeker in bezoekers)
//        //    {
//        //        tabelData.Add(bezoeker);
//        //    }
//        //    foreach (Werknemer werknemer in werknemers)
//        //    {
//        //        tabelData.Add(werknemer);
//        //    }
//        //    foreach (Afspraak afspraak in afspraken)
//        //    {
//        //        tabelData.Add(afspraak);
//        //    }
//        //    foreach (Bedrijf bedrijf in bedrijven)
//        //    {
//        //        tabelData.Add(bedrijf);
//        //    }
//        //    return tabelData;
//        //}

//        public void UpdateAfspraak(int bezoekerId)
//        {
            
//        }

//        public Persoon GeefPersoonOpEmail(string email)
//        {
//            foreach (Bezoeker bezoeker in bezoekers)
//            {
//                if (bezoeker.Email == email)
//                {
//                    return bezoeker;
//                }
//            }
//            foreach (Werknemer werknemer in werknemers)
//            {
//                if (werknemer.Email == email)
//                {
//                    return werknemer;
//                }
//            }
//            return null;
//        }

//        public List<Afspraak> ZoekAfspraakOp(string zoekText)
//        {
//            throw new NotImplementedException();
//        }

//        public List<Werknemer> ZoekOpWerknemers(string zoekText)
//        {
//            throw new NotImplementedException();
//        }

//        public List<Bezoeker> ZoekBezoekersOp(string zoekText)
//        {
//            throw new NotImplementedException();
//        }

//        public List<Bedrijf> ZoekBedrijfOp(string zoekText)
//        {
//            throw new NotImplementedException();
//        }

//        public void UpdateAfspraak(Afspraak afspraak)
//        {
//            throw new NotImplementedException();
//        }

//        public Bezoeker GeefAfspraakOp(string email)
//        {
//            throw new NotImplementedException();
//        }

//        public Afspraak GeefAfspraakOpEmail(string email)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
