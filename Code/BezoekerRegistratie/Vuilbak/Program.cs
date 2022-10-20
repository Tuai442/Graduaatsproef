using Controller.Models;
using System;
using System.IO;


using (StreamReader sr = new StreamReader("bezoekers.csv"))
{
    string line;
    bool skipHeader = true;
    while ((line = sr.ReadLine()) != null)
    {
        if (!skipHeader)
        {
            var split = line.Split(",");
            int id = int.Parse(split[0]);
            string voornaam = split[1];
            string achternaam = split[2];
            string email = split[3];
            string bedrijf = split[4];
            Bezoeker bezoeker = new Bezoeker(voornaam, achternaam, $"{voornaam}.{achternaam}@email.com", bedrijf);
        }
        skipHeader = false;
        

    }
}