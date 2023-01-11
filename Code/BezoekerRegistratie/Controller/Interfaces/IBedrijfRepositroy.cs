using Controller.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Interfaces
{
    public interface IBedrijfRepository
    {
        public List<Bedrijf> GeefAlleBedrijven();
        public void VoegNieuwBedrijfToe(Bedrijf bedrijf);
        public List<Bedrijf> ZoekBedrijfOp(string zoekText);
        List<Bedrijf> GeefBedrijvenOpWerknemerEmail(string email);
        void UpdateBedrijf(Bedrijf bedrijf);
        Bedrijf GeefBedrijfOpEmail(string email);
        Bedrijf GeefBedrijfViaNaam(string value);
        void ZetBedrijfNonActief(int id);
        public bool HeeftBedrijf(int bedrijfId);

    }
}
