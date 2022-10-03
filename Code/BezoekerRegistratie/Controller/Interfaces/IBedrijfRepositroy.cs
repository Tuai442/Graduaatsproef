using Controller.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Interfaces
{
    public interface IBedrijfRepository
    {
        Bedrijf GeefBedrijfOpNaam(string bedrijf);
        List<Bedrijf> GeefAlleBedrijven();
        void VoegNieuwBedrijfToe(Bedrijf bedrijf);
        Bedrijf GeefBedrijfOpId(int bedrijfNaam);
    }
}
