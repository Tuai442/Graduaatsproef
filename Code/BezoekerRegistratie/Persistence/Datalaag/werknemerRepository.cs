using Controller.Models;
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
    public class werknemerRepository
    {
        private string connectionString;

        public werknemerRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }
        private SqlConnection GetConnection()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
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
                        Werknemer werknemer = new Werknemer(/*(int)dataReader["WerknemerId"],*/ (string)dataReader["voornaam"], (string)dataReader["achternaam"], (string)dataReader["email"], (string)dataReader["functie"], (string)dataReader["bedrijfNaam"]);
                        werknemers.Add(werknemer);
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
    }
}

