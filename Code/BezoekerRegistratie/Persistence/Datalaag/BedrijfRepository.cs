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
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Datalaag
{
    public class BedrijfRepository : BaseRepository, IBedrijfRepository
    {
        private string _tableName = "Bedrijf";
        public BedrijfRepository()
        {
        }

        public List<Bedrijf> GeefAlleBedrijven()
        {
            SqlConnection conn = GetConnection();
            List<Bedrijf> bedrijven = new List<Bedrijf>();
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
                        int id = (int)dataReader["bedrijfId"];
                        string naam = (string)dataReader["naam"];
                        string btw = (string)dataReader["btwNummer"];
                        string email = (string)dataReader["email"];
                        string adres = (string)dataReader["adres"];
                        string tel = (string)dataReader["telefoon"];

                        //Bedrijf bedrijf = new Bedrijf(naam, btw, adres, tel, email);

                        Bedrijf bedrijf = new Bedrijf(id, naam, btw, adres, tel, email);

                        bedrijven.Add(bedrijf);
                    }
                }
            }
            catch (Exception e)
            {
                throw new BedrijfException(e.Message);
            }
            finally
            {
                conn.Close();
            }
            return bedrijven;
        }

        public Bedrijf GeefBedrijfOpNaam(string bedrijfNaam)
        {
            string query = "SELECT * from dbo.Bedrijf where naam=@naam";
            SqlConnection conn = GetConnection();
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                try
                {
                    conn.Open();
                    command.Parameters.AddWithValue("@naam", bedrijfNaam);
                    IDataReader dataReader = command.ExecuteReader();
                    dataReader.Read();
                    Bedrijf bedrijf = new Bedrijf((int)dataReader["BedrijfId"], (string)dataReader["naam"], (string)dataReader["btw"], (string)dataReader["adres"], (string)dataReader["telefoon"], (string)dataReader["email"]);
                    dataReader.Close();
                    Console.WriteLine(bedrijf);
                    return bedrijf;
                }
                catch (Exception e)
                {
                    throw new BedrijfException("Geef bedrijf is niet gelukt", e);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public void VoegNieuwBedrijfToe(Bedrijf bedrijf)
        {
            // public Bedrijf(int id, string naam, string btw, string adres, string telefoon, string email)
            string query = "INSERT INTO dbo.Bedrijf (naam,btwNummer,adres,telefoon,email) VALUES(@naam,@btwNummer,@adres,@telefoon,@email)";
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
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    BedrijfException be = new BedrijfException("Bedrijf toevoegen is niet gelukt", e);
                    be.Data.Add("Bedrijf:", bedrijf);
                    throw be;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
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
                    BedrijfException be = new BedrijfException("Bedrijf verwijderen is niet gelukt", e);
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

                string query = $"SELECT * FROM {_tableName} WHERE " +
                    $"( naam like '{zoekText}%' or " +
                    $"btwNummer like '{zoekText}%' or " +
                    $"email like '{zoekText}%' or " +
                    $"adres like '{zoekText}%' or " +
                    $"telefoon like '{zoekText}%' ) and " +
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
                throw new BedrijfException(e.Message);
            }
            finally
            {
                conn.Close();
            }
            return bedrijven;
        }

        public Bedrijf GeefBedrijfOpId(int id)
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
                    Bedrijf bedrijf = new Bedrijf((int)dataReader["BedrijfId"], (string)dataReader["naam"], (string)dataReader["btw"], (string)dataReader["adres"], (string)dataReader["telefoon"], (string)dataReader["email"]);
                    dataReader.Close();
                    Console.WriteLine(bedrijf);
                    return bedrijf;
                }
                catch (Exception e)
                {
                    throw new BedrijfException("Geef bedrijf is niet gelukt", e);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public List<Bedrijf> GeefBedrijvenOpWerknemerEmail(string email)
        {
            SqlConnection conn = GetConnection();
            List<Bedrijf> bedrijven = new List<Bedrijf>();
            try
            {
                conn.Open();

                string query = $"SELECT * FROM {_tableName} b " +
                    $"join werknemer w on w.bedrijfId = b.bedrijfId " +
                    $"WHERE w.email = '{email}';";
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
                throw new WerknemerException(e.Message);
            }
            finally
            {
                conn.Close();
            }
            return bedrijven;
        }

        public void UpdateBedrijf(Bedrijf bedrijf)
        {
            string query = "UPDATE dbo.Bedrijf " +
                 "SET actief=@actief " +
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

                    command.Parameters["@id"].Value = bedrijf.Id;
                    //command.Parameters["@naam"].Value = bedrijf.Naam;
                    //command.Parameters["@btwNummer"].Value = bedrijf.Btw;
                    //command.Parameters["@email"].Value = bedrijf.Email;
                    //command.Parameters["@telefoon"].Value = bedrijf.Telefoon;
                    //command.Parameters["@adres"].Value = bedrijf.Adres;

                    command.ExecuteNonQuery();
                    VoegNieuwBedrijfToe(bedrijf);
                }
                catch (Exception e)
                {
                    BedrijfException be = new BedrijfException("Bedrijf kon niet geupdate worden", e);
                    throw be;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public Bedrijf GeefBedrijfOpEmail(string email)
        {
            string query = "SELECT * from dbo.Bedrijf where email=@email";
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
                    throw new BedrijfException("Geef bedrijf is niet gelukt", e);
                }
                finally
                {
                    conn.Close();
                }

            }
            return null;
        }

        public Bedrijf GeefBedrijfViaNaam(string value)
        {
            SqlConnection conn = GetConnection();
            Bedrijf _bedrijf = null;
            try
            {
                conn.Open();

                string query = $"SELECT * FROM {_tableName} WHERE naam = '{value}' ";

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
                throw new WerknemerException(e.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
//Bedrijf bedrijf = new Bedrijf((string)dataReader["naam"], (string)dataReader["btw"], (string)dataReader["adres"], (string)dataReader["telefoon"], (string)dataReader["email"]);   