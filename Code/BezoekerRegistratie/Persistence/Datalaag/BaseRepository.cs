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
<<<<<<< HEAD
        protected string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\AA.SCORRO2022\graduaat proef\clone werkt 3 nov\Code\BezoekerRegistratie\Datalaag\Database1.mdf"";Integrated Security=True";
=======
        //link Sören
        //protected string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\soren\Documents\Academiejaar 2022-2023\projectwerk\10deversie\Code\BezoekerRegistratie\Datalaag\Database1.mdf;Integrated Security=True";
        
        //link Tuur
        //protected string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Tuur\Desktop\t\Graduaatsproef\Code\BezoekerRegistratie\Datalaag\Database1.mdf;Integrated Security=True";

        //link Diego
        protected string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Hogent\22-23\Graduaatsproef_Finaal\Graduaatsproef\Code\BezoekerRegistratie\Datalaag\Database1.mdf;Integrated Security=True";
       
>>>>>>> f27203b3dc56900cdf02b4a545eead0c6ddc3319
        
        //protected string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Hogent\22-23\Graduaatsproef_Finaal\Graduaatsproef\Code\BezoekerRegistratie\Datalaag\Database1.mdf;Integrated Security=True";

        // link noah
        // Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="D:\AA.SCORRO2022\graduaat proef\clone werkt 3 nov\Code\BezoekerRegistratie\Datalaag\Database1.mdf";Integrated Security=True

        // link tuur
        // protected string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Tuur\Desktop\t\Graduaatsproef\Code\BezoekerRegistratie\Datalaag\Database.mdf;Integrated Security=True";

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

                string query = $"SELECT * FROM Bedrijf WHERE BedrijfId = {id};";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader dataReader = cmd.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        string naam = (string)dataReader["naam"];
                        string btw = (string)dataReader["btwNummer"];
                        string email = (string)dataReader["email"];
                        string adres = (string)dataReader["adres"];
                        string telefoon = (string)dataReader["telefoon"];

                        bedrijf = new Bedrijf(id, naam, btw, adres, telefoon, email);
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

                string query = $"SELECT * FROM Werknemer WHERE werknemerId = {id};";
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

                        werknemer = new Werknemer(idd, voornaam, achternaam, email, functie, bedrijf);
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

                string query = $"SELECT * FROM Werknemer WHERE email = '{email}';";

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

        protected Bezoeker GeefBezoekerOpId(int id)
        {
            SqlConnection conn = GetConnection();
            Bezoeker bezoeker = null;
            try
            {

                conn.Open();

                string query = $"SELECT * FROM Bezoeker WHERE bezoekerId = {id};";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader dataReader = cmd.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        int idd = (int)dataReader["bezoekerId"];
                        string voornaam = (string)dataReader["voornaam"];
                        string achternaam = (string)dataReader["achternaam"];
                        string email = (string)dataReader["email"];
                        bool aanwezig = Convert.ToBoolean(dataReader["aanwezig"]);
                        string bedrijf = (string)dataReader["bedrijf"];

                        bezoeker = new Bezoeker(idd, voornaam, achternaam, email, bedrijf, aanwezig);
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
            return bezoeker;
        }
    }
}
