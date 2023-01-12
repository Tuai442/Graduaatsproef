using Controller;
using Controller.Exceptions.Manager;
using Controller.Interfaces;
using Controller.Managers;
using Controller.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerUT.Managers
{
    public class BezoekerManagerUT
    {
        private BezoekerManager manager;
        private Mock<IBezoekerRepository> bezoekerMock;
        private Mock<IAfspraakRepository> afspraakMock;
        private Mock<IWerknemerRepository> werknemerMock;
        private Mock<IBedrijfRepository> bedrijfMock;

        private Bezoeker _bezoeker;
        private Werknemer _werknemer;
        private Bedrijf _bedrijf;

        public BezoekerManagerUT()
        {
            bezoekerMock = new Mock<IBezoekerRepository>();
            afspraakMock = new Mock<IAfspraakRepository>();
            werknemerMock = new Mock<IWerknemerRepository>();
            bedrijfMock = new Mock<IBedrijfRepository>();

            _bezoeker = new Bezoeker("voornaam", "achternaam", "test@t.com", "Bedrijf", true);
            _bedrijf = new Bedrijf("BedrijfNaam", "BE 0202.239.951", "BedrijfAdres", "+32487877852", "bedrijf@email.com");
            _werknemer = new Werknemer("WVN", "WAN", "wn@wnr.com", "Functie", _bedrijf);

            manager = new BezoekerManager(bezoekerMock.Object, afspraakMock.Object, werknemerMock.Object, bedrijfMock.Object);
        }

        [Fact]
        public void GeefAlleAanwezigeBezoekers()
        {
            List<Bezoeker> bezoekers = new List<Bezoeker>();
            bezoekers.Add(_bezoeker);

            bezoekerMock.Setup(repo => repo.GeefAlleAanwezigeBezoekers()).Returns(bezoekers);

            IReadOnlyList<Bezoeker> bezoeker = manager.GeefAlleAanwezigeBezoekers();
            Assert.True(bezoeker.Any());
        }

        [Fact]
        public void GeefAlleAanwezigeBezoekers_Exception()
        {
            List<Bezoeker> bezoekers = null;
            Assert.Throws<BezoekerManagerException>(() => manager.GeefAlleAanwezigeBezoekers());
        }

        [Fact]
        public void ZoekOp()
        {
            List<Bezoeker> bezoekers = new List<Bezoeker>();
            bezoekers.Add(_bezoeker);

            bezoekerMock.Setup(repo => repo.ZoekBezoekersOp("zoektekst")).Returns(bezoekers);

            IReadOnlyList<Bezoeker> bezoeker = manager.ZoekOp("zoektekst");

            Assert.True(bezoeker.Any());
        }

        [Fact]
        public void ZoekBezoekerOpEmail()
        {
            bezoekerMock.Setup(repo => repo.GeefBezoekerOpEmail("test@t.com")).Returns(_bezoeker);

            Bezoeker bezoeker = manager.ZoekBezoekerOpEmail("test@t.com");

            Assert.Equal(bezoeker, _bezoeker);
        }

        [Fact]
        public void UpdateBezoeker()
        {
            manager.UpdateBezoeker(_bezoeker);
            bezoekerMock.Verify(repo => repo.ZetBezoekerNonActief(_bezoeker));
        }
    }
}
