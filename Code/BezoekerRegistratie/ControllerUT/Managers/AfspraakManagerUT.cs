using Controller;
using Controller.Exceptions;
using Controller.Exceptions.Manager;
using Controller.Interfaces;
using Controller.Managers;
using Controller.Models;
using ControllerUT.Models;
using MimeKit.Cryptography;
using Moq;
using Org.BouncyCastle.Asn1;
using Persistence.Datalaag;
using Persistence.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerUT.Managers
{
    public class AfspraakManagerUT
    {
        private AfspraakManager manager;
        private Mock<IAfspraakRepository> afspraakMock;

        private Bezoeker _bezoeker;
        private Afspraak _afspraak;
        private Werknemer _werknemer;
        private Bedrijf _bedrijf;

        public AfspraakManagerUT()
        {
            afspraakMock = new Mock<IAfspraakRepository>();

            _bezoeker = new Bezoeker("BezVN", "BezAN", "bezoeker@mail.com", "bedrijf", true);
            _bedrijf = new Bedrijf("BedrijfNaam", "BE 0202.239.951", "BedrijfAdres", "+32487877852", "bedrijf@email.com");
            _werknemer = new Werknemer("WerkVN", "WerkVN", "werknemer@email.com", "Functie", _bedrijf);
            _afspraak = new Afspraak(_bezoeker, _werknemer, DateTime.Now);
        }

        [Fact]
        public void GeefAlleAfspraken()
        {
            List<Afspraak> afspraaks = new List<Afspraak>();
            afspraaks.Add(_afspraak);

            manager = new AfspraakManager(afspraakMock.Object);
            afspraakMock.Setup(repo => repo.GeefAlleAfspraken()).Returns(afspraaks);

            IReadOnlyList<Afspraak> afspraak = manager.GeefAlleAfspraken();

            Assert.True(afspraak.Any());
        }

        [Fact]
        public void GeefAlleAfspraken_Exception()
        {
            List<Afspraak> afspraaks = null;

            manager = new AfspraakManager(afspraakMock.Object);

            Assert.Throws<AfspraakManagerException>(() => manager.GeefAlleAfspraken());
        }

        [Fact]
        public void ZoekOp()
        {
            List<Afspraak> afspraaks = new List<Afspraak>();
            afspraaks.Add(_afspraak);

            manager = new AfspraakManager(afspraakMock.Object);
            afspraakMock.Setup(repo => repo.ZoekAfspraakOp("zoektekst")).Returns(afspraaks);

            IReadOnlyList<Afspraak> afspraak = manager.ZoekOp("zoektekst");

            Assert.True(afspraak.Any());
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void ZoekOp_Exception(string s)
        {
            manager = new AfspraakManager(afspraakMock.Object);

            Assert.Throws<AfspraakManagerException>(() => manager.ZoekOp(s));
        }

        [Fact]
        public void UpdateAfspraak()
        {
            manager = new AfspraakManager(afspraakMock.Object);
            manager.UpdateAfspraak(_afspraak);
            afspraakMock.Verify(repo => repo.UpdateAfspraak(_afspraak));
        }

        [Fact]
        public void UpdateAfspraak_Exception()
        {
            manager = new AfspraakManager(afspraakMock.Object);
            Assert.Throws<AfspraakManagerException>(() => manager.UpdateAfspraak(null));
        }

        [Fact]
        public void GeefaAlleopenstaandeAfsprakenVoorSendEmail()
        {
            List<Afspraak> afspraaks = new List<Afspraak>();
            afspraaks.Add(_afspraak);

            manager = new AfspraakManager(afspraakMock.Object);
            afspraakMock.Setup(repo => repo.GeefOpenstaandeAfspraak()).Returns(afspraaks);

            IReadOnlyList<Afspraak> afspraak = manager.GeefaAlleopenstaandeAfsprakenVoorSendEmail();

            Assert.True(afspraak.Any());
        }

        [Fact]
        public void GeefaAlleopenstaandeAfsprakenVoorSendEmail_Exception()
        {
            List<Afspraak> afspraaks = null;

            manager = new AfspraakManager(afspraakMock.Object);

            Assert.Throws<AfspraakManagerException>(() => manager.GeefAlleAfspraken());
        }

        [Fact]
        public void VerwijderAfspraak()
        {
            manager = new AfspraakManager(afspraakMock.Object);
            manager.VerwijderAfspraak(1);
            afspraakMock.Verify(repo => repo.ZetOpNonActief(1));
        }

    }
}
