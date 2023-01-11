using Controller.Interfaces;
using Controller.Models;
using CountryValidation.Countries;
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
    public class BezoekerRepository : BaseRepository , IBezoekerRepository
    {

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
                    command.Parameters["@nummerplaat"].Value = "test";// TODO: Nog niet van toepassing
                    command.Parameters["@aanwezig"].Value = Convert.ToInt32(bezoeker.Aanwezig);
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    BezoekerRepoException be = new BezoekerRepoException("Bezoeker toevoegen is niet gelukt", e);
                    be.Data.Add("Bezoeker:", bezoeker);
                    throw be;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        //TODO: moet aanpassen en niet verwijderen
       /* public void VerwijderBezoeker(int index)
        {
            string query = "DELETE FROM dbo.Bezoeker WHERE bezoekerId=@bezoekerId";
            SqlConnection conn = GetConnection();
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                try
                {
                    conn.Open();
                    command.Parameters.Add(new SqlParameter("@bezoekerId", SqlDbType.Int));
                    //command.Parameters["@bezoekerId"].Value = bezoeker.Id;
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    BezoekerRepoException be = new BezoekerRepoException("Bezoeker verwijderen is niet gelukt", e);
                    //be.Data.Add("Bezoeker:", bezoeker);
                    throw be;
                }
                finally
                {
                    conn.Close();
                }
            }
        }*/

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
                    if (dataReader.Read())
                    {
                        string nummerplaat = (string)dataReader["nummerplaat"];
                        bool aanwezig = Convert.ToBoolean(dataReader["aanwezig"]);
                        Bezoeker bezoeker = new Bezoeker((int)dataReader["bezoekerId"], 
                            (string)dataReader["voornaam"], (string)dataReader["achternaam"], 
                            (string)dataReader["email"], (string)dataReader["bedrijf"], aanwezig, nummerplaat);
                        dataReader.Close();
                        return bezoeker;
                    }
                }
                catch (Exception e)
                {
                    throw new BezoekerRepoException("Geef bezoeker op email is niet gelukt", e);
                }
                finally
                {
                    conn.Close();
                }
                return null;
            }
        }
        public void ZetBezoekerNonActief(Bezoeker bezoeker)
        {
            string query = "UPDATE dbo.Bezoeker " +
                "SET voornaam=@voornaam, achternaam=@achternaam, email=@email, bedrijf=@bedrijf, nummerplaat=@nummerplaat, " +
                "aanwezig=0 " +
                "WHERE bezoekerId = @id;";
            SqlConnection conn = GetConnection();
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                try
                {
                    conn.Open();
                    command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                    command.Parameters.Add(new SqlParameter("@voornaam", SqlDbType.NVarChar));
                    command.Parameters.Add(new SqlParameter("@achternaam", SqlDbType.NVarChar));
                    command.Parameters.Add(new SqlParameter("@email", SqlDbType.NVarChar));
                    command.Parameters.Add(new SqlParameter("@bedrijf", SqlDbType.NVarChar));
                    command.Parameters.Add(new SqlParameter("@nummerplaat", SqlDbType.NVarChar));
                    command.Parameters.Add(new SqlParameter("@aanwezig", SqlDbType.Bit));
                    command.Parameters["@id"].Value = bezoeker.Id;
                    command.Parameters["@voornaam"].Value = bezoeker.Voornaam;
                    command.Parameters["@achternaam"].Value = bezoeker.Achternaam;
                    command.Parameters["@email"].Value = bezoeker.Email;
                    command.Parameters["@bedrijf"].Value = bezoeker.Bedrijf;
                    command.Parameters["@nummerplaat"].Value = "test";// Nog niet van toepassing
                    command.Parameters["@aanwezig"].Value = Convert.ToInt32(bezoeker.Aanwezig);
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    BezoekerRepoException be = new BezoekerRepoException("Bezoeker updaten is niet gelukt", e);
                    be.Data.Add("Bezoeker:", bezoeker);
                    throw be;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public List<Bezoeker> ZoekBezoekersOp(string zoekText)
        {
            string query = $"SELECT * from dbo.Bezoeker where " +
                $"(voornaam like '{zoekText}%' or " +
                $"achternaam like '{zoekText}%' or " +
                $"bedrijf like '{zoekText}%' or " +
                $"email like '{zoekText}%') and aanwezig='True'; ";

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
                        int id = (int)dataReader["bezoekerId"];
                        string voornaam = (string)dataReader["voornaam"];
                        string achternaam = (string)dataReader["achternaam"];
                        string email = (string)dataReader["email"];
                        string bedrijf = (string)dataReader["bedrijf"];
                        string nummerplaat = (string)dataReader["nummerplaat"];

                        bool aanwezig = Convert.ToBoolean(dataReader["aanwezig"]);
                        Bezoeker bezoeker = new Bezoeker(id, voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat);
                        bezoekers.Add(bezoeker);
                    }
                    dataReader.Close();

                    return bezoekers;
                }
                catch (Exception ex)
                {
                    throw new BezoekerRepoException("Geef bezoekers is niet gelukt.", ex);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public List<Bezoeker> GeefAlleAanwezigeBezoekers()
        {
            string query = "SELECT * from dbo.Bezoeker where aanwezig='TRUE' ;";
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
                        int id = (int)dataReader["bezoekerId"];
                        string voornaam = (string)dataReader["voornaam"];
                        string achternaam = (string)dataReader["achternaam"];
                        string email = (string)dataReader["email"];
                        string bedrijf = (string)dataReader["bedrijf"];
                        string nummerplaat = (string)dataReader["nummerplaat"];

                        bool aanwezig = Convert.ToBoolean(dataReader["aanwezig"]);
                        Bezoeker bezoeker = new Bezoeker(id, voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat);
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
                    throw new BezoekerRepoException("Geef bezoekers is niet gelukt.", ex);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }
   
}


