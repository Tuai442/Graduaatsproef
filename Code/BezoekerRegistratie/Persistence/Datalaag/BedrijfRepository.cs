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
                        string naam = (string)dataReader["Naam"];
                        string btw = (string)dataReader["BTW"];
                        string email = (string)dataReader["Email"];
                        string adres = (string)dataReader["Adres"];
                        string tel = (string)dataReader["Telefoon"];
                        Bedrijf bedrijf = new Bedrijf(naam, btw, adres, tel, email);
                        
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
            throw new NotImplementedException();
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
                        
                        string naam = (string)dataReader["Naam"];
                        string btw = (string)dataReader["BTW"];
                        string emailB = (string)dataReader["Email"];
                        string adres = (string)dataReader["Adres"];
                        string tel = (string)dataReader["Telefoon"];
                        Bedrijf bedrijf = new Bedrijf(naam, btw, adres, tel, email);

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