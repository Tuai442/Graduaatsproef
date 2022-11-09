using Controller;
using Controller.Interfaces;
using Controller.Interfaces.Models;
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
    public class WerknemerRepository: BaseRepository, IWerknemerRepository
    {
        private string _tableName = "Werknemer";
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
            string query = $"INSERT INTO dbo.Werknemer (voornaam, achternaam, email, functie, bedrijfId) " +
                $"VALUES(@voornaam, @achternaam, @email, @functie, @bedrijfId);"; 

            SqlConnection conn = GetConnection();
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                try
                {
                    conn.Open();
                    
                    command.Parameters.Add(new SqlParameter("@voornaam", SqlDbType.VarChar));
                    command.Parameters["@voornaam"].Value = werknemer.Voornaam;

                    command.Parameters.Add(new SqlParameter("@achternaam", SqlDbType.VarChar));
                    command.Parameters["@achternaam"].Value = werknemer.Voornaam;

                    command.Parameters.Add(new SqlParameter("@email", SqlDbType.VarChar));
                    command.Parameters["@email"].Value = werknemer.Email;

                    command.Parameters.Add(new SqlParameter("@functie", SqlDbType.VarChar));
                    command.Parameters["@functie"].Value = werknemer.Functie;

                    
                    // TODO: contorle of bedrijf in db is.
                    command.Parameters.Add(new SqlParameter("@bedrijfId", SqlDbType.VarChar));
                    command.Parameters["@bedrijfId"].Value = werknemer.Bedrijf.Id;

                    command.ExecuteNonQuery();

                }

                catch (Exception e)
                {

                    throw new WerknemerException("Werknemer toevoegen niet gelukt", e);

                }
                finally
                {
                    conn.Close();
                }
            }

        }

        public Werknemer GeefWerknemerOpNaam(string voornaam, string achternaam)
        {
            string query = "SELECT * from dbo.Bedrijf where voornaam=@voornaam and achternaam=@achternaam";
            SqlConnection conn = GetConnection();
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                try
                {
                    conn.Open();
                    command.Parameters.AddWithValue("@voornaam", voornaam);
                    command.Parameters.AddWithValue("@achternaam", achternaam);
                    IDataReader dataReader = command.ExecuteReader();
                    dataReader.Read();

                    int bedrijfId = (int)dataReader["bedrijfId"];
                    Bedrijf bedrijf = GeefBedrijfOpId(bedrijfId);
                    Werknemer werknemer = new Werknemer((int)dataReader["id"], (string)dataReader["Voornaam"], (string)dataReader["Achternaam"], (string)dataReader["email"], (string)dataReader["functie"], bedrijf);
                    dataReader.Close();
                    Console.WriteLine(werknemer);
                    return werknemer;
                }
                catch (Exception e)
                {
                    throw new BedrijfException("Geef werknemer is niet gelukt", e);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public Werknemer GeefWerknemerOpId(int id)
        {
            string query = "SELECT * from dbo.Bedrijf where id=@id";
            SqlConnection conn = GetConnection();
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                try
                {
                    conn.Open();
                    command.Parameters.AddWithValue("@id", id);
                    IDataReader dataReader = command.ExecuteReader();
                    dataReader.Read();

                    int bedrijfId = (int)dataReader["bedrijfId"];
                    Bedrijf bedrijf = GeefBedrijfOpId(bedrijfId);
                    Werknemer werknemer = new Werknemer((int)dataReader["id"], (string)dataReader["Voornaam"], (string)dataReader["Achternaam"], (string)dataReader["email"], (string)dataReader["functie"], bedrijf);
                    dataReader.Close();
                    Console.WriteLine(werknemer);
                    return werknemer;
                }
                catch (Exception e)
                {
                    throw new BedrijfException("Geef werknemer is niet gelukt", e);
                }
                finally
                {
                    conn.Close();
                }
            }
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
                        int id = (int)dataReader["werknemerId"];
                        string voornaam = (string)dataReader["voornaam"];
                        string achternaam = (string)dataReader["achternaam"];
                        string email = (string)dataReader["email"];
                        string functie = (string)dataReader["functie"];
                        int bedrijfId = (int)dataReader["bedrijfId"];
                        Bedrijf bedrijf = GeefBedrijfOpId(bedrijfId);

                        Werknemer werknemer = new Werknemer(id, voornaam, achternaam, email, functie, bedrijf);
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
            SqlConnection conn = GetConnection();
            List<Werknemer> werknemers = new List<Werknemer>();
            try
            {
                conn.Open();

                string query = $"SELECT * FROM {_tableName} WHERE " +
                    $"Voornaam like '{zoekText}%' or " +
                    $"Achternaam like '{zoekText}%' or " +
                    $"Email like '{zoekText}%' or " +
                    $"Functie like '{zoekText}%'; ";

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

                        Werknemer werknemer = new Werknemer(id, voornaam, achternaam, email, functie, bedrijf);
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

                        werknemer = new Werknemer(id, voornaam, achternaam, emailW, functie, bedrijf);
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
                    $"join Bedrijf b on w.bedrijfId = b.bedrijfId " +
                    $"WHERE b.email = '{email}';";
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

                        Werknemer werknemer = new Werknemer(id, voornaam, achternaam, emailW, functie, bedrijf);
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

        public void UpdateWerknemer(Werknemer werknemer)
        {
            throw new NotImplementedException();
        }

        public Werknemer GeefWerknemerOpNaam(string contactPersoon)
        {
            throw new NotImplementedException();
        }

      
    }
}

