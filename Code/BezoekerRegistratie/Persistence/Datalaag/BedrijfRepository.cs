using Controller;
using Controller.Interfaces;
using Controller.Models;
using Persistence.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Persistence.Datalaag
{
    public class BedrijfRepository : BaseRepository, IBedrijfRepository
    {
        public BedrijfRepository()
        {
        }

        public bool HeeftBedrijf(int bedrijfId)
        {
            SqlConnection conn = GetConnection();
            string sql = "select count(*) from Bedrijf where bedrijfId = @id and actief=1;";
            using (SqlCommand cmd = conn.CreateCommand())
            {
                try
                {
                    conn.Open();
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@id", bedrijfId);

                    int count = (int)cmd.ExecuteScalar();
                    if (count > 0)
                    {
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    throw new BedrijfRepoException("HeeftWerknemer", ex);
                }
                finally { conn.Close(); }
                return false;
            }
        }
        public void UpdateBedrijf(Bedrijf bedrijf)
        {
            string query = "UPDATE dbo.Bedrijf " +
                 "SET actief=0 " +
                 "WHERE bedrijfId = @id;"; 
            SqlConnection conn = GetConnection();
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                try
                {
                    conn.Open();


                    command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                    command.Parameters["@id"].Value = bedrijf.Id;

                    command.ExecuteNonQuery();
                    VoegNieuwBedrijfToe(bedrijf);
                }
                catch (Exception e)
                {
                    throw new BedrijfRepoException($"Bedrijf kon niet geupdate worden, door een probleem met de database \n {e.Message}");

                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public List<Bedrijf> GeefAlleBedrijven()
        {
            SqlConnection conn = GetConnection();
            List<Bedrijf> bedrijven = new List<Bedrijf>();
            try
            {
                conn.Open();

                string query = $"SELECT * FROM Bedrijf where actief = 1;";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader dataReader = cmd.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        int id = (int)dataReader["bedrijfId"];
                        string naam = (string)dataReader["naam"];
                        string btw = (string)dataReader["btwNummer"];
                        string email = (string)dataReader["email"];
                        string adres = (string)dataReader["adres"];
                        string tel = (string)dataReader["telefoon"];


                        Bedrijf bedrijf = new Bedrijf(id, naam, btw, adres, tel, email);

                        bedrijven.Add(bedrijf);
                    }
                }
            }
            catch (Exception e)
            {
                throw new BedrijfRepoException(e.Message);
            }
            finally
            {
                conn.Close();
            }
            return bedrijven;
        }

        public void VoegNieuwBedrijfToe(Bedrijf bedrijf)
        {
            string query = "INSERT INTO dbo.Bedrijf (naam,btwNummer,adres,telefoon,email, actief) output INSERTED.bedrijfId " +
                "VALUES(@naam,@btwNummer,@adres,@telefoon,@email, 1)";
            SqlConnection conn = GetConnection();
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                try
                {
                    conn.Open();
                    command.Parameters.Add(new SqlParameter("@naam", SqlDbType.NVarChar));
                    command.Parameters.Add(new SqlParameter("@btwNummer", SqlDbType.NVarChar));
                    command.Parameters.Add(new SqlParameter("@adres", SqlDbType.NVarChar));
                    command.Parameters.Add(new SqlParameter("@telefoon", SqlDbType.NVarChar));
                    command.Parameters.Add(new SqlParameter("@email", SqlDbType.NVarChar));
                    command.Parameters["@naam"].Value = bedrijf.Naam;
                    command.Parameters["@btwNummer"].Value = bedrijf.Btw;
                    command.Parameters["@adres"].Value = bedrijf.Adres;
                    command.Parameters["@telefoon"].Value = bedrijf.Telefoon;
                    command.Parameters["@email"].Value = bedrijf.Email;

                    bedrijf.Id = (int)command.ExecuteScalar();
                }
                catch (Exception e)
                {
                    throw new BedrijfRepoException("Bedrijf toevoegen is niet gelukt", e);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        //TODO: niet verwijderen, maar actief = 0
        public void VerwijderBedrijf(Bedrijf bedrijf)
        {
            string query = "DELETE FROM dbo.Bedrijf WHERE id=@id";
            SqlConnection conn = GetConnection();
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                try
                {
                    conn.Open();
                    command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                    command.Parameters["@id"].Value = bedrijf.Id;
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    BedrijfRepoException be = new BedrijfRepoException("Bedrijf verwijderen is niet gelukt", e);
                    be.Data.Add("Bedrijf:", bedrijf);
                    throw be;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public List<Bedrijf> ZoekBedrijfOp(string zoekText)
        {
            SqlConnection conn = GetConnection();
            List<Bedrijf> bedrijven = new List<Bedrijf>();
            try
            {
                conn.Open();
                string query = $"SELECT * FROM Bedrijf WHERE " +
                    $" naam like '{zoekText}%' or " +
                    $"btwNummer like '{zoekText}%' or " +
                    $"email like '{zoekText}%' or " +
                    $"adres like '{zoekText}%' or " +
                    $"telefoon like '{zoekText}%' and " +
                    $"actief = 1;";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader dataReader = cmd.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        int id = (int)dataReader["bedrijfId"];
                        string naam = (string)dataReader["naam"];
                        string btw = (string)dataReader["btwNummer"];
                        string email = (string)dataReader["email"];
                        string adres = (string)dataReader["adres"];
                        string tel = (string)dataReader["telefoon"];

                        Bedrijf bedrijf = new Bedrijf(id, naam, btw, adres, tel, email);
                        bedrijven.Add(bedrijf);
                    }
                }
            }
            catch (Exception e)
            {
                throw new BedrijfRepoException(e.Message);
            }
            finally
            {
                conn.Close();
            }
            return bedrijven;
        }

        public List<Bedrijf> GeefBedrijvenOpWerknemerEmail(string email)
        {
            SqlConnection conn = GetConnection();
            List<Bedrijf> bedrijven = new List<Bedrijf>();
            try
            {
                conn.Open();
                string query = $"SELECT * FROM Bedrijf b " +
                    $"join werknemer w on w.bedrijfId = b.bedrijfId " +
                    $"WHERE w.email = '{email}' and w.actief = 1 and b.acief = 1;";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader dataReader = cmd.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        int id = (int)dataReader["bedrijfId"];
                        string naam = (string)dataReader["naam"];
                        string btw = (string)dataReader["btwNummer"];
                        string emailB = (string)dataReader["email"];
                        string adres = (string)dataReader["adres"];
                        string tel = (string)dataReader["telefoon"];
                        Bedrijf bedrijf = new Bedrijf(id, naam, btw, adres, tel, email);

                        bedrijven.Add(bedrijf);
                    }
                }
            }
            catch (Exception e)
            {
                throw new WerknemerRepoException("GeefBedrijvenOpWerknemerEmail - Fout bij het ophalen van data uit de database.");
            }
            finally
            {
                conn.Close();
            }
            return bedrijven;
        }

        public void ZetBedrijfNonActief(int id)
        {
            string query = "UPDATE dbo.Bedrijf " +
                 "SET actief=0 " +
                 "WHERE bedrijfId = @id;"; //naam=@naam, btwNummer=@btwNummer, email=@email, telefoon=@telefoon, adres=@adres 
            SqlConnection conn = GetConnection();
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                try
                {
                    conn.Open();
                    command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                    //command.Parameters.Add(new SqlParameter("@naam", SqlDbType.NVarChar));
                    //command.Parameters.Add(new SqlParameter("@btwNummer", SqlDbType.NVarChar));
                    //command.Parameters.Add(new SqlParameter("@email", SqlDbType.NVarChar));
                    //command.Parameters.Add(new SqlParameter("@telefoon", SqlDbType.NVarChar));
                    //command.Parameters.Add(new SqlParameter("@adres", SqlDbType.NVarChar));

                    command.Parameters["@id"].Value = id;
                    //command.Parameters["@naam"].Value = bedrijf.Naam;
                    //command.Parameters["@btwNummer"].Value = bedrijf.Btw;
                    //command.Parameters["@email"].Value = bedrijf.Email;
                    //command.Parameters["@telefoon"].Value = bedrijf.Telefoon;
                    //command.Parameters["@adres"].Value = bedrijf.Adres;

                    command.ExecuteNonQuery();

                }
                catch (Exception e)
                {
                    throw new BedrijfRepoException($"Bedrijf kon niet geupdate worden, door een probleem met de database \n { e.Message }");
                    
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public Bedrijf GeefBedrijfOpEmail(string email)
        {
            string query = "SELECT * from dbo.Bedrijf where email=@email and actief = 1";
            SqlConnection conn = GetConnection();
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                try
                {
                    conn.Open();
                    command.Parameters.AddWithValue("@email", email);
                    IDataReader dataReader = command.ExecuteReader();
                    dataReader.Read();
                    int id = (int)dataReader["BedrijfId"];
                    string naam = (string)dataReader["naam"];
                    string btw = (string)dataReader["btwNummer"];
                    string adres = (string)dataReader["adres"];
                    string telefoon = (string)dataReader["telefoon"];
                    string emial = (string)dataReader["email"];
                    Bedrijf bedrijf = new Bedrijf(id, naam, btw, adres, telefoon, email);
                    dataReader.Close();

                    return bedrijf;
                }
                catch (Exception e)
                {
                    throw new BedrijfRepoException("Geef bedrijf is niet gelukt door een probleem met de database.", e);
                }
                finally
                {
                    conn.Close();
                }

            }
            
        }

        public Bedrijf GeefBedrijfViaNaam(string value)
        {
            SqlConnection conn = GetConnection();
            Bedrijf _bedrijf = null;
            try
            {
                conn.Open();

                string query = $"SELECT * FROM Bedrijf WHERE naam = '{value}' and actief = 1";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader dataReader = cmd.ExecuteReader();

                dataReader.Read();
                int id = (int)dataReader["bedrijfId"];
                string naam = (string)dataReader["naam"];
                string btw = (string)dataReader["btwNummer"];
                string email = (string)dataReader["email"];
                string adres = (string)dataReader["adres"];
                string tel = (string)dataReader["telefoon"];
                _bedrijf = new Bedrijf(id, naam, btw, adres, tel, email);
                dataReader.Close();

                return _bedrijf;
            }
            catch (Exception e)
            {
                throw new WerknemerRepoException(e.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        
    }
}
  