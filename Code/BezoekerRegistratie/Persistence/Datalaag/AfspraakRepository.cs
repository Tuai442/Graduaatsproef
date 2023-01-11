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
using Persistence.Exceptions;
using System.Globalization;
using System.Data.SqlTypes;
using System.Reflection.PortableExecutable;
using System.Transactions;
using System.Collections;

namespace Persistence.Datalaag
{
    public class AfspraakRepository : BaseRepository, IAfspraakRepository
    {
        BezoekerRepository bezoekerRepo;
        WerknemerRepository werknemerRepo;
        public AfspraakRepository()
        {
            bezoekerRepo = new BezoekerRepository();
            werknemerRepo = new WerknemerRepository();
        }
        private SqlConnection GetConnection()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }
        public void VoegAfspraakToe(Afspraak afspraak)
        {

            string bezoekerQuery = "UPDATE Bezoeker SET aanwezig=@aanwezig " +
                "where bezoekerId=@id; ";

            string afspraakQuery = "INSERT INTO dbo.Afspraak (startTijd,eindTijd,werknemerId,bezoekerId, actief) " +
                "VALUES(@startTijd,@eindTijd,@werknemerId,@bezoekerId, 1)";

            //SqlConnection conn = GetConnection();
            SqlTransaction trans = null;
            using (SqlConnection conn = GetConnection())
            {
                try
                {
                    conn.Open();
                    trans = conn.BeginTransaction();

                    SqlCommand afspraakCmd = new SqlCommand(afspraakQuery, conn, trans);
                    afspraakCmd.Parameters.Add(new SqlParameter("@startTijd", SqlDbType.DateTime));
                    afspraakCmd.Parameters.Add(new SqlParameter("@eindTijd", SqlDbType.DateTime));
                    afspraakCmd.Parameters.Add(new SqlParameter("@werknemerId", SqlDbType.Int));
                    afspraakCmd.Parameters.Add(new SqlParameter("@bezoekerId", SqlDbType.Int));

                    afspraakCmd.Parameters["@startTijd"].Value = afspraak.StartTijd;
                    if (afspraak.EindTijd == null)
                    {
                        afspraakCmd.Parameters["@eindTijd"].Value = DBNull.Value;
                    }
                    else
                    {
                        afspraakCmd.Parameters["@eindTijd"].Value = afspraak.EindTijd;

                    }
                    afspraakCmd.Parameters["@werknemerId"].Value = afspraak.Werknemer.Id;
                    afspraakCmd.Parameters["@bezoekerId"].Value = afspraak.Bezoeker.Id;
                    afspraakCmd.ExecuteNonQuery();

                    // Bezoeker Updaten
                    SqlCommand bezoekerCmd = new SqlCommand(bezoekerQuery, conn, trans);
                    bezoekerCmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                    bezoekerCmd.Parameters.Add(new SqlParameter("@aanwezig", SqlDbType.Bit));


                    bezoekerCmd.Parameters["@id"].Value = afspraak.Bezoeker.Id;
                    bezoekerCmd.Parameters["@aanwezig"].Value = afspraak.Bezoeker.Aanwezig;
                    bezoekerCmd.ExecuteNonQuery();

                    trans.Commit();
                }
                catch (Exception e)
                {
                    trans.Rollback();
                    AfspraakRepoException ae = new AfspraakRepoException("Afspraak toevoegen is niet gelukt", e);
                    ae.Data.Add("Afspraak:", afspraak);
                    throw ae;
                }
                finally
                {
                    conn.Close();
                }
            }

        }
        //TODO: uitwerken met actief = 0, niet verwijderen
        public void ZetOpNonActief(int id)
        {
            string query = "update Afspraak set actief = 0 where afspraakId = @id";

            SqlConnection conn = GetConnection();
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                try
                {
                    conn.Open();
                    command.CommandText = query;
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    BezoekerRepoException be = new BezoekerRepoException("AfspraakRepo - Afspraak op non-actief zetten is niet gelukt", e);
                    throw be;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        public List<Afspraak> GeefAlleAfspraken()
        {
            string query = "SELECT afspraakId, startTijd, eindTijd, bezoekerId, werknemerId from dbo.Afspraak where actief = 1 order by startTijd;";
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
                        int bezoekerId = (int)dataReader["bezoekerId"];
                        Bezoeker bezoeker = GeefBezoekerOpId(bezoekerId);
                        int werknemerId = (int)dataReader["werknemerId"];
                        Werknemer werknemer = GeefWerknemerOpId(werknemerId);
                        DateTime startTijd = (DateTime)dataReader["startTijd"];
                        DateTime? eindTijd = GeefDateTime(dataReader["eindTijd"]);
                        Afspraak afspraak = new Afspraak(afspraakId, bezoeker, werknemer, startTijd, eindTijd);

                        afspraken.Add(afspraak);
                    }
                    dataReader.Close();

                    return afspraken;
                }
                catch (Exception ex)
                {
                    throw new AfspraakRepoException("Afspraken geven is niet gelukt.", ex);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        //TODO: moet update niet nieuw element aanmaken
        public void UpdateAfspraak(Afspraak afspraak)
        {
            SqlConnection conn = GetConnection();

            string queryNonActief =
                "update Afspraak set actief = 0 where afspraakId = @id";

            //string bezoekerQuery =
            //    "UPDATE Bezoeker SET aanwezig=@aanwezig where bezoekerId=@bezoekerId;";

            string WerknemerNonActiefQuery =
                "update Werknemer set actief = 0 where werknemerId = @werknemerId";

            string nieuweWerknemerQuery =
                "insert into werknemer (voornaam, achternaam, bedrijfId, email, functie) " +
                "output INSERTED.werknemerId values (@voornaam, @achternaam, @bedrijfId, @email, @functie);";

            string AfspraakQuery =
                "INSERT INTO dbo.Afspraak (startTijd,eindTijd,werknemerId,bezoekerId, actief) VALUES(@startTijd,@eindTijd,@werknemerId,@bezoekerId, 1)";

            SqlTransaction trans = null;
            using (SqlCommand cmd = conn.CreateCommand())
            using (SqlCommand cmd2 = conn.CreateCommand())
            using (SqlCommand cmd3 = conn.CreateCommand())
            using (SqlCommand cmd4 = conn.CreateCommand())
            {
                try
                {
                    conn.Open();
                    trans = conn.BeginTransaction();

                    //trans 1 - afspraak non-actief
                    cmd.Transaction = trans;
                    cmd.CommandText = queryNonActief;
                    cmd.Parameters.AddWithValue("@id", afspraak.Id);
                    cmd.ExecuteNonQuery();


                    //trans 2 - werknemer non-actief
                    cmd2.Transaction = trans;
                    cmd2.CommandText = WerknemerNonActiefQuery;

                    cmd2.Parameters.AddWithValue("@werknemerId", afspraak.Werknemer.Id);

                    cmd2.ExecuteNonQuery();

                    //trans 3 - nieuwe werknemer
                    cmd3.Transaction = trans;
                    cmd3.CommandText = nieuweWerknemerQuery;

                    cmd3.Parameters.AddWithValue("@voornaam", afspraak.Werknemer.Voornaam);
                    cmd3.Parameters.AddWithValue("@achternaam", afspraak.Werknemer.Achternaam);
                    cmd3.Parameters.AddWithValue("@bedrijfId", afspraak.Werknemer.Bedrijf.Id);
                    cmd3.Parameters.AddWithValue("@email", afspraak.Werknemer.Email);
                    cmd3.Parameters.AddWithValue("@functie", afspraak.Werknemer.Functie);

                    int werknemerId = (int)cmd3.ExecuteScalar();

                    //trans 4 - nieuwe afspraak
                    cmd4.Transaction = trans;
                    cmd4.CommandText = AfspraakQuery;

                    cmd4.Parameters.AddWithValue("@startTijd", afspraak.StartTijd);
                    cmd4.Parameters.AddWithValue("@werknemerId", werknemerId);
                    cmd4.Parameters.AddWithValue("@bezoekerId", afspraak.Bezoeker.Id);
                    if (afspraak.EindTijd == null)
                    {
                        cmd4.Parameters.AddWithValue("@eindTijd", DBNull.Value);
                    }
                    else
                    {
                        cmd4.Parameters.AddWithValue("@eindTijd", afspraak.EindTijd);
                    }

                    cmd4.ExecuteNonQuery();

                    //einde transacties
                    trans.Commit();
                }
                catch (Exception e)
                {
                    trans.Rollback();
                    throw  new AfspraakRepoException("Update is niet gelukt", e);
                }
                finally
                {
                    conn.Close();
                }

            }
        }
        public List<Afspraak> ZoekAfspraakOp(string zoekText)
        {
            {
                SqlConnection conn = GetConnection();
                List<Afspraak> afspraken = new List<Afspraak>();
                try
                {
                    conn.Open();
                    string query =
                        $"select f.*, bed.naam, " +
                        $"b.voornaam as 'bezVN', b.achternaam as 'bezAN',b.email, " +
                        $"w.voornaam as 'wnVN', w.achternaam as 'wnAN' " +

                        $"from Afspraak f " +
                        $"inner join Werknemer w on f.werknemerId = w.werknemerId " +
                        $"inner join Bezoeker b on f.bezoekerId = b.bezoekerId " +
                        $"inner join Bedrijf bed on w.bedrijfId = bed.bedrijfId " +

                        $"where actief = 1 and " +
                        
                        $"f.startTijd like '{zoekText}%' or " +
                        $"f.eindTijd like '{zoekText}%' or " +
                        $"bed.naam like '{zoekText}%' or " +
                        $"b.voornaam like '{zoekText}%' or " +
                        $"b.achternaam like '{zoekText}%' or " +
                        $"w.voornaam like '{zoekText}%' or " +
                        $"w.achternaam like '{zoekText}%';"; 

                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            int afspraakId = (int)dataReader["afspraakId"];
                            DateTime startTijd = (DateTime)dataReader["startTijd"];
                            DateTime eindTijd = (DateTime)dataReader["eindTijd"];
                            string bezoekerEmail = (string)dataReader["email"];
                            int werknemerId = (int)dataReader["werknemerId"];

                            if (afspraakId != null)
                            {
                                Bezoeker bezoeker = bezoekerRepo.GeefBezoekerOpEmail(bezoekerEmail);
                                Werknemer werknemer = werknemerRepo.GeefWerknemerOpId(werknemerId);
                                Afspraak afspraak = new Afspraak(afspraakId,bezoeker, werknemer, startTijd, eindTijd);
                                afspraken.Add(afspraak);
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    throw new AfspraakRepoException("Kan afspraak niet opzoeken", e);
                }
                finally
                {
                    conn.Close();
                }
                return afspraken;
            }
        }
        public Afspraak GeefAfspraakOpBezoekerId(int id)
        {
            string query = "SELECT * from dbo.Afspraak where actief = 1 and bezoekerId=@id";
            SqlConnection conn = GetConnection();
            Afspraak afspraak = null;

            using (SqlCommand command = new SqlCommand(query, conn))
            {
                try
                {
                    conn.Open();
                    command.Parameters.AddWithValue("@id", id);
                    IDataReader dataReader = command.ExecuteReader();

                    if (dataReader.Read())
                    {
                        int bezoekerId = (int)dataReader["bezoekerId"];
                        Bezoeker bezoeker = GeefBezoekerOpId(bezoekerId);
                        int werknemerId = (int)dataReader["werknemerId"];
                        Werknemer werknemer = GeefWerknemerOpId(werknemerId);
                        DateTime startTijd = (DateTime)dataReader["startTijd"];
                        DateTime? eindTijd = GeefDateTime(dataReader["eindTijd"]); ;
                        afspraak = new Afspraak(bezoeker, werknemer, startTijd, eindTijd);
                    }


                    dataReader.Close();
                    return afspraak;
                }
                catch (Exception e)
                {
                    throw new AfspraakRepoException("Geef afspraak is niet gelukt", e);
                }
                finally
                {
                    conn.Close();
                }
                return null;
            }
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
        public Afspraak GeefOpenstaandeAfspraakOpBezoekerEmail(string email)
        {
            string query = "SELECT a.*, b.*, bedrijf.*, w.*, " +
                "w.voornaam as w_voornaam, w.achternaam as w_achternaam, w.email as w_email, " +
                "b.email as b_email from dbo.Afspraak a " +
                "join bezoeker b on b.bezoekerId = a.bezoekerId " +
                "join werknemer w on w.werknemerId = a.werknemerId " +
                "join bedrijf bedrijf on bedrijf.bedrijfId = w.bedrijfId " +
                "where b.email=@email and a.eindTijd is null";
            SqlConnection conn = GetConnection();
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                try
                {
                    conn.Open();
                    command.Parameters.AddWithValue("@email", email);
                    IDataReader dataReader = command.ExecuteReader();
                    dataReader.Read();

                    // Bezoeker
                    int bezoekerId = (int)dataReader["bezoekerId"];
                    string vNaam = (string)dataReader["voornaam"];
                    string aNaam = (string)dataReader["achternaam"];
                    string emailB = (string)dataReader["b_email"];
                    string bedrijf = (string)dataReader["bedrijf"];
                    bool aanwezig = (bool)dataReader["aanwezig"];
                    Bezoeker bezoeker = new Bezoeker(bezoekerId, vNaam, aNaam, emailB, bedrijf, aanwezig);

                    // Bedrijf
                    int bedrijfId = (int)dataReader["bedrijfId"];
                    string naam = (string)dataReader["naam"];
                    string btw = (string)dataReader["btwNummer"];
                    string emailb = (string)dataReader["email"];
                    string adres = (string)dataReader["adres"];
                    string tel = (string)dataReader["telefoon"];
                    Bedrijf bedrijf1 = new Bedrijf(naam, btw, adres, tel, email);


                    // Werknemer
                    int werknemerId = (int)dataReader["werknemerId"];
                    string vNaamW = (string)dataReader["w_voornaam"];
                    string aNaamW = (string)dataReader["w_achternaam"];
                    string emailW = (string)dataReader["w_email"];
                    string functie = (string)dataReader["functie"];
                    Werknemer werknemer = new Werknemer(werknemerId, vNaamW, aNaamW, emailW, functie, bedrijf1);

                    DateTime startTijd = (DateTime)dataReader["startTijd"];
                    DateTime? eindTijd = null;
                    if (dataReader["eindTijd"] != DBNull.Value) // Controle of null is
                    {
                        eindTijd = (DateTime)dataReader["eindTijd"];
                    }
                    

                    Afspraak afspraak = new Afspraak((int)dataReader["afspraakId"],
                        bezoeker,
                        werknemer,
                        startTijd,
                        eindTijd);

                    dataReader.Close();
                    Console.WriteLine(afspraak);
                    return afspraak;
                }
                catch (Exception e)
                {
                    throw new BedrijfRepoException("Geef afspraak is niet gelukt", e);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        public List<Afspraak> GeefOpenstaandeAfspraak()
        {
            string query = "SELECT * from dbo.Afspraak where actief = 1 and eindTijd is null;";
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
                        int bezoekerId = (int)dataReader["bezoekerId"];
                        Bezoeker bezoeker = GeefBezoekerOpId(bezoekerId);
                        int werknemerId = (int)dataReader["werknemerId"];
                        Werknemer werknemer = GeefWerknemerOpId(werknemerId);
                        DateTime startTijd = (DateTime)dataReader["startTijd"];
                        DateTime? eindTijd = GeefDateTime(dataReader["eindTijd"]);
                        Afspraak afspraak = new Afspraak(bezoeker, werknemer, startTijd, eindTijd);

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
                    throw new AfspraakRepoException("Geef afspraken is niet gelukt.", ex);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }
}