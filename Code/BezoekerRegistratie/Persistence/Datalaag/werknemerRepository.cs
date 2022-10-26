using Controller;
using Controller.Interfaces;
using Controller.Models;
using Persistence.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Datalaag
{
    public class WerknemerRepository:  BaseRepository, IWerknemerRepository
    {
        private string _tableName = "Werknemers";
        public WerknemerRepository()
        {

        }
        
        public List<Werknemer> GeefAlleWerknemer()
        {
            string query = "SELECT * FROM dbo.Werknemer INNER JOIN Bedrijf ON dbo.Werknemer_bedrijfId = dbo.Bedrijf_bedrijfId";
            SqlConnection conn = GetConnection();
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                try
                {
                    List<Werknemer> werknemers = new List<Werknemer>();
                    conn.Open();
                    IDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        /*Werknemer werknemer = new Werknemer(/*(int)dataReader["WerknemerId"], (string)dataReader["voornaam"], (string)dataReader["achternaam"], (string)dataReader["email"], (string)dataReader["functie"], (string)dataReader["bedrijfNaam"]);
                        werknemers.Add(werknemer);*/
                    }
                    dataReader.Close();
                    foreach (Werknemer werknemer in werknemers)
                    {
                        Console.WriteLine(werknemer);
                    }
                    return werknemers;
                }
                catch (Exception ex)
                {
                    throw new WerknemerException("Geef werknemers is niet gelukt.", ex);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public void VoegWerknemerToe(Werknemer werknemer)
        {
            string query = $"INSERT INTO {_tableName} (Voornaam, Achternaam, Email, Functie, BedrijfId) " +
                $"VALUES(@Voornaam, @Achternaam, @Achternaam, @Functie, @BedrijfId);"; 
               
            SqlConnection conn = GetConnection();
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                try
                {
                    conn.Open();

                    command.Parameters.Add(new SqlParameter("@Voornaam", SqlDbType.NVarChar));
                    command.Parameters["@Voornaam"].Value = werknemer.Voornaam;

                    command.Parameters.Add(new SqlParameter("@Achternaam", SqlDbType.NVarChar));
                    command.Parameters["@Achternaam"].Value = werknemer.Achternaam;

                    command.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar));
                    command.Parameters["@Email"].Value = werknemer.Email;

                    command.Parameters.Add(new SqlParameter("@Functie", SqlDbType.NVarChar));
                    command.Parameters["@Functie"].Value = werknemer.Functie;

                    command.Parameters.Add(new SqlParameter("@BedrijfId", SqlDbType.Int));
                    command.Parameters["@BedrijfId"].Value = werknemer.Bedrijf.Id;

                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {

                    throw new Exception(e.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        public Werknemer GeefWerknemerOpNaam(string contactPersoon)
        {
            throw new NotImplementedException();
        }

        public Werknemer GeefWerknemerOpId(int id)
        {
            return GeefWerknemerOpId(id);
        }

        public List<Werknemer> GeefAlleWerknemers()
        {
            SqlConnection conn = GetConnection();
            List<Werknemer> werknemers = new List<Werknemer>();
            try
            {
                conn.Open();

                string query = $"SELECT * FROM {_tableName};";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader dataReader = cmd.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        int id = (int)dataReader["WerknemerId"];
                        string voornaam = (string)dataReader["Voornaam"];
                        string achternaam = (string)dataReader["Achternaam"];
                        string email = (string)dataReader["Email"];
                        string functie = (string)dataReader["Functie"];
                        int bedrijfId = (int)dataReader["BedrijfId"];
                        Bedrijf bedrijf = GeefBedrijfOpId(bedrijfId);

                        Werknemer werknemer = new Werknemer(voornaam, achternaam, email, functie, bedrijf);
                        werknemers.Add(werknemer);
                    }


                }
            }
            catch (Exception e)
            {
                throw new WerknemerException(e.Message);
            }
            finally
            {
                conn.Close();
            }
            return werknemers;
        }

        public List<Werknemer> ZoekOpWerknemers(string zoekText)
        {
            throw new NotImplementedException();
        }

        public Persoon GeefPersoonOpVolledigeNaam(string naam, string achternaam)
        {
            throw new NotImplementedException();
        }

        public Werknemer GeefWerknemerOpEmail(string email)
        {
            SqlConnection conn = GetConnection();
            Werknemer werknemer = null;
            try
            {
                conn.Open();

                string query = $"SELECT * FROM {_tableName} WHERE Email = '{email}';";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader dataReader = cmd.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        int id = (int)dataReader["WerknemerId"];
                        string voornaam = (string)dataReader["Voornaam"];
                        string achternaam = (string)dataReader["Achternaam"];
                        string emailW = (string)dataReader["Email"];
                        string functie = (string)dataReader["Functie"];
                        int bedrijfId = (int)dataReader["BedrijfId"];
                        Bedrijf bedrijf = GeefBedrijfOpId(bedrijfId);

                        werknemer = new Werknemer(voornaam, achternaam, emailW, functie, bedrijf);
                    }


                }
            }
            catch (Exception e)
            {
                throw new WerknemerException(e.Message);
            }
            finally
            {
                conn.Close();
            }
            return werknemer;
        }

        public List<Werknemer> GeefWerknemersOpEmailBedrijf(string email)
        {
            SqlConnection conn = GetConnection();
            List<Werknemer> werknemers = new List<Werknemer>();
            try
            {
                conn.Open();

                string query = $"SELECT * FROM {_tableName} w " +
                    $"join Bedrijven b on w.BedrijfId = b.BedrijfId " +
                    $"WHERE b.Email = '{email}';";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader dataReader = cmd.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        int id = (int)dataReader["WerknemerId"];
                        string voornaam = (string)dataReader["Voornaam"];
                        string achternaam = (string)dataReader["Achternaam"];
                        string emailW = (string)dataReader["Email"];
                        string functie = (string)dataReader["Functie"];
                        int bedrijfId = (int)dataReader["BedrijfId"];
                        Bedrijf bedrijf = GeefBedrijfOpId(bedrijfId);

                        Werknemer werknemer = new Werknemer(voornaam, achternaam, emailW, functie, bedrijf);
                        werknemers.Add(werknemer);
                    }


                }
            }
            catch (Exception e)
            {
                throw new WerknemerException(e.Message);
            }
            finally
            {
                conn.Close();
            }
            return werknemers;
        }
    }
}

