using Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    public class App
    {
        private BezoekerController _bezoekerController;
        private BeheerController _beheerController;
        private bool running = true;
        private string onderschijdingsLijn = "================================================";

        public App(BezoekerController bezoekerController, BeheerController beheerController)
        {
            this._bezoekerController = bezoekerController;
            this._beheerController = beheerController;
        }

        public void StartUp()
        {
            while (running)
            {
                OpenStartScherm();
            }
            
        }

        private void OpenStartScherm()
        {
            int keuze = SelecteerOptie("kies", new List<string> { "receptionist", "bezoeker" });
            Console.WriteLine(keuze);
            switch (keuze)
            {
                case 0:
                    OpenReceptionistMenu();
                    break;

                case 1:
                    OpenBezoekerMenu();
                    break;
            }
        }

        private int SelecteerOptie(string vraag, List<string> list)
        {
            Console.WriteLine(vraag);
            foreach (string optie in list)
            {
                Console.WriteLine($"- {optie}");
            }

            int lineIndex = 0;
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    Console.Clear();
                    var key = Console.ReadKey(intercept: true).Key;
                    switch (key)
                    {
                        case ConsoleKey.Enter:
                            return lineIndex;
                            break;
                        case ConsoleKey.UpArrow:
                            if (lineIndex >= 0)
                            {
                                lineIndex--;
                            }
                            break;
                        case ConsoleKey.DownArrow:
                            if (lineIndex < list.Count)
                            {
                                lineIndex++;
                            }
                            break;
                        default:
                            break;
                    }
                    int listIndex = 0;
                    Console.WriteLine(vraag);
                    foreach (string optie in list)
                    {
                        if (lineIndex == listIndex)
                        {
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                        Console.WriteLine($"- {optie}");
                        Console.ResetColor();
                        listIndex++;


                    }
                }
            }
            
            return -1;
        }

        private void OpenReceptionistMenu()
        {
            int keuze = SelecteerOptie("Wat wilt u doen?", new List<string> { "Nieuwe bezoeker registreren", "Nieuwe afspraak maken" });
            switch (keuze)
            {
                case 0:
                    OpenRegistreerNieuweBezoeker();
                    break;
                case 1:
                    OpenMaakNieuweAfspraak();
                    break;
            }
        }

        private void OpenMaakNieuweAfspraak()
        {
            Console.Clear();
            Console.WriteLine("Afsrpaak maken");
            Console.WriteLine(onderschijdingsLijn);
            string voornaam = VraagInput("Geef de voornaam van de bezoeker");
            string achternaam = VraagInput("Geef de achternaam van de bezoeker");
            string telofoon = VraagInput("Geef de telofoon van de bezoeker");
            string nummerplaat = VraagInput("Geef de nummerplaat van de bezoeker");
            string datum = VraagInput("Geef de datum van de bezoeker");

            List<string> bedrijven = _beheerController.GeefAlleContactPersonen();
            int keuze = SelecteerOptie("Geef het bedrijf van de bezoeker, wilt u een zoeken uit de databank of een nieuwe maken",
                new List<string> { "Bedrijf zoeken", "Nieuwe maken" });
            string bedrijf = "";
            switch (keuze)
            {
                case 0:
                    List<string> zoekLijst = _beheerController.GeefAlleBedrijfsNamen();
                    Console.WriteLine(zoekLijst);
                    bedrijf = DynamishZoeken("Zoek een bedrijf op", zoekLijst);
                    break;
                case 1:
                    bedrijf = OpenNieuwBedrijfToevoegen();
                    break;
            }
            int bezoekerId = _beheerController.GeefBezoekersId(voornaam, achternaam);
            //_bezoekerController.MaakNieuweAfspraak(bezoekerId, 0, bedrijf, new DateTime());
            Console.WriteLine($"Nieuw afspraak is gemaakt info:\n" +
                $"voornaam: {voornaam}\n" +
                $"achternaam: {achternaam}\n" +
                $"telefoon: {telofoon}\n" +
                $"bedrijf: {bedrijf}");
            Console.WriteLine(onderschijdingsLijn);

        }

        private string OpenNieuwBedrijfToevoegen()
        {
            Console.Clear();
            Console.WriteLine("Nieuw bedrijf toevoegen");
            Console.WriteLine(onderschijdingsLijn);
            string naam = VraagInput("Geef de naam van de bedrijf");
            string btw = VraagInput("Geef de btw nummer van de bedrijf");
            string adress = VraagInput("Geef de adress van de bedrijf");
            string telefoon = VraagInput("Geef de telefoon van de bedrijf");
            string email = VraagInput("Geef de email van de bedrijf");
            _beheerController.VoegNieuwBedrijfToe(naam, btw, adress, telefoon, email);
            Console.WriteLine("Bedrijf toegevoegd!");
            return naam;
        }

        

        private void OpenRegistreerNieuweBezoeker()
        {
            Console.WriteLine("Registreer nieuw bezoeker");
            Console.WriteLine(onderschijdingsLijn);
            string voornaam = VraagInput("Geef de voornaam van de bzoeker");
            string achternaam = VraagInput("Geef de achternaam van de bzoeker");
            string nummerplaat = VraagInput("Geef de nummerplaat van de bzoeker");
            string email = VraagInput("Geef de email van de bzoeker");
            string telefoon = VraagInput("Geef de telefoon van de bzoeker");
        }

        private void OpenBezoekerMenu()
        {

            int keuze = SelecteerOptie("Hoe wil je inschrijven", new List<string> { "Naam", "telfoon", "email" });
            Console.WriteLine(keuze);
            switch (keuze)
            {
                case 0:
                    //List<string> zoekLijst = _beheerController.GeefAlleBezoekersNamen();
                    //string naam = DynamishZoeken("Zoek je naam op.", zoekLijst);
                    //int id = _beheerController.GeefBezoekersId(naam);
                    //ToonInfo(id);
                    //_bezoekerController.GeefBezoekersId(naam: voornaam, achternaam: achternaam);
                    break;

            }
        }

        private void ToonInfo(int id)
        {
            Console.Clear();
            string afspraak = _bezoekerController.GeefAfspraakInfoOpBezoekerId(id);
            Console.WriteLine(onderschijdingsLijn);
            Console.WriteLine(afspraak);
            Console.WriteLine(onderschijdingsLijn);
            Console.WriteLine();
        }

        private string DynamishZoeken(string v, List<string> zoekLijst)
        {
            bool isAanHetZoeken = true;
            string totaleWoord = "";
            string gevondenWoord = "";
            int lineIndex = 0;
            while (isAanHetZoeken)
            {
                if (Console.KeyAvailable)
                {
                    Dictionary<string, int> gelijkbareName = GeefAlleGelijkbareNamen(totaleWoord, zoekLijst);

                    Console.Clear();
                    var key = Console.ReadKey(intercept: true).Key;

                    switch (key)
                    {
                        case ConsoleKey.Backspace:
                            totaleWoord = totaleWoord.Remove(totaleWoord.Length - 1);
                            break;
                        case ConsoleKey.Enter:
                            isAanHetZoeken = false;
                            gevondenWoord = gelijkbareName.Keys.ToList()[lineIndex];
                            break;
                        case ConsoleKey.UpArrow:
                            if (lineIndex >= 0)
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


                   

                    int indexCounter = 0;
                    foreach (var naam in gelijkbareName.Keys)
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
                            int matchedKarakters = gelijkbareName[naam];
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

            }
            Console.Clear();
            return gevondenWoord;
        }


        public Dictionary<string, int> GeefAlleGelijkbareNamen(string totaleWoord, List<string> zoekLijst)
        {

            Dictionary<string, int> naamList = new Dictionary<string, int>();
            foreach (string naam in zoekLijst)
            {
                int matchedKarakters = 0;
                for (int i = 0; i < totaleWoord.Length; i++)
                {
                    if (i < naam.Length)
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
            return naamList;

        }







        private string VraagInput(string v)
        {
            Console.WriteLine(v);
            return Console.ReadLine();
        }

        private int HandelKeuezInput(int maxKeuze)
        {
            
            int input = 0;
            bool gelukt = false;
            do
            {
                string inputString = Console.ReadLine();
                gelukt = int.TryParse(inputString, out input);
                if(input > maxKeuze || !gelukt)
                {
                    Console.WriteLine("Kan keuze niet verweken probeer opnieuw");
                    gelukt = false;
                }
            } while (gelukt == false);
            return input;
           
            
        }
    }
}
