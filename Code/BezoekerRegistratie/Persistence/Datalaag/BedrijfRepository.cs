using System;
using System.Collections.Generic;
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
    }
}
