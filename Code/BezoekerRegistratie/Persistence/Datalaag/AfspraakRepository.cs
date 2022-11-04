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
    public class AfspraakRepository : IAfspraakRepository
    {

        private string connectionString;

        public AfspraakRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }
        private SqlConnection GetConnection()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }

        public void VoegAfspraakToe(Afspraak afspraak)
        {

            string query = "INSERT INTO dbo.Afspraak (voornaamBezoeker,achternaamBezoeker,bezoekersBedrijfNaam,email,startTijd,eindTijd,werknemerId) VALUES(@voornaamBezoeker,@achternaamBezoeker,@bezoekersBedrijfNaam,@email,@startTijd,@eindTijd,@werknemerId)";
            SqlConnection conn = GetConnection();
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                try
                {
                    conn.Open();
                    command.Parameters.Add(new SqlParameter("@voornaamBezoeker", SqlDbType.NVarChar));
                    command.Parameters.Add(new SqlParameter("@chternaamBezoeker", SqlDbType.NVarChar));
                    command.Parameters.Add(new SqlParameter("@bezoekersBedrijfNaam", SqlDbType.NVarChar));
                    command.Parameters.Add(new SqlParameter("@email", SqlDbType.NVarChar));
                    command.Parameters.Add(new SqlParameter("@startTijd", SqlDbType.DateTime));
                    command.Parameters.Add(new SqlParameter("@eindTijd", SqlDbType.DateTime));
                    command.Parameters.Add(new SqlParameter("@werknemerId", SqlDbType.DateTime));
                    command.Parameters["@voornaamBezoeker"].Value = afspraak.Bezoeker.Voornaam;
                    command.Parameters["@achternaamBezoeker"].Value = afspraak.Bezoeker.Achternaam;
                    command.Parameters["@bezoekersBedrijfNaam"].Value = afspraak.Bezoeker.Bedrijf;
                    command.Parameters["@email"].Value = afspraak.Bezoeker.Email;
                    command.Parameters["@startTijd"].Value = afspraak.StartTijd;
                    command.Parameters["@eindTijd"].Value = afspraak.EindTijd;
                    command.Parameters["@werknemerId"].Value = afspraak.Werknemer.Id;
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    AfspraakException ae = new AfspraakException("Afspraak toevoegen is niet gelukt", e);
                    ae.Data.Add("Afspraak:", afspraak);
                    throw ae;
                }
                finally
                {
                    conn.Close();
                }
            }

        }
        public void VerwijderBezoeker(Bezoeker bezoeker)
        {
            string query = "DELETE FROM dbo.Bezoeker WHERE id=@id";
            SqlConnection conn = GetConnection();
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                try
                {
                    conn.Open();
                    command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                    command.Parameters["@id"].Value = bezoeker.Id;
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    BezoekerException be = new BezoekerException("Bezoeker verwijderen is niet gelukt", e);
                    be.Data.Add("Bezoeker:", bezoeker);
                    throw be;
                }
                finally
                {
                    conn.Close();
                }
            }
        }


        public Afspraak GeefAfspraakOpDatum(DateTime datum)
        {
            string query = "SELECT * from dbo.Afspraak where datum=@datum";
            SqlConnection conn = GetConnection();
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                try
                {
                    conn.Open();
                    command.Parameters.AddWithValue("@datum", datum);
                    IDataReader dataReader = command.ExecuteReader();
                    dataReader.Read();
                    Afspraak afspraak = new Afspraak((string)dataReader["voornaamBezoeker"], (string)dataReader["achternaamBezoeker"], (string)dataReader["bezoekerBedrijfsnaam"], (string)dataReader["email"], (DateTime)dataReader["startTijd"], (DateTime)dataReader["eindTijd"], (int)dataReader["werknemerId"]);
                    dataReader.Close();
                    Console.WriteLine(afspraak);
                    return afspraak;
                }
                catch (Exception e)
                {
                    throw new BedrijfException("Geef afspraak is niet gelukt", e);
                }
                finally
                {
                    conn.Close();
                }
            }
        }


        public List<Afspraak> GeefAlleAfspraken()
        {
            string query = "SELECT * from dbo.Afspraak";
            SqlConnection conn = GetConnection();
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                try
                {
                    List<Afspraak> afspraken = new List<Afspraak>();
                    conn.Open();
                    IDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Afspraak afspraak = new Afspraak((string)dataReader["voornaamBezoeker"], (string)dataReader["achternaamBezoeker"], (string)dataReader["bezoekerBedrijfsnaam"], (string)dataReader["email"], (DateTime)dataReader["startTijd"], (DateTime)dataReader["eindTijd"], (int)dataReader["werknemerId"]);
                        afspraken.Add(afspraak);
                    }
                    dataReader.Close();
                    foreach (Afspraak afspraak in afspraken)
                    {
                        Console.WriteLine(afspraak);
                    }
                    return afspraken;
                }
                catch (Exception ex)
                {
                    throw new AfspraakException("Geef afspraken is niet gelukt.", ex);
                }
                finally
                {
                    conn.Close();
                }
            }
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

