﻿using Controller.Interfaces;
using Controller.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class BezoekerMapper : Mapper, IBezoekerRepository
    {
        public List<Bezoeker> GeefAlleBezoekers()
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

        public Persoon GeefPersoonOpVolledigeNaam(string naam, string achternaam)
        {
            throw new NotImplementedException();
        }
    }
}
