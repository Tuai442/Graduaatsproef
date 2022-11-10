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
using System.Globalization;
using System.Data.SqlTypes;
using System.Reflection.PortableExecutable;

namespace Persistence.Datalaag
{
    public class AfspraakRepository : BaseRepository,  IAfspraakRepository
    {


        public AfspraakRepository()
        {
        }
        private SqlConnection GetConnection()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }
        public void VoegAfspraakToe(Afspraak afspraak)
        {

            string query = "INSERT INTO dbo.Afspraak (startTijd, eindTijd, bezoeker_voornaam, bezoeker_achternaam, bezoeker_email, " +
                "werknemer_voornaam, werknemer_achternaam, werknemer_email, bedrijf) " +
                "VALUES(@startTijd, @eindTijd, @bezoeker_voornaam, @bezoeker_achternaam, @bezoeker_email, " +
                "@werknemer_voornaam, @werknemer_achternaam, @werknemer_email, @bedrijf)";
            SqlConnection conn = GetConnection();
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                try
                {
                    conn.Open();
                    command.Parameters.Add(new SqlParameter("@startTijd", SqlDbType.DateTime));
                    command.Parameters.Add(new SqlParameter("@eindTijd", SqlDbType.DateTime));
                    command.Parameters.Add(new SqlParameter("@bezoeker_voornaam", SqlDbType.VarChar));
                    command.Parameters.Add(new SqlParameter("@bezoeker_achternaam", SqlDbType.VarChar));
                    command.Parameters.Add(new SqlParameter("@bezoeker_email", SqlDbType.VarChar));
                    command.Parameters.Add(new SqlParameter("@werknemer_voornaam", SqlDbType.VarChar));
                    command.Parameters.Add(new SqlParameter("@werknemer_achternaam", SqlDbType.VarChar));
                    command.Parameters.Add(new SqlParameter("@werknemer_email", SqlDbType.VarChar));
                    command.Parameters.Add(new SqlParameter("@bedrijf", SqlDbType.VarChar));

                    command.Parameters["@startTijd"].Value = afspraak.StartTijd;
                    if(afspraak.EindTijd == null)
                    {
                        command.Parameters["@eindTijd"].Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters["@eindTijd"].Value = afspraak.EindTijd; // TODO: moet mogelijk zijn om null in te steken

                    }
                    command.Parameters["@bezoeker_voornaam"].Value = afspraak.BezoekerVoornaam;
                    command.Parameters["@bezoeker_achternaam"].Value = afspraak.BezoekerAchternaam;
                    command.Parameters["@bezoeker_email"].Value = afspraak.BezoekerEmail;
                    command.Parameters["@werknemer_voornaam"].Value = afspraak.WerknemerVoornaam;
                    command.Parameters["@werknemer_achternaam"].Value = afspraak.WerknemerAchternaam;
                    command.Parameters["@werknemer_email"].Value = afspraak.WerknemerEmail;
                    command.Parameters["@bedrijf"].Value = afspraak.Bedrijf;
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    AfspraakException ae = new AfspraakException("Afspraak toevoegen is niet gelukt", e);
                    ae.Data.Add("Afspraak:", afspraak);
                    throw ae;
                }
                finally
                {
                    conn.Close();
                }
            }

        }
        
        public List<Afspraak> GeefAlleAfspraken()
        {
            string query = "SELECT * from dbo.Afspraak;";
            SqlConnection conn = GetConnection();
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                try
                {
                    List<Afspraak> afspraken = new List<Afspraak>();
                    conn.Open();
                    IDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        int afspraakId = (int)dataReader["afspraakId"];
                        string bVoornaam = (string)dataReader["bezoeker_voornaam"];
                        string bAchternaam = (string)dataReader["bezoeker_achternaam"];
                        string bEmail = (string)dataReader["bezoeker_email"];
                        string wVoornaam = (string)dataReader["werknemer_voornaam"];
                        string wAchternaam = (string)dataReader["werknemer_achternaam"];
                        string wEmail = (string)dataReader["werknemer_email"];
                        string bedrijf = (string)dataReader["bedrijf"];


                        DateTime startTijd = (DateTime)dataReader["startTijd"];
                        DateTime? eindTijd = GeefDateTime(dataReader["eindTijd"]);
                        Afspraak afspraak = new Afspraak(afspraakId, bVoornaam, bAchternaam, bEmail, wVoornaam, wAchternaam, wEmail, bedrijf,
                            startTijd, eindTijd);

                        afspraken.Add(afspraak);
                    }
                    dataReader.Close();
                    foreach (Afspraak afspraak in afspraken)
                    {
                        Console.WriteLine(afspraak);
                    }
                    return afspraken;
                }
                catch (Exception ex)
                {
                    throw new AfspraakException("Geef afspraken is niet gelukt.", ex);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        public void UpdateAfspraak(Afspraak afspraak)
        {
            string query = "update dbo.Afspraak set eindTijd=@eindtijd where afspraakId=@afspraakId";
            SqlConnection conn = GetConnection();
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                try
                {
                    conn.Open();
                    command.Parameters.Add(new SqlParameter("@afspraakId", SqlDbType.Int));
                    command.Parameters.Add(new SqlParameter("@eindtijd", SqlDbType.DateTime));
                    command.Parameters["@afspraakId"].Value = afspraak.Id;
                    command.Parameters["@eindtijd"].Value = afspraak.EindTijd;
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    AfspraakException ae = new AfspraakException("Update is niet gelukt", e);
                    ae.Data.Add("Afspraak", afspraak);
                    throw ae;
                }
                finally
                {
                    conn.Close();
                }

            }
        }

        //TODO: methode uitwerken
        public List<Afspraak> ZoekAfspraakOp(string zoekText)
        {
            return null;
        }

        public Afspraak GeefAfspraakOpBezoekerId(int id)
        {
            //string query = "SELECT * from dbo.Afspraak where bezoekerId=@id";
            //SqlConnection conn = GetConnection();
            //Afspraak afspraak = null;

            //using (SqlCommand command = new SqlCommand(query, conn))
            //{
            //    try
            //    {
            //        conn.Open();
            //        command.Parameters.AddWithValue("@id", id);
            //        IDataReader dataReader = command.ExecuteReader();

            //        if (dataReader.Read())
            //        {
            //            int bezoekerId = (int)dataReader["bezoekerId"];
            //            Bezoeker bezoeker = GeefBezoekerOpId(bezoekerId);
            //            int werknemerId = (int)dataReader["werknemerId"];
            //            Werknemer werknemer = GeefWerknemerOpId(werknemerId);
            //            DateTime startTijd = (DateTime)dataReader["startTijd"];
            //            DateTime? eindTijd = GeefDateTime(dataReader["eindTijd"]); ;
            //            afspraak = new Afspraak(bezoeker, werknemer, startTijd, eindTijd);
            //        }


            //        dataReader.Close();
            //        return afspraak;
            //    }
            //    catch (Exception e)
            //    {
            //        throw new AfspraakException("Geef afspraak is niet gelukt", e);
            //    }
            //    finally
            //    {
            //        conn.Close();
            //    }
            //    return null;
            //}
            return null;
        }

        public static DateTime? GeefDateTime(object obj)
        {
            if (obj == null || obj == DBNull.Value)
            {
                return null; 
            }
            else
            {
                return (DateTime)obj;
            }
        }

        public Afspraak GeefAfspraakOpBezoekerEmail(string email)
        {
            string query = $"SELECT * from dbo.Afspraak where bezoeker_email='{email}' and eindTijd is null; ";
            SqlConnection conn = GetConnection();
            Afspraak afspraak = null;

            using (SqlCommand command = new SqlCommand(query, conn))
            {
                try
                {
                    conn.Open();
                    IDataReader dataReader = command.ExecuteReader();

                    if (dataReader.Read())
                    {
                        int afspraakId = (int)dataReader["afspraakId"];
                        string bVoornaam = (string)dataReader["bezoeker_voornaam"];
                        string bAchternaam = (string)dataReader["bezoeker_achternaam"];
                        string bEmail = (string)dataReader["bezoeker_email"];
                        string wVoornaam = (string)dataReader["werknemer_voornaam"];
                        string wAchternaam = (string)dataReader["werknemer_achternaam"];
                        string wEmail = (string)dataReader["werknemer_email"];
                        string bedrijf = (string)dataReader["bedrijf"];


                        DateTime startTijd = (DateTime)dataReader["startTijd"];
                        DateTime? eindTijd = GeefDateTime(dataReader["eindTijd"]);
                        afspraak = new Afspraak(afspraakId, bVoornaam, bAchternaam, bEmail, wVoornaam, wAchternaam, wEmail, bedrijf,
                            startTijd, eindTijd);
                    }


                    dataReader.Close();
                    return afspraak;
                }
                catch (Exception e)
                {
                    throw new AfspraakException("Geef afspraak is niet gelukt", e);
                }
                finally
                {
                    conn.Close();
                }
                return null;
            }
        }

        public int GeefAfspraakOpDatum(DateTime datum)
        {
            throw new NotImplementedException();
        }

        public Afspraak GeefAfspraakOpEmail(string email)
        {
            throw new NotImplementedException();
        }

        public List<Afspraak> GeefAlleAanwezigeAfspraken()
        {
            throw new NotImplementedException();
        }
    }
}