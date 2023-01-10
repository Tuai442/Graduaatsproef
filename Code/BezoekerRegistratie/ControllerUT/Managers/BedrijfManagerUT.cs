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
    public class BedrijfManagerUT
    {
        private IBedrijfRepository _repo = new BedrijfRepository();
        private BedrijfManager manager;

        public BedrijfManagerUT()
        {
            manager = new BedrijfManager(_repo);
        }

        //TODO: exception door btw controle
        [Fact]
        public void ControleVoegNieuwBedrijfToe_Valid()
        {
            manager.VoegNieuwBedrijfToe("naam", "BE 0123.321.123", "adres", "0487878787", "school@hotmail.com");
        }

        [Theory]
        [InlineData("BE 0123.321123", "0487878787", "school@hotmail.com")]
        [InlineData("BE 0123.321.123", "04878787878787", "school@hotmail.com")]
        [InlineData("BE 0123.321.123", "0487878787", "@hotmail.com")]
        public void ControleVoegNieuwBedrijfToe_Invalid(string btw, string telefoon, string email)
        {
            Assert.Throws<ControleerException>(() => manager.VoegNieuwBedrijfToe("naam", btw, "adres", telefoon, email));
        }

        [Fact]
        public void GeefAlleBedrijven()
        {
            IReadOnlyList<Bedrijf> lijst = manager.GeefAlleBedrijven();
        }

        [Fact]
        public void ZoekOp_Valid()
        {
            IReadOnlyList<Bedrijf> lijst = manager.ZoekOp("k");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void ZoekOp_Invalid(string s)
        {
            Assert.Throws<BedrijfException>(() => manager.ZoekOp(s));
        }

        [Fact]
        public void GeefBedrijvenOpEmailWerknemer_Valid()
        {
            IReadOnlyList<Bedrijf> lijst = manager.GeefBedrijvenOpEmailWerknemer("k@gmail.com");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void GeefBedrijvenOpEmailWerknemer_Invalid(string s)
        {
            Assert.Throws<ControleerException>(() => manager.GeefBedrijvenOpEmailWerknemer(s));
        }

        [Fact]
        public void UpdateBedrijf_Valid()
        {
            Bedrijf b = new Bedrijf("naam", "BE 0123.321.123", "adres", "0487878787", "school@hotmail.com");
            manager.UpdateBedrijf(b);
        }

        [Fact]
        public void UpdateBedrijf_Invalid()
        {
            Assert.Throws<BedrijfException>(() => manager.UpdateBedrijf(null));
        }
    }
}
