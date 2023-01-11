using Controller.Exceptions;
using Controller.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerUT.Models
{
    public class BezoekerUT
    {
        [Theory]
        [InlineData(null, null)]
        [InlineData(null, "abc")]
        [InlineData("ABC-123", null)]
        [InlineData("ABC-123", "")]
        [InlineData("", "abc")]
        public void Bezoeker_Invalid(string nummerplaat, string bedrijf)
        {
            Assert.Throws<ControleerException>(() => new Bezoeker("vnaam", "anaam", "d@test.com", bedrijf, true, nummerplaat));
        }

        [Fact]
        public void Bezoeker_Valid()
        {
            Bezoeker bez = new Bezoeker("Vnaam", "anaam", "d@test.com", "abc", true, "ABC-123");
        }

        [Fact]
        public void MeldAan()
        {
            Bezoeker bez = new Bezoeker("Vnaam", "anaam", "d@test.com", "abc", false, "ABC-123");
            bez.MeldAan();
            Assert.True(bez.Aanwezig);
        }

        [Fact]
        public void MeldAf()
        {
            Bezoeker bez = new Bezoeker("Vnaam", "anaam", "d@test.com", "abc", true, "ABC-123");
            bez.MeldAf();
            Assert.False(bez.Aanwezig);
        }
    }
}
