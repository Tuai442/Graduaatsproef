using Controller.Interfaces;
using Controller.Interfaces.Models;
using Controller.Models;
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
        private string _tableName = "Bedrijven";
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
                        int id = (int)dataReader["BedrijfId"];
                        string naam = (string)dataReader["Naam"];
                        string btw = (string)dataReader["BTW"];
                        string email = (string)dataReader["Email"];
                        string adres = (string)dataReader["Adres"];
                        string tel = (string)dataReader["Telefoon"];

                        //Bedrijf bedrijf = new Bedrijf(naam, btw, adres, tel, email);
                        
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

        public Bedrijf GeefBedrijfOpNaam(string bedrijf)
        {
            throw new NotImplementedException();
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
                    command.Parameters.Add(new SqlParameter("@telefoon", SqlDbType.Int));
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
            throw new NotImplementedException();
        }


        public Bedrijf GeefBedrijfOpId(int id)
        {
            return GeefBedrijfOpId(id);
        }


        public List<Bedrijf> GeefBedrijvenOpWerknemerEmail(string email)
        {
            SqlConnection conn = GetConnection();
            List<Bedrijf> bedrijven = new List<Bedrijf>();
            try
            {
                conn.Open();

                string query = $"SELECT * FROM {_tableName} b " +
                    $"join Werknemers w on w.BedrijfId = b.BedrijfId " +
                    $"WHERE w.Email = '{email}';";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader dataReader = cmd.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        int id = (int)dataReader["BedrijfId"];
                        string naam = (string)dataReader["Naam"];
                        string btw = (string)dataReader["BTW"];
                        string emailB = (string)dataReader["Email"];
                        string adres = (string)dataReader["Adres"];
                        string tel = (string)dataReader["Telefoon"];
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

    }
}