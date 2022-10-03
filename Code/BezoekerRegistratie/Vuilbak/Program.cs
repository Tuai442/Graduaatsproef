


List<string> namen = new List<string>
{
    "jan",
    "rob",
    "jaap",
    "peter"
};

bool isAanHetZoeken = true;
string totaleWoord = "";
int lineIndex = 0;
while (isAanHetZoeken)
{
    if (Console.KeyAvailable)
    {
        Console.Clear();
        var key = Console.ReadKey(intercept: true).Key;

        switch (key)
        {
            case ConsoleKey.Backspace:
                totaleWoord = totaleWoord.Remove(totaleWoord.Length - 1);
                break;
            case ConsoleKey.Enter:
                break;
            case ConsoleKey.UpArrow:
                if(lineIndex >= 0)
                {
                    lineIndex--;
                }
                break;
            case ConsoleKey.DownArrow:
                if (lineIndex < totaleWoord.Length)
                {
                    lineIndex++;
                }
                break;
            default:
                totaleWoord += key.ToString();
                break;
        }

      
    
        Console.Write(totaleWoord);
        Console.WriteLine();


        // ----------------------------------------
        Dictionary<string, int> naamList = new Dictionary<string, int>();
        foreach (string naam in namen)
        {
            int matchedKarakters = 0;
            for (int i = 0; i < totaleWoord.Length; i++)
            {
                if(i < naam.Length)
                {
                    if (Char.ToLower(totaleWoord[i]) == Char.ToLower(naam[i]))
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
                naamList.Add(naam, matchedKarakters);
            }
        }

        int indexCounter = 0;
        foreach (var naam in naamList.Keys)
        {
            if (lineIndex == indexCounter)
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine($"- {naam}");
                Console.ResetColor();

            }


            else
            {
                int matchedKarakters = naamList[naam];
                Console.Write($"- ");
                for (int i = 0; i < matchedKarakters; i++)
                {
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write($"{naam[i]}");
                }
                Console.ResetColor();
                Console.WriteLine($"{naam.Substring(matchedKarakters, (naam.Length - matchedKarakters))}");

            }
            indexCounter += 1;


        }
    }

    // await Task.Delay(10);// beter met een delay

}