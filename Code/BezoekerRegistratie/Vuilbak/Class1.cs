using Controller.Models;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuilbak
{
    public class Program
    {
        static void Main(string[] args)
        {
            string connectionString = $"Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\Users\\soren\\Documents\\Academiejaar 2022-2023\\projectwerk\\6deVersie\\Code\\BezoekerRegistratie\\Persistence\\Databank\\Database1.mdf; Integrated Security = True";
            Bezoeker bezoeker = new Bezoeker("Bart", "Porrez", "Bart.Porrez@Gmail.com",1,"1-ABC-123",false);
            //(voornaam,achternaam,email,bedrijfId,nummerplaat,aanwezig)
            BezoekerRepository bezoekerRepository = new BezoekerRepository(connectionString);
            bezoekerRepository.VoegBezoekerToe(bezoeker);
        }
    }
}
