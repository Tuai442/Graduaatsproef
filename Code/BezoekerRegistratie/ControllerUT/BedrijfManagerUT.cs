using Controller.Exceptions;
using Controller.Interfaces;
using Controller.Managers;
using Controller.Models;
using Persistence.Datalaag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerUT
{
    public class BedrijfManagerUT
    {
        private IBedrijfRepository _repo = new BedrijfRepository();
        private BedrijfManager manager;

        public BedrijfManagerUT()
        {
            manager = new BedrijfManager(_repo);
        }

        //TODO: exception door btw controle
        [Fact]
        public void ControleVoegNieuwBedrijfToe_Valid()
        {
            manager.VoegNieuwBedrijfToe("naam", "BE 0123.321.123", "adres", "0487878787", "school@hotmail.com");
        }
        
        [Theory]
        [InlineData("BE 0123.321123", "0487878787", "school@hotmail.com")]
        [InlineData("BE 0123.321.123", "04878787878787", "school@hotmail.com")]
        [InlineData("BE 0123.321.123", "0487878787", "@hotmail.com")]
        public void ControleVoegNieuwBedrijfToe_Invalid(string btw, string telefoon, string email)
        {
            Assert.Throws<BedrijfException>(() => manager.VoegNieuwBedrijfToe("naam", btw, "adres", telefoon, email));
        }

    }
}
