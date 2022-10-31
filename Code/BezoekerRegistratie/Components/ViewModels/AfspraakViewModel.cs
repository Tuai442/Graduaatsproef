using Controller;
using Controller.Interfaces;
using Controller.Interfaces.Models;
using Controller.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Components.ViewModels
{
    public class  AfspraakViewModel : IAfspraak
    {
        public string BezoekerNaam { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string WerknemerNaam { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime StartTijd { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime? EindTijd { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
       

        public List<Rij> GeefDict()
        {
            throw new NotImplementedException();
        }

        public object GeefItemSource()
        {
            throw new NotImplementedException();
        }
    }
}
