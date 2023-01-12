using Controller.Models;
using System.Runtime.CompilerServices;
using Controller.Exceptions;

namespace ControllerUT.Models
{
    public class BedrijfUT
    {
        private Bedrijf b = new Bedrijf("naam", "BE0427250554", "adres", "0487878787", "school@hotmail.com");

        [Fact]
        public void Bedrijf_Valid()
        {
            Bedrijf bedrijf = new Bedrijf("naam", "BE0427250554", "adres", "0487878787", "school@hotmail.com");
        }

        [Theory]
        [InlineData(null, "BE 0123.321.123", "adres", "0487878787", "school@hotmail.com")]
        [InlineData("", "BE 0123.321.123", "adres", "0487878787", "school@hotmail.com")]


        [InlineData("naam", "BE 0123.321.123", null, "0487878787", "school@hotmail.com")]
        [InlineData("naam", "BE 0123.321.123", "", "0487878787", "school@hotmail.com")]

        [InlineData("naam", "BE 0123.321.123", "adres", null, "school@hotmail.com")]
        [InlineData("naam", "BE 0123.321.123", "adres", "", "school@hotmail.com")]

        [InlineData("naam", "BE 0123.321.123", "adres", "0487878787", null)]
        [InlineData("naam", "BE 0123.321.123", "adres", "0487878787", "")]
        [InlineData("naam", "BE 0123.321.123", "adres", "0487878787", "school")]
        public void Bedrijf_Invalid(string naam, string btw, string adres, string telefoon, string email)
        {
            Assert.Throws<ControleerException>(() => new Bedrijf(naam, btw, adres, telefoon, email));
        }

        [Fact]
        public void To_String()
        {
            string s = b.ToString();
            Assert.Equal("naam", s);
        }
    }
}