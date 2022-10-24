using Controller.Interfaces;
using Controller.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controller;
using Controller.Interfaces.Models;
using Persistence.Exceptions;

namespace Persistence.Datalaag
{
    public class AfspraakRepository: BaseRepository, IAfspraakRepository
    {
      
        private string _tableName = "Afspraken";
        public AfspraakRepository()
        {
            //SlaDummyDataOp();
        }
        private SqlConnection GetConnection()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }
        public void VoegAfspraakToe(Afspraak afspraak)
        {
            string query = $"INSERT INTO {_tableName} (Email, VoornaamBezoekern, AchternaamBezoekern, " +
                $"VoornaamContactPersoon, AchternaamContactPersoon, Bedrijf, StartTijd, EindTijd) " +
                $"VALUES(@Email, @VoornaamBezoekern, @AchternaamBezoekern, " +
                $"@VoornaamWerknemer, @AchternaamWerknemer, @Bedrijf, @StartTijd, @EindTijd)";
            SqlConnection conn = GetConnection();
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                try
                {
                    conn.Open();

                    command.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar));
                    command.Parameters["@Email"].Value = afspraak.Email;

                    command.Parameters.Add(new SqlParameter("@VoornaamBezoeker", SqlDbType.NVarChar));
                    command.Parameters["@VoornaamBezoeker"].Value = afspraak.VoornaamBezoeker;

                    command.Parameters.Add(new SqlParameter("@AchternaamBezoeker", SqlDbType.NVarChar));
                    command.Parameters["@AchternaamBezoeker"].Value = afspraak.AchternaamBezoeker;

                    command.Parameters.Add(new SqlParameter("@VoornaamContactPersoon", SqlDbType.NVarChar));
                    command.Parameters["@VoornaamContactPersoon"].Value = afspraak.VoornaamContactPersoon;

                    command.Parameters.Add(new SqlParameter("@AchternaamContactPersoon", SqlDbType.NVarChar));
                    command.Parameters["@AchternaamContactPersoon"].Value = afspraak.VoornaamContactPersoon;

                    command.Parameters.Add(new SqlParameter("@Bedrijf", SqlDbType.NVarChar));
                    command.Parameters["@Bedrijf"].Value = afspraak.Bedrijf;

                    command.Parameters.Add(new SqlParameter("@StartTijd", SqlDbType.DateTime));
                    command.Parameters["@StartTijd"].Value = afspraak.StartTijd;

                    command.Parameters.Add(new SqlParameter("@EindTijd", SqlDbType.DateTime));
                    command.Parameters["@EindTijd"].Value = afspraak.EindTijd;


                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    
                    throw new AfspraakException("Kan afspraak niet toevoegen.");
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        public void VerwijderBezoeker(Bezoeker bezoeker)
        {
            
        }

        public int GeefAfspraakOpDatum(DateTime datum)
        {
            throw new NotImplementedException();
        }

        public List<Afspraak> GeefAlleAfspraken()
        {
            SqlConnection conn = GetConnection();
            List<Afspraak> afspraken = new List<Afspraak>();
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
                        int id = (int)dataReader["AfspraakId"];
                        string email = (string)dataReader["Email"];
                        string voornaamB = (string)dataReader["VoornaamBezoeker"];
                        string achternaamB = (string)dataReader["AchternaamBezoeker"];
                        DateTime startTijd = (DateTime)dataReader["StartTijd"];
                        DateTime eindTijd = (DateTime)dataReader["EindTijd"];
                        int bedrijfId = (int)dataReader["BedrijfId"];
                        int werknemerId = (int)dataReader["werknemerId"];

                        Bedrijf bedrijf = GeefBedrijfOpId(bedrijfId);
                        Werknemer werknemer = GeefWerknemerOpId(werknemerId);
                        Afspraak afspraak = new Afspraak(id, email, voornaamB, achternaamB,
                            werknemer.Voornaam, werknemer.Achternaam, bedrijf.Naam, startTijd, eindTijd);
                        afspraken.Add(afspraak);
                    }


                }
            }
            catch (Exception e)
            {
                throw new AfspraakException(e.Message);
            }
            finally
            {
                conn.Close();
            }
            return afspraken;

        }

        public void UpdateAfspraak(Afspraak afspraak)
        {
            throw new NotImplementedException();
        }

        public List<Afspraak> ZoekAfspraakOp(string zoekText)
        {
            SqlConnection conn = GetConnection();
            List<Afspraak> afspraken = new List<Afspraak>();
            try
            {
                conn.Open();

                string query = $"SELECT * FROM {_tableName} WHERE column LIKE '{zoekText}%';";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader dataReader = cmd.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        int id = (int)dataReader["AfspraakId"];
                        string email = (string)dataReader["Email"];
                        string voornaamB = (string)dataReader["VoornaamBezoeker"];
                        string achternaamB = (string)dataReader["AchternaamBezoeker"];
                        string bedrijf = (string)dataReader["Bedrijf"];
                        string voornaamCp = (string)dataReader["VoornaamContactPersoon"];
                        string achternaamCp = (string)dataReader["AchternaamContactPersoon"];
                        DateTime startTijd = (DateTime)dataReader["StartTijd"];
                        DateTime eindTijd = (DateTime)dataReader["EindTijd"];

                        Afspraak afspraak = new Afspraak(id, email, voornaamB, achternaamB, bedrijf,
                            voornaamCp, achternaamCp, startTijd, eindTijd);
                        afspraken.Add(afspraak);
                    }


                }
            }
            catch (Exception e)
            {
                throw new AfspraakException("Kan afspraak niet toevoegen.");
            }
            finally
            {
                conn.Close();
            }
            return afspraken;
        }

        public Afspraak GeefAfspraakOpEmail(string emailGezocht)
        {
            SqlConnection conn = GetConnection();
            Afspraak afspraak = null;
            try
            {
                conn.Open();

                string query = $"SELECT * FROM {_tableName} WHERE Email = '{emailGezocht}';";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader dataReader = cmd.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        int id = (int)dataReader["AfspraakId"];
                        string email = (string)dataReader["Email"];
                        string voornaamB = (string)dataReader["VoornaamBezoeker"];
                        string achternaamB = (string)dataReader["AchternaamBezoeker"];
                        string bedrijf = (string)dataReader["Bedrijf"];
                        string voornaamCp = (string)dataReader["VoornaamContactPersoon"];
                        string achternaamCp = (string)dataReader["AchternaamContactPersoon"];
                        DateTime startTijd = (DateTime)dataReader["StartTijd"];
                        DateTime eindTijd = (DateTime)dataReader["EindTijd"];

                        afspraak = new Afspraak(id, email, voornaamB, achternaamB, bedrijf,
                            voornaamCp, achternaamCp, startTijd, eindTijd);
                        
                    }


                }
            }
            catch (Exception e)
            {
                throw new AfspraakException("Kan afspraak niet toevoegen.");
            }
            finally
            {
                conn.Close();
            }
            
            return afspraak;
        }

       
    }
}
