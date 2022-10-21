using Controller.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class BezoekerRepository
    {
        private string connectionString;

        public BezoekerRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }
        private SqlConnection GetConnection()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }
        public void VoegBezoekerToe(Bezoeker bezoeker)
        {
            string query = "INSERT INTO dbo.Bezoeker (voornaam,achternaam,email,nummerplaat) VALUES(@voornaam,@achternaam,@email,@nummerplaat)";
            SqlConnection conn = GetConnection();
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                try
                {
                    conn.Open();
                    //command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                    command.Parameters.Add(new SqlParameter("@voornaam", SqlDbType.NVarChar));
                    command.Parameters.Add(new SqlParameter("@achternaam", SqlDbType.NVarChar));
                    command.Parameters.Add(new SqlParameter("@email", SqlDbType.NVarChar));
                    command.Parameters.Add(new SqlParameter("@nummerplaat", SqlDbType.NVarChar));
                    // command.Parameters["@id"].Value = klant.KlantID;
                    command.Parameters["@voornaam"].Value = bezoeker.Voornaam;
                    command.Parameters["@achternaam"].Value = bezoeker.Achternaam;
                    command.Parameters["@email"].Value = bezoeker.Email;
                    command.Parameters["@nummerplaat"].Value = bezoeker.Nummerplaat;
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    BezoekerException be = new BezoekerException("Bezoeker toevoegen is niet gelukt", e);
                    be.Data.Add("Bezoeker:", bezoeker);
                    throw be;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        public void VerwijderBezoeker(Bezoeker bezoeker)
        {
            string query1 = "DELETE FROM dbo.Bezoeker WHERE id=@id";
            SqlConnection conn1 = GetConnection();
            using (SqlCommand command = new SqlCommand(query1, conn1))
            {
                try
                {
                    conn1.Open();
                    command.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int));
                    command.Parameters["@Id"].Value = bezoeker.BezoekerId;
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    BezoekerException be = new BezoekerException("Bezoeker verwijderen is niet gelukt", e);
                    be.Data.Add("Bezoeker:", bezoeker);
                    throw be;
                }
                finally
                {
                    conn1.Close();
                }
            }
        }

    }
}


