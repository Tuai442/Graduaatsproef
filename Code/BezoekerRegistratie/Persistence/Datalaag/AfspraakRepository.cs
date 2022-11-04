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
                    Afspraak afspraak = new Afspraak((string)dataReader["voornaamBezoeker"], (string)dataReader["achternaamBezoeker"], (string)dataReader["bezoekerBedrijfsnaam"], (string)dataReader["email"], (DateTime)dataReader["startTijd"], (DateTime)dataReader["eindTijd"], (int)["werknemerId"]);
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

        }
        public void UpdateAfspraak(Afspraak afspraak)
        {
        }

        public List<Afspraak> ZoekAfspraakOp(string zoekText)
        {
        }

        public void UpdateAfspraak(Afspraak afspraak)
        {

        }

        public List<Afspraak> ZoekAfspraakOp(string zoekText)
        {

        }

        public Afspraak GeefAfspraakOpEmail(string emailGezocht)
        {

        }
    }
}