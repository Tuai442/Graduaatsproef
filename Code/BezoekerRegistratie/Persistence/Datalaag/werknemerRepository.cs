using Controller;
using Controller.Interfaces;
using Controller.Models;
using Persistence.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Datalaag
{
    public class WerknemerRepository : BaseRepository, IWerknemerRepository
    {
        private string _tableName = "Werknemer";
        public WerknemerRepository()
        {

        }

        public void VoegWerknemerToe(Werknemer werknemer)
        {
            string query = $"INSERT INTO dbo.Werknemer (voornaam, achternaam, email, functie, bedrijfId, actief) output INSERTED.werknemerId " +
                $"VALUES(@voornaam, @achternaam, @email, @functie, @bedrijfId, 1);";

            SqlConnection conn = GetConnection();
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                try
                {
                    conn.Open();

                    command.Parameters.Add(new SqlParameter("@voornaam", SqlDbType.VarChar));
                    command.Parameters["@voornaam"].Value = werknemer.Voornaam;

                    command.Parameters.Add(new SqlParameter("@achternaam", SqlDbType.VarChar));
                    command.Parameters["@achternaam"].Value = werknemer.Achternaam;

                    command.Parameters.Add(new SqlParameter("@email", SqlDbType.VarChar));
                    command.Parameters["@email"].Value = werknemer.Email;

                    command.Parameters.Add(new SqlParameter("@functie", SqlDbType.VarChar));
                    command.Parameters["@functie"].Value = werknemer.Functie;

                    command.Parameters.Add(new SqlParameter("@bedrijfId", SqlDbType.VarChar));
                    command.Parameters["@bedrijfId"].Value = werknemer.Bedrijf.Id;

                    werknemer.Id = (int)command.ExecuteScalar();

                }

                catch (Exception e)
                {

                    throw new WerknemerRepoException("Werknemer toevoegen niet gelukt", e);

                }
                finally
                {
                    conn.Close();
                }
            }

        }

        public Werknemer GeefWerknemerOpId(int id)
        {
            string query = "SELECT * from dbo.Werknemer where werknemerId =@id and actief = 1";
            SqlConnection conn = GetConnection();
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                try
                {
                    conn.Open();
                    command.Parameters.AddWithValue("@id", id);
                    IDataReader dataReader = command.ExecuteReader();
                    dataReader.Read();

                    string voornaam = (string)dataReader["voornaam"];
                    string achternaam = (string)dataReader["achternaam"];
                    string email = (string)dataReader["email"];
                    string functie = (string)dataReader["functie"];
                    int bedrijfId = (int)dataReader["bedrijfId"];

                    dataReader.Close();

                    Bedrijf bedrijf = GeefBedrijfOpId(bedrijfId);
                    Werknemer werknemer = new Werknemer(voornaam, achternaam, email, functie, bedrijf);

                    return werknemer;
                }
                catch (Exception e)
                {
                    throw new BedrijfRepoException("Geef werknemer is niet gelukt", e);
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

                string query = $"SELECT * FROM {_tableName} " +
                    $"WHERE actief = 1;";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader dataReader = cmd.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        int id = (int)dataReader["werknemerId"];
                        string voornaam = (string)dataReader["voornaam"];
                        string achternaam = (string)dataReader["achternaam"];
                        Trace.WriteLine(id);
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
                throw new WerknemerRepoException(e.Message);
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
                    $"( Voornaam like '{zoekText}%' or " +
                    $"Achternaam like '{zoekText}%' or " +
                    $"Email like '{zoekText}%' or " +
                    $"Functie like '{zoekText}%' ) and " +
                    $"actief = 1; ";

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
                throw new WerknemerRepoException(e.Message);
            }
            finally
            {
                conn.Close();
            }
            return werknemers;
        }


        public Werknemer GeefWerknemerOpEmail(string email)
        {
            SqlConnection conn = GetConnection();
            Werknemer werknemer = null;
            try
            {
                conn.Open();

                string query = $"SELECT * FROM {_tableName} WHERE Email = '{email}' and actief = 1;";
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
                throw new WerknemerRepoException(e.Message);
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
                    $"WHERE b.email = '{email}' and w.actief = 1;";
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
                throw new WerknemerRepoException(e.Message);
            }
            finally
            {
                conn.Close();
            }
            return werknemers;
        }

        //TODO: update anders schrijven
        public void ZetNonActiefWerknemer(Werknemer werknemer)
        {
            string query = "UPDATE dbo.Werknemer " +
                "SET actief=@actief " +
                "WHERE werknemerId = @id;";
            // TODO: met transactie 

                    SqlConnection conn = GetConnection();
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                try
                {
                    conn.Open();
                    command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                    command.Parameters.Add(new SqlParameter("@actief", SqlDbType.Bit));

                    command.Parameters["@id"].Value = werknemer.Id;
                    command.Parameters["@actief"].Value = false;

                    command.ExecuteNonQuery();
                    VoegWerknemerToe(werknemer);
                }
                catch (Exception e)
                {
                    WerknemerRepoException be = new WerknemerRepoException("Werknemer updaten is niet gelukt", e);
                    throw be;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }
}

