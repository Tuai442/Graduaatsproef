using Controller.Interfaces;
using Controller.Managers;
using Controller.Models;
using ControllerUT.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerUT.Managers
{
    public class WerknemerMannagerUT
    {
        private WerknemerManager manager;
        private Mock<IWerknemerRepository> werknemerMock;

        private Werknemer _werknemer;
        private Werknemer _werknemer2;
        private Bedrijf _bedrijf;

        public WerknemerMannagerUT()
        {
            werknemerMock = new Mock<IWerknemerRepository>();
            manager = new WerknemerManager(werknemerMock.Object);

            _bedrijf = new Bedrijf("BedrijfNaam", "BE 0202.239.951", "BedrijfAdres", "+32487877852", "bedrijf@email.com");
            _werknemer = new Werknemer("Voornaam", "Achternaam", "test@t.com", "Functie", _bedrijf);
            _werknemer2 = new Werknemer("VN", "AN", "voorbeeld@t.com", "Functie", _bedrijf);
            _werknemer2.Id = 2;
        }

        [Fact]
        public void GeefAlleWerknemers()
        {
            List<Werknemer> werknemers = new List<Werknemer>();
            werknemers.Add(_werknemer);

            werknemerMock.Setup(repo => repo.GeefAlleWerknemers()).Returns(werknemers);

            IReadOnlyList<Werknemer> w = manager.GeefAlleWerknemers();
            Assert.True(w.Any());
        }


        [Fact]
        public void GeefWerknemersOpEmailBedrijf()
        {
            List<Werknemer> werknemers = new List<Werknemer>();
            werknemers.Add(_werknemer);

            werknemerMock.Setup(repo => repo.GeefWerknemersOpEmailBedrijf("test@t.com")).Returns(werknemers);

            IReadOnlyList<Werknemer> w = manager.GeefWerknemersOpEmailBedrijf("test@t.com");
            Assert.True(w.Any());
        }

        [Fact]
        public void UpdateWerknemer()
        {
            _werknemer.Id = 1;
            werknemerMock.Setup(repo => repo.HeeftWerknemer(_werknemer.Id)).Returns(true);
            werknemerMock.Setup(repo => repo.GeefWerknemerOpId(_werknemer2.Id)).Returns(_werknemer2);

            manager.UpdateWerknemer(_werknemer);
            werknemerMock.Verify(repo => repo.UpdateWerknemer(_werknemer));
        }

        [Fact]
        public void VerwijderWerknemer()
        {
            _werknemer.Id = 1;
            werknemerMock.Setup(repo => repo.HeeftWerknemer(_werknemer.Id)).Returns(true);

            manager.VerwijderWerknemer(1);
            werknemerMock.Verify(repo => repo.ZetNonActiefWerknemer(_werknemer.Id));
        }

        [Fact]
        public void ZoekOp()
        {
            List<Werknemer> werknemers = new List<Werknemer>();
            werknemers.Add(_werknemer);

            werknemerMock.Setup(repo => repo.ZoekOpWerknemers("zoektekst")).Returns(werknemers);

            IReadOnlyList<Werknemer> w = manager.ZoekOp("zoektekst");

            Assert.True(w.Any());
        }
    }
}
