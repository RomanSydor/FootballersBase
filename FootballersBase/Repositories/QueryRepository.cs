using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace FootballersBase.Repositories
{
    public class QueryRepository : IQueryRepository
    {

        public SqlConnection CreateConnection()
        {
            string connectionString = "Server=(LocalDB)\\MSSQLLocalDB;Database=FootballersDb;Trusted_Connection=True;MultipleActiveResultSets=true";
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }
    }
}
