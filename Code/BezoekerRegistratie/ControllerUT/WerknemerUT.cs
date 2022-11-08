using Controller.Exceptions;
using Controller.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerUT
{
    public class WerknemerUT
    {
        private Bedrijf b = new Bedrijf("naam", "BE 0123.321.123", "adres", "0487878787", "school@hotmail.com");

        [Fact]
        public void Werknemer_Valid()
        {
            new Werknemer(1, "Tuur", "VanH", "T@gmail.com", "administratie", b);
        }


        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Werknemer_Invalid(string functie)
        {
            Assert.Throws<ControleerException>(() => new Werknemer(1, "Tuur", "VanH", "T@gmail.com", functie, b));
        }
    }
}
