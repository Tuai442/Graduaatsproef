using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Components.Models
{
    public class ThemaController
    {
        public Dictionary<string, string> LichtThema { get; set; }
        public Dictionary<string, string> DonkerThema { get; set; }

        private string _themaPath = @"";
        public ThemaController()
        {
            LaadThemas(_themaPath);
        }

        private void LaadThemas(string themaPath)
        {
            throw new NotImplementedException();
        }
    }
}
