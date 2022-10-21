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
    public class BedrijfRepository
    {
        private string connectionString;

        public BedrijfRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }
        private SqlConnection GetConnection()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }
        public List<Bedrijf> GeefAlleBedrijven()
        {
            string query = "SELECT * from dbo.Bedrijf";
            SqlConnection conn = GetConnection();
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                try
                {
                    List<Bedrijf> bedrijven = new List<Bedrijf>();
                    conn.Open();
                    IDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Bedrijf bedrijf = new Bedrijf(/*(int)dataReader["bedrijfId"],*/ (string)dataReader["naam"], (string)dataReader["btwNummer"], (string)dataReader["adres"], (string)dataReader["telefoon"], (string)dataReader["email"]);
                        bedrijven.Add(bedrijf);
                    }
                    dataReader.Close();
                    foreach (Bedrijf bedrijf in bedrijven)
                    {
                        Console.WriteLine(bedrijf);
                    }
                    return bedrijven;
                }
                catch (Exception ex)
                {
                    throw new BedrijfException("Geef bedrijven is niet gelukt.", ex);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }
}