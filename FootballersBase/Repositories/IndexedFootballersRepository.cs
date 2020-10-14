﻿using System.Data.SqlClient;

namespace FootballersBase.Repositories
{
    public class IndexedFootballersRepository : FootballersDbRepository
    {
        private string _connectionString = "Server=(LocalDB)\\MSSQLLocalDB;Database=FootballersIndexedDb;" +
            "Trusted_Connection=True;MultipleActiveResultSets=true";

        public override void CreateConnection()
        {
            var connection = new SqlConnection(_connectionString);
            _connection = connection;
        }
    }
}
