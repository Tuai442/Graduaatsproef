using Controller;
using Controller.Exceptions;
using Controller.Models;
//using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerUT
{
    public class ControleerUT
    {
        [Theory]
        [InlineData("+32487878787")]
        [InlineData("0032487878787")]
        [InlineData("0487878787")]
        [InlineData("0487228787")]
        [InlineData("04 8722 87 87")]
        public void ControleTelefoon_Valid(string telefoon)
        {
            Controleer.ControleTelefoon(telefoon);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("abcd")]
        [InlineData("048722888558558787")]
        public void ControleTelefoon_Invalid(string telefoon)
        {
            Assert.Throws<BedrijfException>(() => Controleer.ControleTelefoon(telefoon));
        }

        [Theory]
        [InlineData("BE 0123.321.123")]
        [InlineData("BE0123.321.123")]
        [InlineData("be 0123.321.123")]
        public void ControleBTW_Valid(string btw)
        {
            Controleer.BtwNummerControle(btw);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("abcd")]
        [InlineData("0487228")]
        [InlineData("BE")]
        [InlineData("BE 2222")]
        [InlineData("BE 1212 121 122")]
        [InlineData("BE 1212121122")]
        public void ControleBTW_Invalid(string btw)
        {
            Assert.Throws<BedrijfException>(() => Controleer.BtwNummerControle(btw));
        }

        [Theory]
        [InlineData("gapoto8713@abudat.com")]
        [InlineData("gapoto8713@hotmail.com")]
        [InlineData("zhfj@zefji.sjf.be")]
        public void ControleEmail_Valid(string email)
        {
            Controleer.ControleEmail(email);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("@")]
        [InlineData("@hotmail.com")]
        [InlineData("abcd")]
        [InlineData("0487228")]
        [InlineData("015@")]
        [InlineData("015@ergeg")]
        public void ControleEmail_Invalid(string email)
        {
            Assert.Throws<BedrijfException>(() => Controleer.ControleEmail(email));
        }

        [Fact]
        public void ControleIsAfspraakAlAfgesloten_Valid()
        {
            Bezoeker bezoeker = null;
            Werknemer werknemer = null;
            Afspraak f = new Afspraak(0, bezoeker, werknemer, DateTime.Now, null);
            Controleer.ControleIsAfspraakAlAfgesloten(f);
        }

        [Fact]
        public void ControleIsAfspraakAlAfgesloten_Null_Invalid()
        {
            Afspraak f = null;
            Assert.Throws<UitLogException>(() => Controleer.ControleIsAfspraakAlAfgesloten(f));
        }

        [Fact]
        public void ControleIsAfspraakAlAfgesloten_NietIngelogd_Invalid()
        {
            Bezoeker bezoeker = null;
            Werknemer werknemer = null;
            Afspraak f = new Afspraak(0, bezoeker, werknemer, DateTime.Now, DateTime.Now);
            Assert.Throws<UitLogException>(() => Controleer.ControleIsAfspraakAlAfgesloten(f));
        }

        [Theory]
        [InlineData("1-ABC-123")]
        [InlineData("2-ABC-123")]
        [InlineData("ABC-123")]
        public void ControleNummerplaat_Valid(string nummerplaat)
        {
            Controleer.ControleNummerplaat(nummerplaat);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("1ABC-123")]
        [InlineData("1-ABC123")]
        [InlineData("1-AC-123")]
        [InlineData("1-ABC-23")]
        [InlineData("3-ABC-123")]
        [InlineData("2ABC123")]
        public void ControleNummerplaat_Invalid(string nummerplaat)
        {
            Assert.Throws<BezoekerException>(() => Controleer.ControleNummerplaat(nummerplaat));
        }

        [Fact]
        public void SetStringParameters_Valid()
        {
            string s = Controleer.SetStringParameters("Neal");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void SetStringParameters_Invalid(string s)
        {
            Assert.Throws<Exception>(() => Controleer.SetStringParameters(s));
        }

    }
}
