using Controller.Exceptions;
using Controller.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerUT
{
    public class PersoonUT
    {
        [Fact]
        public void Persoon_Valid()
        {
            new Persoon("Tuur", "VanH", "T@gmail.com");
        }

        [Theory]
        [InlineData(null, null)]
        [InlineData(null, "abc")]
        [InlineData("abc", null)]
        [InlineData("", "abc")]
        [InlineData("abc", "")]
        [InlineData("", "")]
        public void Persoon_Invalid(string voornaam, string achternaam)
        {
            Assert.Throws<ControleerException>(() => new Persoon(voornaam, achternaam, "d@hotmail.com"));
        }

        [Fact]
        public void GeefVolledigeNaam()
        {
            Persoon p = new Persoon("Tuur", "VanH", "T@gmail.com");
            string s = p.GeefVolledigeNaam();
            Assert.Equal("Tuur VanH", s);
        }
    }
}
