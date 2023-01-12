using Controller;
using Controller.Exceptions;
using Controller.Exceptions.Manager;
using Controller.Interfaces;
using Controller.Managers;
using Controller.Models;
using Moq;
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
        private BedrijfManager manager;
        private Mock<IBedrijfRepository> bedrijfMock;

        private Bedrijf _bedrijf;

        public BedrijfManagerUT()
        {
            bedrijfMock = new Mock<IBedrijfRepository>();

            _bedrijf = new Bedrijf("BedrijfNaam", "BE 0202.239.951", "BedrijfAdres", "+32487877852", "bedrijf@email.com");
        }

        [Fact]
        public void VoegNieuwBedrijfToe()
        {
            manager = new BedrijfManager(bedrijfMock.Object);
            
            manager.VoegNieuwBedrijfToe("naam", "BE 0202.239.951", "adres", "0487878787", "school@hotmail.com");
        }

        [Fact]
        public void GeefAlleBedrijven()
        {
            List<Bedrijf> bedrijfs = new List<Bedrijf>();
            bedrijfs.Add(_bedrijf);

            manager = new BedrijfManager(bedrijfMock.Object);
            bedrijfMock.Setup(repo => repo.GeefAlleBedrijven()).Returns(bedrijfs);

            IReadOnlyList<Bedrijf> bedrijf = manager.GeefAlleBedrijven();
            Assert.True(bedrijf.Any());
        }

        [Fact]
        public void GeefAlleBedrijven_Exception()
        {
            List<Bedrijf> bedrijfs = null;

            manager = new BedrijfManager(bedrijfMock.Object);

            Assert.Throws<BedrijfManagerException>(() => manager.GeefAlleBedrijven());
        }

        [Fact]
        public void ZoekOp()
        {
            List<Bedrijf> bedrijfs = new List<Bedrijf>();
            bedrijfs.Add(_bedrijf);

            manager = new BedrijfManager(bedrijfMock.Object);
            bedrijfMock.Setup(repo => repo.ZoekBedrijfOp("zoektekst")).Returns(bedrijfs);

            IReadOnlyList<Bedrijf> bedrijf = manager.ZoekOp("zoektekst");

            Assert.True(bedrijf.Any());
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void ZoekOp_Exception(string s)
        {
            manager = new BedrijfManager(bedrijfMock.Object);

            Assert.Throws<BedrijfManagerException>(() => manager.ZoekOp(s));
        }

        [Fact]
        public void GeefBedrijvenOpEmailWerknemer()
        {
            List<Bedrijf> bedrijfs = new List<Bedrijf>();
            bedrijfs.Add(_bedrijf);

            manager = new BedrijfManager(bedrijfMock.Object);
            bedrijfMock.Setup(repo => repo.GeefBedrijvenOpWerknemerEmail("t@t.com")).Returns(bedrijfs);

            IReadOnlyList<Bedrijf> bedrijf = manager.GeefBedrijvenOpEmailWerknemer("t@t.com");

            Assert.True(bedrijf.Any());
        }

        [Fact]
        public void UpdateBedrijf()
        {
            manager = new BedrijfManager(bedrijfMock.Object);

            _bedrijf.Id = 1;
            bedrijfMock.Setup(repo => repo.HeeftBedrijf(1)).Returns(true);

            manager.UpdateBedrijf(_bedrijf);
            bedrijfMock.Verify(repo => repo.UpdateBedrijf(_bedrijf));
        }

        [Fact]
        public void GeefBedrijfOpEmail()
        {
            manager = new BedrijfManager(bedrijfMock.Object);
            bedrijfMock.Setup(repo => repo.GeefBedrijfOpEmail("t@t.com")).Returns(_bedrijf);

            Bedrijf bedrijf = manager.GeefBedrijfOpEmail("t@t.com");

            Assert.Equal(bedrijf, _bedrijf);
        }

        [Fact]
        public void GeefBedrijfViaNaam()
        {
            manager = new BedrijfManager(bedrijfMock.Object);
            bedrijfMock.Setup(repo => repo.GeefBedrijfViaNaam("naam")).Returns(_bedrijf);

            Bedrijf bedrijf = manager.GeefBedrijfViaNaam("naam");

            Assert.Equal(bedrijf, _bedrijf);
        }

        [Fact]
        public void VerwijderBedrijf()
        {
            manager = new BedrijfManager(bedrijfMock.Object);

            _bedrijf.Id = 1;
            bedrijfMock.Setup(repo => repo.HeeftBedrijf(1)).Returns(true);

            manager.VerwijderBedrijf(1);
            bedrijfMock.Verify(repo => repo.ZetBedrijfNonActief(1));
        }
    }
}
