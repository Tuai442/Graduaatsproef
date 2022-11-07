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

            string query = "INSERT INTO dbo.Afspraak (startTijd,eindTijd,werknemerId,bezoekerId) VALUES(@startTijd,@eindTijd,@werknemerId,@bezoekerId)";
            SqlConnection conn = GetConnection();
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                try
                {
                    conn.Open();
                    command.Parameters.Add(new SqlParameter("@startTijd", SqlDbType.DateTime));
                    command.Parameters.Add(new SqlParameter("@eindTijd", SqlDbType.DateTime));
                    command.Parameters.Add(new SqlParameter("@werknemerId", SqlDbType.Int));
                    command.Parameters.Add(new SqlParameter("@bezoekerId", SqlDbType.Int));
                    command.Parameters["@startTijd"].Value = afspraak.StartTijd;
                    command.Parameters["@eindTijd"].Value = afspraak.EindTijd;
                    command.Parameters["@werknemerId"].Value = afspraak.Werknemer.Id;
                    command.Parameters["@bezoekerId"].Value = afspraak.Bezoeker.Id;
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
                    Afspraak afspraak = new Afspraak((int)dataReader["afspraakId"], (Bezoeker)dataReader["bezoekerId"], (Werknemer)dataReader["werknemerId"], (DateTime)dataReader["startTijd"], (DateTime)dataReader["eindTijd"]); 
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
                        Afspraak afspraak = new Afspraak((int)dataReader["afspraakId"], (Bezoeker)dataReader["bezoekerId"],(Werknemer)dataReader["werknemerId"],(DateTime)dataReader["startTijd"], (DateTime)dataReader["eindTijd"]);

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

        public List<Afspraak> GeefAlleAanwezigeBezoekers()
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
            string query = "SELECT * from dbo.Afspraak where email=@email";
            SqlConnection conn = GetConnection();
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                try
                {
                    conn.Open();
                    command.Parameters.AddWithValue("@email", emailGezocht);
                    IDataReader dataReader = command.ExecuteReader();
                    dataReader.Read();
                    Afspraak afspraak= new Afspraak((int)dataReader["afspraakId"],(Bezoeker)dataReader["bezoekerId"], (Werknemer)dataReader["werknemerId"], (DateTime)dataReader["startTijd"], (DateTime)dataReader["eindTijd"]);
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
    }
}