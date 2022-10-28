using Controller.Interfaces;
using Controller.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controller;
using Controller.Interfaces.Models;
using Persistence.Exceptions;
using System.Globalization;
using System.Data.SqlTypes;

namespace Persistence.Datalaag
{
    public class AfspraakRepository: BaseRepository, IAfspraakRepository
    {
      
        private string _tableName = "Afspraken";
        public AfspraakRepository()
        {
            //SlaDummyDataOp();
        }
        
        public void VoegAfspraakToe(Afspraak afspraak)
        {
            
            string query = $"INSERT INTO {_tableName} (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, " +
                $"StartTijd, EindTijd, WerknemerId) " +
                $"VALUES(@VoornaamBezoeker, @AchternaamBezoeker, @BezoekersBedrijfNaam, @Email, @Aanwezig, " +
                $"@StartTijd, @EindTijd, @WerknemerId)";
            SqlConnection conn = GetConnection();
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                try//{"The parameterized query '(@VoornaamBezoeker varchar(1),@AchternaamBezoeker varchar(1)
                   //,@Be' expects the parameter '@EindTijd', which was not supplied."}
                {
                    conn.Open();

                    command.Parameters.Add(new SqlParameter("@VoornaamBezoeker", SqlDbType.VarChar));
                    command.Parameters["@VoornaamBezoeker"].Value = afspraak.Bezoeker.Voornaam;

                    command.Parameters.Add(new SqlParameter("@AchternaamBezoeker", SqlDbType.VarChar));
                    command.Parameters["@AchternaamBezoeker"].Value = afspraak.Bezoeker.Achternaam;

                    command.Parameters.Add(new SqlParameter("@BezoekersBedrijfNaam", SqlDbType.VarChar));
                    command.Parameters["@BezoekersBedrijfNaam"].Value = afspraak.Bezoeker.Bedrijf;

                    command.Parameters.Add(new SqlParameter("@Email", SqlDbType.VarChar));
                    command.Parameters["@Email"].Value = afspraak.Bezoeker.Email;

                    command.Parameters.Add(new SqlParameter("@Aanwezig", SqlDbType.Bit));
                    command.Parameters["@Aanwezig"].Value = Convert.ToByte(afspraak.IsAanwezig);

                    command.Parameters.Add(new SqlParameter("@StartTijd", SqlDbType.DateTime));
                    command.Parameters["@StartTijd"].Value = afspraak.StartTijd;


                    // Eindtijd kan null zijn daarom zo afhandelen.
                    DateTime? eindTijd = afspraak.EindTijd;
                    command.Parameters.Add(new SqlParameter("@EindTijd", SqlDbType.DateTime));
                    if (eindTijd != null)
                    {
                        command.Parameters["@EindTijd"].Value = eindTijd;
                    }
                    else
                    {
                        command.Parameters["@EindTijd"].Value = new SqlDateTime();
                    }

                    
                    command.Parameters.Add(new SqlParameter("@WerknemerId", SqlDbType.Int));
                    command.Parameters["@WerknemerId"].Value = afspraak.Werknemer.Id;


                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    
                    throw new AfspraakException("Kan afspraak niet toevoegen.");
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        public void VerwijderBezoeker(Bezoeker bezoeker)
        {
            
        }

        public int GeefAfspraakOpDatum(DateTime datum)
        {
            throw new NotImplementedException();
        }

        public List<Afspraak> GeefAlleAfspraken()
        {
            // Geeft een lijst terug die gejoind wordt met werknemrs en bedrijven.
            SqlConnection conn = GetConnection();
            List<Afspraak> afspraken = new List<Afspraak>();
            try
            {
                conn.Open();
                string query = $"select AfspraakId, " +
                    $"a.Email as a_email, VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam," +
                    $"Voornaam, Achternaam, w.Email as w_email, Functie, w.WerknemerId, " +
                    $"Naam, BTW, b.Email as b_email, Adres, telefoon," +
                    $"StartTijd, EindTijd, Aanwezig FROM {_tableName} a " +

                    $"join Werknemers w on w.WerknemerId = a.WerknemerId " +
                    $"join Bedrijven b on w.BedrijfId = b.BedrijfId;";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader dataReader = cmd.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        // Bezoeker
                        int afspraakId = (int)dataReader["AfspraakId"];
                        string email = (string)dataReader["a_email"];
                        string voornaamB = (string)dataReader["VoornaamBezoeker"];
                        string achternaamB = (string)dataReader["AchternaamBezoeker"];
                        string bedrijfBezoeker = (string)dataReader["BezoekersBedrijfNaam"];

                        // Werknemer
                        int werknemerId = (int)dataReader["WerknemerId"];
                        string voornaamWerknemer = (string)dataReader["Voornaam"];
                        string achternaamWerknemer = (string)dataReader["Achternaam"];
                        string emailWerknemer = (string)dataReader["w_email"];
                        string functie = (string)dataReader["Functie"];
                        string bedrijfWerknemer = (string)dataReader["Naam"];

                        // Bedrijf
                        string btw = (string)dataReader["BTW"];
                        string bedrijfEmail = (string)dataReader["b_email"];
                        string adress = (string)dataReader["Adres"];
                        string telefoon = (string)dataReader["telefoon"];

                        // Datum
                        DateTime startTijd = (DateTime)dataReader["StartTijd"];
                        bool aanwezig = (bool)dataReader["Aanwezig"];
                        DateTime? EindTijd = null;
                        if (!aanwezig)
                        {
                            EindTijd = (DateTime)dataReader["EindTijd"];
                        }

                        Bezoeker bezoeker = new Bezoeker(email, voornaamB, achternaamB, bedrijfBezoeker);
                        Bedrijf bedrijf = new Bedrijf(bedrijfWerknemer, btw, adress, telefoon, email);
                        Werknemer werknemer = new Werknemer(werknemerId, voornaamWerknemer, achternaamWerknemer, email, functie, bedrijf);

                        Afspraak afspraak = new Afspraak(afspraakId, bezoeker, werknemer, startTijd, EindTijd);
                        
                        afspraken.Add(afspraak);
                    }


                }
            }
            catch (Exception e)
            {
                throw new AfspraakException(e.Message);
            }
            finally
            {
                conn.Close();
            }
            return afspraken;

        }


