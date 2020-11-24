﻿using System.Data.SqlClient;

namespace FootballersBase.Repositories
{
    public class DefaultFootballersRepository : FootballersDbRepository
    {
        private string _connectionString = "Server=DESKTOP-VUEJ976;Database=FootballersDb;Trusted_Connection=True;" +
            "MultipleActiveResultSets=true";

        public override void CreateConnection()
        {
            var connection = new SqlConnection(_connectionString);
            _connection = connection;
        }
    }
}
