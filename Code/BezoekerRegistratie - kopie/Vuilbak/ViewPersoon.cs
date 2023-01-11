using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuilbak
{
    public class ViewPersoon : IPersoon
    {
        [ColumnNaam("Testnaam")]
        public string Naam { get; set; }
    }

    internal class ColumnNaamAttribute : Attribute
    {
        public string ColumnNaam { get; set; }
        public ColumnNaamAttribute(string columnNaam)
        {
            ColumnNaam = columnNaam;
        }
    }
}
