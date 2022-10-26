using Controller.Models;
using Persistence.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Datalaag
{
    public class BaseRepository
    {
        protected string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Tuur\Desktop\t\Graduaatsproef\Code\BezoekerRegistratie\Datalaag\Database1.mdf;Integrated Security=True";
        
        public BaseRepository()
        {
        }

        protected SqlConnection GetConnection()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }


        // Deze methode's worden alleen gebruikt voor data in te laden
        protected Bedrijf GeefBedrijfOpId(int id)
        {
            SqlConnection conn = GetConnection();
            Bedrijf bedrijf = null;
            try
            {

                conn.Open();

                string query = $"SELECT * FROM Bedrijven WHERE BedrijfId = {id};";
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
                        string telefoon = (string)dataReader["Telefoon"];

                        bedrijf = new Bedrijf(naam, btw, adres, telefoon, email);
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
            return bedrijf;
        }
        
        protected Werknemer GeefWerknemerOpId(int id) 
        {
            SqlConnection conn = GetConnection();
            Werknemer werknemer = null;
            try
            {

                conn.Open();

                string query = $"SELECT * FROM Werknemers WHERE WerknemerId = {id};";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader dataReader = cmd.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        int idd = (int)dataReader["WerknemerId"];
                        string voornaam = (string)dataReader["Voornaam"];
                        string achternaam = (string)dataReader["Achternaam"];
                        string functie = (string)dataReader["Functie"];
                        string email = (string)dataReader["Email"];
                        int bedrijfId = (int)dataReader["BedrijfId"];
                        Bedrijf bedrijf = GeefBedrijfOpId(bedrijfId);

                        werknemer = new Werknemer(voornaam, achternaam, email, functie, bedrijf);
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
            return werknemer;
        }

        protected int GeefIdVanWerknemer(string email)
        {
            SqlConnection conn = GetConnection();
            int id = -1;
            try
            {
                conn.Open();

                string query = $"SELECT * FROM Werknemers WHERE email = '{email}';";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader dataReader = cmd.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        id = (int)dataReader["WerknemerId"];
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
            return id;
        }
    }
}
