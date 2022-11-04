using Controller.Models;
using System.Runtime.CompilerServices;
using Controller.Exceptions;

namespace ControllerUT
{
    public class BedrijfUT
    {
        private Bedrijf b;

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void BedrijfNaam_Invalid(string p)
        {
            Assert.Throws<BedrijfException>(() => b.Naam = p);
        }

        [Fact]
        public void BedrijfNaam_Valid()
        {
            b.Naam = "De Nul";
            Assert.Equal("De Nul", b.Naam);
        }
    }
}