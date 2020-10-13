using System;
using System.Data.SqlClient;

namespace FootballersBase.Repositories
{
    public class QueryWithIndexRepository : IQueryRepository
    {
        public SqlConnection CreateConnection()
        {
            string connectionString = "Server=(LocalDB)\\MSSQLLocalDB;Database=FootballersIndexedDb;Trusted_Connection=True;MultipleActiveResultSets=true";
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }
    }
}
