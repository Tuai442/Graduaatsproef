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