        public List<Afspraak> GeefAlleAanwezigeAfspraken()
        {
            // Geeft een lijst terug die gejoind wordt met werknemrs en bedrijven.
            SqlConnection conn = GetConnection();
            List<Afspraak> afspraken = new List<Afspraak>();
            try
            {
                conn.Open();
                string query = $"select AfspraakId, " +
                    $"a.Email as a_email, VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam," +
                    $"Voornaam, Achternaam, w.Email as w_email, Functie, w.WerknemerId, " +
                    $"Naam, BTW, b.Email as b_email, Adres, telefoon," +
                    $"StartTijd, EindTijd, Aanwezig FROM {_tableName} a " +

                    $"join Werknemers w on w.WerknemerId = a.WerknemerId " +
                    $"join Bedrijven b on w.BedrijfId = b.BedrijfId " +
                    $"WHERE a.Aanwezig = 1";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader dataReader = cmd.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        // Bezoeker
                        int afspraakId = (int)dataReader["AfspraakId"];
                        string email = (string)dataReader["a_email"];
                        string voornaamB = (string)dataReader["VoornaamBezoeker"];
                        string achternaamB = (string)dataReader["AchternaamBezoeker"];
                        string bedrijfBezoeker = (string)dataReader["BezoekersBedrijfNaam"];

                        // Werknemer
                        int werknemerId = (int)dataReader["WerknemerId"];
                        string voornaamWerknemer = (string)dataReader["Voornaam"];
                        string achternaamWerknemer = (string)dataReader["Achternaam"];
                        string emailWerknemer = (string)dataReader["w_email"];
                        string functie = (string)dataReader["Functie"];
                        string bedrijfWerknemer = (string)dataReader["Naam"];

                        // Bedrijf
                        string btw = (string)dataReader["BTW"];
                        string bedrijfEmail = (string)dataReader["b_email"];
                        string adress = (string)dataReader["Adres"];
                        string telefoon = (string)dataReader["telefoon"];

                        // Datum
                        DateTime startTijd = (DateTime)dataReader["StartTijd"];
                        bool aanwezig = (bool)dataReader["Aanwezig"];
                        DateTime? EindTijd = null;
                        

                        Bezoeker bezoeker = new Bezoeker(email, voornaamB, achternaamB, bedrijfBezoeker);
                        Bedrijf bedrijf = new Bedrijf(bedrijfWerknemer, btw, adress, telefoon, email);
                        Werknemer werknemer = new Werknemer(werknemerId ,voornaamWerknemer, achternaamWerknemer, email, functie, bedrijf);

                        Afspraak afspraak = new Afspraak(afspraakId, bezoeker, werknemer, startTijd, EindTijd);

                        afspraken.Add(afspraak);
                    }


                }
            }
            catch (Exception e)
            {
                throw new AfspraakException(e.Message);
            }
            finally
            {
                conn.Close();
            }
            return afspraken;

        }
        public void UpdateAfspraak(Afspraak afspraak)
        {
            SqlConnection conn = GetConnection();
            try
            {
                conn.Open();
                string query = $"UPDATE Afspraken SET VoornaamBezoeker= @VoornaamBezoeker, AchternaamBezoeker= @AchternaamBezoeker," +
                    $"BezoekersBedrijfNaam= @BezoekersBedrijfNaam, Email= @Email, Aanwezig= @Aanwezig, " +
                    $"StartTijd= @StartTijd, EindTijd= @EindTijd, WerknemerId= @WerknemerId " +
                    $"WHERE AfspraakId = {afspraak.Id}";

                SqlCommand cmd = new SqlCommand(query, conn);

                
                cmd.Parameters.Add("VoornaamBezoeker", SqlDbType.VarChar).Value = afspraak.Bezoeker.Voornaam;
                cmd.Parameters.Add("AchternaamBezoeker", SqlDbType.VarChar).Value = afspraak.Bezoeker.Achternaam;
                cmd.Parameters.Add("BezoekersBedrijfNaam", SqlDbType.VarChar).Value = afspraak.Bezoeker.Bedrijf;
                cmd.Parameters.Add("Email", SqlDbType.VarChar).Value = afspraak.Bezoeker.Email;
                cmd.Parameters.Add("Aanwezig", SqlDbType.Bit).Value = Convert.ToByte(afspraak.IsAanwezig);
                cmd.Parameters.Add("StartTijd", SqlDbType.DateTime).Value = afspraak.StartTijd;
                cmd.Parameters.Add("EindTijd", SqlDbType.DateTime).Value = afspraak.EindTijd;
                cmd.Parameters.Add("WerknemerId", SqlDbType.Int).Value = afspraak.Werknemer.Id;

                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new AfspraakException(e.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public List<Afspraak> ZoekAfspraakOp(string zoekText)
        {
            SqlConnection conn = GetConnection();
            List<Afspraak> afspraken = new List<Afspraak>();
            try
            {
                conn.Open();
                
                string query = $"SELECT * FROM {_tableName} WHERE column LIKE '{zoekText}%';";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader dataReader = cmd.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        int id = (int)dataReader["AfspraakId"];
                        string email = (string)dataReader["Email"];
                        string voornaamB = (string)dataReader["VoornaamBezoeker"];
                        string achternaamB = (string)dataReader["AchternaamBezoeker"];
                        string bedrijf = (string)dataReader["Bedrijf"];
                        string voornaamCp = (string)dataReader["VoornaamContactPersoon"];
                        string achternaamCp = (string)dataReader["AchternaamContactPersoon"];
                        DateTime startTijd = (DateTime)dataReader["StartTijd"];
                        DateTime eindTijd = (DateTime)dataReader["EindTijd"];
                        int werknemerId = (int)dataReader["WerknemerId"];

                        Werknemer werknemer = GeefWerknemerOpId(werknemerId);
                        //Afspraak afspraak = new Afspraak(email, voornaamB, achternaamB, bedrijf,
                        //    voornaamCp, achternaamCp, "", startTijd, eindTijd);
                        //afspraken.Add(afspraak);
                    }


                }
            }
            catch (Exception e)
            {
                throw new AfspraakException("Kan afspraak niet toevoegen.");
            }
            finally
            {
                conn.Close();
            }
            return afspraken;
        }

        public Afspraak GeefAfspraakOpEmail(string emailGezocht)
        {
            // Er gaat altijd van één afspraak de EindTijd null zijn van een bezoeker omdat we zo weten dat die nog aanwezig is.
            // We moeten er voor zorgen dat het NIET MOGELIJK is dat een bezoeker 2 afspraken met een EindTijd null kan hebben.
            SqlConnection conn = GetConnection();
            Afspraak afspraak = null;
            try
            {
                conn.Open();

                string query = $"SELECT AfspraakId, " +
                    $"a.Email as a_email, VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, " +
                    $"Voornaam, Achternaam, w.Email as w_email, Functie, w.WerknemerId," +
                    $"Naam, BTW, b.Email as b_email, Adres, telefoon, b.BedrijfId, " +
                    $"StartTijd, EindTijd, Aanwezig  FROM {_tableName} a " +
                    $"join Werknemers w on a.WerknemerId = w.WerknemerId " +
                    $"join Bedrijven b on w.BedrijfId = b.BedrijfId " +
                    $"WHERE a.EindTijd is null and a.Email = '{emailGezocht}';";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader dataReader = cmd.ExecuteReader();
                if (dataReader.HasRows)
                { 
                    
                    while (dataReader.Read())
                    {
                        // Bezoeker
                        int afspraakId = (int)dataReader["AfspraakId"];
                        string email = (string)dataReader["a_email"];
                        string voornaamB = (string)dataReader["VoornaamBezoeker"];
                        string achternaamB = (string)dataReader["AchternaamBezoeker"];
                        string bedrijfBezoeker = (string)dataReader["BezoekersBedrijfNaam"];

                        // Werknemer
                        int werknemerId = (int)dataReader["WerknemerId"];
                        string voornaamWerknemer = (string)dataReader["Voornaam"];
                        string achternaamWerknemer = (string)dataReader["Achternaam"];
                        string emailWerknemer = (string)dataReader["w_email"];
                        string functie = (string)dataReader["Functie"];
                        string bedrijfWerknemer = (string)dataReader["Naam"];

                        // Bedrijf
                        int bedrijfId = (int)dataReader["BedrijfId"];
                        string btw = (string)dataReader["BTW"];
                        string bedrijfEmail = (string)dataReader["b_email"];
                        string adress = (string)dataReader["Adres"];
                        string telefoon = (string)dataReader["telefoon"];

                        // Datum
                        DateTime startTijd = (DateTime)dataReader["StartTijd"];
                        bool aanwezig = (bool)dataReader["Aanwezig"];
                        DateTime? EindTijd = null;
                        if (!aanwezig)
                        {
                            EindTijd = (DateTime)dataReader["EindTijd"];
                        }

                        Bezoeker bezoeker = new Bezoeker(voornaamB, achternaamB, email, bedrijfBezoeker);
                        Bedrijf bedrijf = new Bedrijf(bedrijfId, bedrijfWerknemer, btw, adress, telefoon, email);
                        Werknemer werknemer = new Werknemer(werknemerId, voornaamWerknemer, achternaamWerknemer, email, functie, bedrijf);
                        afspraak = new Afspraak(afspraakId, bezoeker, werknemer, startTijd, EindTijd);

                    }
                }
            }
            catch (Exception e)
            {
                throw new AfspraakException(e.Message);
            }
            finally
            {
                conn.Close();
            }

            return afspraak;
        }

       
    }
}
