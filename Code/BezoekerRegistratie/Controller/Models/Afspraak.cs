using Controller.Interfaces;
using Controller.Interfaces.Models;
using Controller.Models;
using System.Security.Cryptography;

namespace Controller
{
    public class Afspraak: IAfspraak
    {
        public int Id { get; set; }
        public string Email { get; set; }

        // TODO: misschien we gelaten en met foreign key werken in tabel
        public string VoornaamBezoeker { get; set; }
        public string AchternaamBezoeker { get; set; }
        public string VoornaamContactPersoon { get; set; }
        public string AchternaamContactPersoon { get; set; }
        // -----
        public string Bedrijf { get; set; }
        public DateTime StartTijd { get; set; }
        public DateTime EindTijd { get; set; }

        public Afspraak(string email, string vnBezoeker, string anBezoeker,
            string vnContactpersoon, string anContactPersoon, string bedrijf)
        {
            Email = email;
            VoornaamBezoeker = vnBezoeker;
            AchternaamBezoeker = anBezoeker;
            VoornaamContactPersoon = vnContactpersoon;
            AchternaamContactPersoon = anContactPersoon;
            Bedrijf = bedrijf;
            StartTijd = DateTime.Now;
        }


        public Afspraak(int id, string email, string vnBezoeker, string anBezoeker,
            string vnContactpersoon, string anContactPersoon, string bedrijf, 
            DateTime startTijd, DateTime eindTijd)
        {
            Id = id;
            Email = email;
            VoornaamBezoeker = vnBezoeker;
            AchternaamBezoeker = anBezoeker;
            VoornaamContactPersoon = vnContactpersoon;
            AchternaamContactPersoon = anContactPersoon;
            Bedrijf = bedrijf;
            StartTijd = startTijd;
            EindTijd = eindTijd;
        }

        //public Afspraak(int id, string email, string vnBezoeker, string anBezoeker,
        //  string vnContactpersoon, string anContactPersoon, string bedrijf,
        //  DateTime startTijd, DateTime eindTijd)
        //{
        //    Id = id;
        //    Email = email;
        //    VoornaamBezoeker = vnBezoeker;
        //    AchternaamBezoeker = anBezoeker;
        //    VoornaamContactPersoon = vnContactpersoon;
        //    AchternaamContactPersoon = anContactPersoon;
        //    Bedrijf = bedrijf;
        //    StartTijd = startTijd;
        //    EindTijd = eindTijd;
        //}



        public void EindeAfspraak()
        {
            EindTijd = DateTime.Now;
        }
        //public override string? ToString()
        //{
        //    return $"Naam: {VoornaamBezoeker}\n" +
        //            $"Contact persoon: {ContactPersoon}\n" +
        //            $"Datum: {StartTijd.ToString()}\n" +
        //            $"Bedrijf: {Bedrijf}";
        //}

        public object GeefItemSource()
        {
            object result = new
            {
                Voornaam = VoornaamBezoeker,
                Achternaam = AchternaamBezoeker,
                Email = Email,
                VoornaamContactPersoon = VoornaamContactPersoon,
                AchternaamContactPersoon = AchternaamContactPersoon,
                Bedrijf = Bedrijf,
                StartTijd = StartTijd,
                EindTijd = EindTijd
            };
            return result;
        }
    }
}