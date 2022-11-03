using System;

namespace Components.Models
{
    public class HoofdingAttribute : Attribute
    {
        public string Hoofding { get; set; }

        public HoofdingAttribute(string hoofding)
        {
            Hoofding = hoofding;
        }
    }
}