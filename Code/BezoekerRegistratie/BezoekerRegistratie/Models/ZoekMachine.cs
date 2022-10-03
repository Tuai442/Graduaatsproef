using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BezoekerRegistratie.Models
{
    public static class ZoekMachine
    {
        public static List<string> ZoekWoordInLijst(string zoekWoord, List<string> alleItems)
        {
            List<string> result = new List<string>();
            foreach (string woord in alleItems)
            {
                int matchedKarakters = 0;
                for (int i = 0; i < zoekWoord.Length; i++)
                {
                    if (i < woord.Length)
                    {
                        if (Char.ToLower(zoekWoord[i]) == Char.ToLower(woord[i]))
                        {
                            matchedKarakters++;
                        }
                        else
                        {
                            matchedKarakters = 0;
                        }
                    }
                    else
                    {
                        matchedKarakters = 0;
                    }
                }
                if (matchedKarakters > 0)
                {
                    result.Add(woord);
                }

            }
            return result;
        }
    }
}
