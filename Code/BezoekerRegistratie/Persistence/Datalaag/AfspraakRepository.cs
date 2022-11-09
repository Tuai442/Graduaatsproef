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
using System.Reflection.PortableExecutable;

namespace Persistence.Datalaag
{
    public class AfspraakRepository : BaseRepository,  IAfspraakRepository
    {


        public AfspraakRepository()
        {
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
                    if(afspraak.EindTijd == null)
                    {
                        command.Parameters["@eindTijd"].Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters["@eindTijd"].Value = afspraak.EindTijd; // TODO: moet mogelijk zijn om null in te steken

                    }
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
            string query = "SELECT startTijd, eindTijd, bezoekerId, werknemerId from dbo.Afspraak;";
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
                        int bezoekerId = (int)dataReader["bezoekerId"];
                        Bezoeker bezoeker = GeefBezoekerOpId(bezoekerId);
                        int werknemerId = (int)dataReader["werknemerId"];
                        Werknemer werknemer = GeefWerknemerOpId(werknemerId);
                        DateTime startTijd = (DateTime)dataReader["startTijd"];
                        DateTime? eindTijd = GeefDateTime(dataReader["eindTijd"]);
                        Afspraak afspraak = new Afspraak(bezoeker, werknemer, startTijd, eindTijd);

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
        public void UpdateAfspraak(Afspraak afspraak)
        {
            string query = "update dbo.Afspraak set eindtijd=@eindtijd where afspraakId=@afspraakId";
            SqlConnection conn = GetConnection();
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                try
                {
                    conn.Open();
                    command.Parameters.Add(new SqlParameter("@afspraakId", SqlDbType.Int));
                    command.Parameters.Add(new SqlParameter("@eindtijd", SqlDbType.DateTime));
                    command.Parameters["@afspraakId"].Value = afspraak.Id;
                    command.Parameters["@eindtijd"].Value = afspraak.EindTijd;
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    AfspraakException ae = new AfspraakException("Update is niet gelukt", e);
                    ae.Data.Add("Afspraak", afspraak);
                    throw ae;
                }
                finally
                {
                    conn.Close();
                }

            }
        }

        //TODO: methode uitwerken
        public List<Afspraak> ZoekAfspraakOp(string zoekText)
        {
            return null;
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

        int IAfspraakRepository.GeefAfspraakOpDatum(DateTime datum)
        {
            throw new NotImplementedException();
        }

        public List<Afspraak> GeefAlleAanwezigeAfspraken()
        {
            throw new NotImplementedException();
        }

        public Afspraak GeefAfspraakOpBezoekerId(int id)
        {
            string query = "SELECT * from dbo.Afspraak where bezoekerId=@id";
            SqlConnection conn = GetConnection();
            Afspraak afspraak = null;

            using (SqlCommand command = new SqlCommand(query, conn))
            {
                try
                {
                    conn.Open();
                    command.Parameters.AddWithValue("@id", id);
                    IDataReader dataReader = command.ExecuteReader();
                    dataReader.Read();

                    if (dataReader.Read())
                    {
                        int bezoekerId = (int)dataReader["bezoekerId"];
                        Bezoeker bezoeker = GeefBezoekerOpId(bezoekerId);
                        int werknemerId = (int)dataReader["werknemerId"];
                        Werknemer werknemer = GeefWerknemerOpId(werknemerId);
                        DateTime startTijd = (DateTime)dataReader["startTijd"];
                        DateTime? eindTijd = (DateTime)dataReader["eindTijd"]; ;
                        afspraak = new Afspraak(bezoeker, werknemer, startTijd, eindTijd);
                    }

                     
                    dataReader.Close();
                    return afspraak;
                }
                catch (Exception e)
                {
                    throw new AfspraakException("Geef afspraak is niet gelukt", e);
                }
                finally
                {
                    conn.Close();
                }
                return null;
            }
        }

        public static DateTime? GeefDateTime(object obj)
        {
            if (obj == null || obj == DBNull.Value)
            {
                return null; 
            }
            else
            {
                return (DateTime)obj;
            }
        }
    }
}