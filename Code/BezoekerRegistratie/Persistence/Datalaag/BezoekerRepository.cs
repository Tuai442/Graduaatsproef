using Controller.Interfaces;
using Controller.Models;
using Persistence.Datalaag;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class BezoekerRepository : IBezoekerRepository
    {
        private string connectionString;

        public BezoekerRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }
        public void VoegBezoekerToe(Bezoeker bezoeker)
        {
            string query = "INSERT INTO dbo.Bezoeker (voornaam,achternaam,email,bedrijf,nummerplaat,aanwezig) VALUES(@voornaam,@achternaam,@email,@bedrijf,@nummerplaat,@aanwezig)";
            SqlConnection conn = GetConnection();
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                try
                {
                    conn.Open();
                    command.Parameters.Add(new SqlParameter("@voornaam", SqlDbType.NVarChar));
                    command.Parameters.Add(new SqlParameter("@achternaam", SqlDbType.NVarChar));
                    command.Parameters.Add(new SqlParameter("@email", SqlDbType.NVarChar));
                    command.Parameters.Add(new SqlParameter("@bedrijf", SqlDbType.NVarChar));
                    command.Parameters.Add(new SqlParameter("@nummerplaat", SqlDbType.NVarChar));
                    command.Parameters.Add(new SqlParameter("@aanwezig", SqlDbType.Bit));
                    command.Parameters["@voornaam"].Value = bezoeker.Voornaam;
                    command.Parameters["@achternaam"].Value = bezoeker.Achternaam;
                    command.Parameters["@email"].Value = bezoeker.Email;
                    command.Parameters["@bedrijf"].Value = bezoeker.Bedrijf;
                    command.Parameters["@nummerplaat"].Value = bezoeker.Nummerplaat;
                    command.Parameters["@aanwezig"].Value = bezoeker.Aanwezig;
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    BezoekerException be = new BezoekerException("Bezoeker toevoegen is niet gelukt", e);
                    be.Data.Add("Bezoeker:", bezoeker);
                    throw be;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        public void VerwijderBezoeker(Bezoeker bezoeker)
        {
            string query = "DELETE FROM dbo.Bezoeker WHERE bezoekerId=@bezoekerId";
            SqlConnection conn = GetConnection();
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                try
                {
                    conn.Open();
                    command.Parameters.Add(new SqlParameter("@bezoekerId", SqlDbType.Int));
                    command.Parameters["@bezoekerId"].Value = bezoeker.Id;
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
        public List<Bezoeker> GeefAlleBezoekers()
        {
            string query = "SELECT * from dbo.Bezoeker";
            SqlConnection conn = GetConnection();
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                try
                {
                    List<Bezoeker> bezoekers = new List<Bezoeker>();
                    conn.Open();
                    IDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Bezoeker bezoeker = new Bezoeker((int)dataReader["bezoekerId"], (string)dataReader["voornaam"], (string)dataReader["achternaam"], (string)dataReader["email"], (string)dataReader["bedrijf"], (bool)dataReader["aanwezig"], (string)dataReader["nummerplaat"]);
                        bezoekers.Add(bezoeker);
                    }
                    dataReader.Close();
                    foreach (Bezoeker bezoeker in bezoekers)
                    {
                        Console.WriteLine(bezoeker);
                    }
                    return bezoekers;
                }
                catch (Exception ex)
                {
                    throw new BezoekerException("Geef bezoekers is niet gelukt.", ex);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public Bezoeker GeefBezoekerOpEmail(string email)
        {
            string query = "SELECT * from dbo.Bezoeker where email=@email";
            SqlConnection conn = GetConnection();
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                try
                {
                    conn.Open();
                    command.Parameters.AddWithValue("@email", email);
                    IDataReader dataReader = command.ExecuteReader();
                    dataReader.Read();
                    Bezoeker bezoeker = new Bezoeker((int)dataReader["bezoekerId"], (string)dataReader["voornaam"], (string)dataReader["achternaam"], (string)dataReader["email"], (string)dataReader["bedrijf"], (bool)dataReader["aanwezig"], (string)dataReader["nummerplaat"]);
                    dataReader.Close();
                    Console.WriteLine(bezoeker);
                    return bezoeker;
                }
                catch (Exception e)
                {
                    throw new BedrijfException("Geef bezoeker op email is niet gelukt", e);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        public void UpdateBezoeker(Bezoeker bezoeker)
        {
            throw new NotImplementedException();
        }

        public List<Bezoeker> GeefAlleAanwezigeBezoekers(bool aanwezig)
        {
            string query = "SELECT * from dbo.Bezoeker where @aanwezig='TRUE";
            SqlConnection conn = GetConnection();
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                try
                {
                    List<Bezoeker> bezoekers = new List<Bezoeker>();
                    conn.Open();
                    command.Parameters.AddWithValue("@aanwezig", aanwezig);
                    IDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Bezoeker bezoeker = new Bezoeker((int)dataReader["bezoekerId"], (string)dataReader["voornaam"], (string)dataReader["achternaam"], (string)dataReader["email"], (string)dataReader["bedrijf"], (bool)dataReader["aanwezig"], (string)dataReader["nummerplaat"]);
                        bezoekers.Add(bezoeker);
                    }
                    dataReader.Close();
                    foreach (Bezoeker bezoeker in bezoekers)
                    {
                        Console.WriteLine(bezoeker);
                    }
                    return bezoekers;
                }
                catch (Exception ex)
                {
                    throw new BezoekerException("Geef bezoekers is niet gelukt.", ex);
                }
                finally
                {
                    conn.Close();
                }
            }
        }


        public List<Bezoeker> ZoekBezoekersOp(string zoekText)
        {
            //weet niet welk statement er hier moet
            string query = "SELECT * from dbo.Bezoeker where ";
            SqlConnection conn = GetConnection();
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                try
                {
                    List<Bezoeker> bezoekers = new List<Bezoeker>();
                    conn.Open();
                    command.Parameters.AddWithValue("@zoektext", zoekText);
                    IDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Bezoeker bezoeker = new Bezoeker((int)dataReader["bezoekerId"], (string)dataReader["voornaam"], (string)dataReader["achternaam"], (string)dataReader["email"], (string)dataReader["bedrijf"], (bool)dataReader["aanwezig"], (string)dataReader["nummerplaat"]);
                        bezoekers.Add(bezoeker);
                    }
                    dataReader.Close();
                    foreach (Bezoeker bezoeker in bezoekers)
                    {
                        Console.WriteLine(bezoeker);
                    }
                    return bezoekers;
                }
                catch (Exception ex)
                {
                    throw new BezoekerException("Geef bezoekers is niet gelukt.", ex);
                }
                finally
                {
                    conn.Close();
                }
            }
        }


        public Bezoeker GeefbezoekerOpVolledigeNaam(string voornaam, string achternaam)
        {
            string query = "SELECT * from dbo.Bezoeker where voornaam=@voornaam and achtnaam=@achternaam";
            SqlConnection conn = GetConnection();
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                try
                {
                    conn.Open();
                    command.Parameters.AddWithValue("@voornaam", voornaam);
                    command.Parameters.AddWithValue("@achternaam", achternaam);
                    IDataReader dataReader = command.ExecuteReader();
                    Bezoeker bezoeker = new Bezoeker((int)dataReader["bezoekerId"], (string)dataReader["voornaam"], (string)dataReader["achternaam"], (string)dataReader["email"], (string)dataReader["bedrijf"], (bool)dataReader["aanwezig"], (string)dataReader["nummerplaat"]);                    
                    dataReader.Close();
                    Console.WriteLine(bezoeker);
                    return bezoeker;
                }
                catch (Exception ex)
                {
                    throw new BezoekerException("Geef bezoeker is niet gelukt.", ex);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }
    }
}


