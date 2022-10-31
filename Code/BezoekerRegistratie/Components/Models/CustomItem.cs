using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Components.Models
{
    public class CustomItem
    {
        public string Text { get; set; }
        public string Waarde { get; set; }
        

        public CustomItem(string text, string waarde)
        {
            Text = text;
            Waarde = waarde;
        }

        public override string ToString()
        {
            return Text;
        }
    }
}
