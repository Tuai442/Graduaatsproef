using Controller;
using Controller.Exceptions;
using Controller.Interfaces;
using Controller.Managers;
using Controller.Models;
using Persistence.Datalaag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerUT.Managers
{
    public class AfspraakManagerUT
    {
        private IAfspraakRepository _repo = new AfspraakRepository();
        private AfspraakManager manager;

        public AfspraakManagerUT()
        {
            manager = new AfspraakManager(_repo);
        }

        [Fact]
        public void GeefAlleAfspraken()
        {
            IReadOnlyList<Afspraak> afspraak = manager.GeefAlleAfspraken();
        }

        //TODO: zoekop is nog niet uitgewerkt
        [Fact]
        public void ZoekOp_Valid()
        {
            IReadOnlyList<Afspraak> lijst = manager.ZoekOp("k");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void ZoekOp_Invalid(string s)
        {
            Assert.Throws<AfspraakException>(() => manager.ZoekOp(s));
        }

        [Fact]
        public void UpdateAfspraak_Valid()
        {

            //Bedrijf bedrijf = new Bedrijf("naam", "BE 0123.321.123", "adres", "0487878787", "school@hotmail.com");
            //Bezoeker b = new Bezoeker(100, "naam","achter","d@v.com","kitkat",true);
            //Werknemer w = new Werknemer(1,"naam","achter","e@mail.com","ceo", bedrijf);
            //Afspraak a = new Afspraak(b, w, new DateTime(2015, 06, 19, 5, 30, 0), new DateTime(2015, 06, 19, 8, 30, 0));

            //_repo.VoegAfspraakToe(a);
            //manager.UpdateAfspraak(a);
        }

        [Fact]
        public void UpdateAfspraak_Invalid()
        {
            Assert.Throws<AfspraakException>(() => manager.UpdateAfspraak(null));
        }
    }
}
