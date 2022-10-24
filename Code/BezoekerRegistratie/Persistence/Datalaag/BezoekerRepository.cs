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
    public class BezoekerRepository: BaseRepository, IBezoekerRepository
    {
        private string connectionString;

        public BezoekerRepository()
        {
           
        }
        private SqlConnection GetConnection()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }
        public void VoegBezoekerToe(Bezoeker bezoeker)
        {
            string query = "INSERT INTO dbo.Bezoeker (voornaam,achternaam,email,bedrijfId,nummerplaat,aanwezig) VALUES(@voornaam,@achternaam,@email,@bedrijfId,@nummerplaat,@aanwezig)";
            SqlConnection conn = GetConnection();
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                try
                {
                    conn.Open();
                    //command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                    command.Parameters.Add(new SqlParameter("@voornaam", SqlDbType.NVarChar));
                    command.Parameters.Add(new SqlParameter("@achternaam", SqlDbType.NVarChar));
                    command.Parameters.Add(new SqlParameter("@email", SqlDbType.NVarChar));
                    command.Parameters.Add(new SqlParameter("@bedrijfId", SqlDbType.Int));
                    command.Parameters.Add(new SqlParameter("@nummerplaat", SqlDbType.NVarChar));
                    command.Parameters.Add(new SqlParameter("@aanwezig", SqlDbType.Bit));
                    // command.Parameters["@id"].Value = klant.KlantID;
                    command.Parameters["@voornaam"].Value = bezoeker.Voornaam;
                    command.Parameters["@achternaam"].Value = bezoeker.Achternaam;
                    command.Parameters["@email"].Value = bezoeker.Email;
                    //command.Parameters["@bedrijfId"].Value = bezoeker.BedrijfId;
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
            string query1 = "DELETE FROM dbo.Bezoeker WHERE id=@id";
            SqlConnection conn1 = GetConnection();
            using (SqlCommand command = new SqlCommand(query1, conn1))
            {
                try
                {
                    conn1.Open();
                    command.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int));
                    command.Parameters["@Id"].Value = bezoeker.BezoekerId;
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
                    conn1.Close();
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
                        Bezoeker bezoeker = new Bezoeker((string)dataReader["voornaam"], (string)dataReader ["achternaam"], (string)dataReader ["email"],(int)dataReader ["bedrijfId"],(string)dataReader ["nummerplaat"],(bool)dataReader ["aanwezig"]);
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
            throw new NotImplementedException();
        }

        public List<Bezoeker> GeefAlleBezoekers()
        {
            throw new NotImplementedException();
        }

        public void UpdateBezoeker(Bezoeker bezoeker)
        {
            throw new NotImplementedException();
        }

        public List<Bezoeker> GeefAlleAanwezigeBezoekers()
        {
            throw new NotImplementedException();
        }

        public List<Bezoeker> ZoekBezoekersOp(string zoekText)
        {
            throw new NotImplementedException();
        }

        public Persoon GeefPersoonOpVolledigeNaam(string naam, string achternaam)
        {
            throw new NotImplementedException();
        }
    }
}


