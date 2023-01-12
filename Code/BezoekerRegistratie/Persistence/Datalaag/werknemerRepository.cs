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
using System.Numerics;
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

        public void ZetNonActiefWerknemer(int id)
        {
            string query = "UPDATE dbo.Werknemer " +
                "SET actief=0 " +
                "WHERE werknemerId = @id;";

            SqlConnection conn = GetConnection();
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                try
                {
                    conn.Open();
                    command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                    command.Parameters.Add(new SqlParameter("@actief", SqlDbType.Bit));

                    command.Parameters["@id"].Value = id;
                    command.Parameters["@actief"].Value = false;

                    command.ExecuteNonQuery();
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

        public bool HeeftWerknemer(int id)
        {
            SqlConnection conn = GetConnection();
            string sql = "select count(*) from Werknemer where werknemerId = @id and actief=1;";
            using (SqlCommand cmd = conn.CreateCommand())
            {
                try
                {
                    conn.Open();
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@id", id);

                    int count = (int)cmd.ExecuteScalar();
                    if (count > 0)
                    {
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    throw new WerknemerRepoException("HeeftWerknemer", ex);
                }
                finally { conn.Close(); }
                return false;
            }
        }

        public void UpdateWerknemer(Werknemer werknemer)
        {
            string query = "UPDATE dbo.Werknemer " +
               "SET actief=0 " +
               "WHERE werknemerId = @id;";

            string query2 = $"INSERT INTO dbo.Werknemer (voornaam, achternaam, email, functie, bedrijfId, actief) output INSERTED.werknemerId " +
               $"VALUES(@voornaam, @achternaam, @email, @functie, @bedrijfId, 1);";

            SqlTransaction trans = null;
            SqlConnection conn = GetConnection();
            try
            {
                conn.Open();
                trans = conn.BeginTransaction();
                SqlCommand cmd1 = new SqlCommand(query, conn, trans);
                cmd1.Parameters.AddWithValue("@actief", 0);
                cmd1.Parameters.AddWithValue("@id", werknemer.Id);
                cmd1.ExecuteNonQuery();
                

                SqlCommand cmd2 = new SqlCommand(query2, conn, trans);

                cmd2.Parameters.AddWithValue("@actief", 0);
                cmd2.Parameters.AddWithValue("@werknemerId", werknemer.Id);
                cmd2.Parameters.AddWithValue("@voornaam", werknemer.Voornaam);
                cmd2.Parameters.AddWithValue("@achternaam", werknemer.Achternaam);
                cmd2.Parameters.AddWithValue("@email", werknemer.Email);
                cmd2.Parameters.AddWithValue("@functie", werknemer.Functie);
                cmd2.Parameters.AddWithValue("@bedrijfId", werknemer.Bedrijf.Id);

                werknemer.Id = (int)cmd2.ExecuteScalar();
                trans.Commit();
            }
            catch(Exception ex)
            {
                trans.Rollback();
                throw new WerknemerRepoException("UpdateWerknemer", ex);
            }
           
        }
    }
}

