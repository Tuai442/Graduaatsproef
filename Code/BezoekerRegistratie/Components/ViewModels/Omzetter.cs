using Controller.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Components.ViewModels
{
    public class Omzetter
    {
        public static List<object> ZetInterfacesOmInItemSources(List<IItemSource> interfaces)
        {
            return interfaces.Select(x => x.GeefItemSource()).ToList();
        }
    }
}
