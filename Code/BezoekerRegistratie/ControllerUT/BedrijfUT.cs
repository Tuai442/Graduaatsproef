using Controller.Models;
using System.Runtime.CompilerServices;
using Controller.Exceptions;

namespace ControllerUT
{
    public class BedrijfUT
    {
        [Fact]
        public void ControleBedrijf_Valid()
        {
            Bedrijf b = new Bedrijf("naam", "BE 0123.321.123", "adres", "0487878787", "school@hotmail.com");
        }
        private Bedrijf bedrijf = new Bedrijf("naam", "BE 0123.321.123", "adres", "0487878787", "school@hotmail.com");

        //[Theory]
        //[InlineData("+32487878787")]
        //[InlineData("0032487878787")]
        //[InlineData("0487878787")]
        //[InlineData("0487228787")]
        //[InlineData("04 8722 87 87")]
        //public void ControleTelefoon_Valid(string telefoon)
        //{
        //    Assert.True(bedrijf.ControleTelefoon(telefoon));
        //}

        //[Theory]
        //[InlineData(null)]
        //[InlineData("")]
        //[InlineData("abcd")]
        //[InlineData("048722888558558787")]
        //public void ControleTelefoon_Invalid(string telefoon)
        //{
        //    Assert.False(bedrijf.ControleTelefoon(telefoon));
        //}

        //[Theory]
        //[InlineData("BE 0123.321.123")]
        //[InlineData("BE0123.321.123")]
        //[InlineData("be 0123.321.123")]
        //public void ControleBTW_Valid(string btw)
        //{
        //    Assert.True(bedrijf.ControleBTW(btw));
        //}

        //[Theory]
        //[InlineData(null)]
        //[InlineData("")]
        //[InlineData("abcd")]
        //[InlineData("0487228")]
        //[InlineData("BE")]
        //[InlineData("BE 2222")]
        //[InlineData("BE 1212 121 122")]
        //[InlineData("BE 1212121122")]
        //public void ControleBTW_Invalid(string btw)
        //{
        //    Assert.False(bedrijf.ControleBTW(btw));
        //}

        //[Theory]
        //[InlineData("gapoto8713@abudat.com")]
        //[InlineData("gapoto8713@hotmail.com")]
        //[InlineData("zhfj@zefji.sjf.be")]
        //public void ControleEmail_Valid(string email)
        //{
        //    Assert.True(bedrijf.ControleEmail(email));
        //}

        //[Theory]
        //[InlineData(null)]
        //[InlineData("")]
        //[InlineData("@")]
        //[InlineData("@hotmail.com")]
        //[InlineData("abcd")]
        //[InlineData("0487228")]
        //[InlineData("015@")]
        //[InlineData("015@ergeg")]
        //public void ControleEmail_Invalid(string email)
        //{
        //    Assert.False(bedrijf.ControleEmail(email));
        //}

        [Theory]
        [InlineData("BE 0123.321123", "0487878787", "school@hotmail.com")]
        [InlineData("BE 0123.321.123", "04878787878787", "school@hotmail.com")]
        [InlineData("BE 0123.321.123", "0487878787", "@hotmail.com")]
        public void ControleBedrijf_Invalid(string btw, string telefoon, string email)
        {
            Assert.Throws<BedrijfException>(()=> new Bedrijf("naam", btw, "adres", telefoon, email));
        }
    }
}