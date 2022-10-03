using Controller.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Interfaces
{
    public interface IPersoonRepository
    {
        Persoon GeefPersoonOpVolledigeNaam(string naam, string achternaam);

    }
}
