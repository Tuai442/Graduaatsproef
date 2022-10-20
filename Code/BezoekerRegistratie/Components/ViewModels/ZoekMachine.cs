using Controller.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Components.Models
{
    public class ZoekMachine
    {
        private List<object> _dataRaw;
        // Dynamic wilt zeggen dat we verschillende soorten objecten kunnen opslaasn.
        // Zoals: int, string, float
        private Dictionary<string, string> _dataDict;
        public ZoekMachine()
        {
            _dataRaw = new List<object>();
            _dataDict = new Dictionary<string, string>();
        }


        public void LaadNieuweData(List<object> data)
        {
            _dataRaw = data;
            
        }

        public List<object> ZoekWoordInAlleAttributen(string zoekWoord)
        {
            // TODO: totaal niet effecient juist maar voor de demo gebruiken.
            List<object> result = new List<object>();
            foreach(string key in _dataDict.Keys)
            {
                var json = JsonConvert.SerializeObject(result);
                var dictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);

            }

            return result;
        }
            
    }


}


    //List<object> result = new List<object>();
    //        foreach (string woord in _dataRaw)
    //        {
    //            int matchedKarakters = 0;
    //            for (int i = 0; i < zoekWoord.Length; i++)
    //            {
    //                if (i < woord.Length)
    //                {
    //                    if (Char.ToLower(zoekWoord[i]) == Char.ToLower(woord[i]))
    //                    {
    //                        matchedKarakters++;
    //                    }
    //                    else
    //                    {
    //                        matchedKarakters = 0;
    //                    }
    //                }
    //                else
    //                {
    //                    matchedKarakters = 0;
    //                }
    //            }
    //            if (matchedKarakters > 0)
    //            {
    //                result.Add(woord);
    //            }

    //        }
    //        return result;
    //    }