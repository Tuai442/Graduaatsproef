using Controller.Models;
using System.Runtime.CompilerServices;
using Controller.Exceptions;

namespace ControllerUT
{
    public class BedrijfUT
    {
        private Bedrijf b = new Bedrijf("naam", "BE 0123.321.123", "adres", "0487878787", "school@hotmail.com");

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