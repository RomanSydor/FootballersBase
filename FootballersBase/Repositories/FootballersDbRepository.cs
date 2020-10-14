using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace FootballersBase.Repositories
{
    public abstract class FootballersDbRepository
    {
        protected SqlConnection _connection;

        public abstract void CreateConnection();

        public QueryResponse Query(string sqlQuery)
        {
            var responce = new QueryResponse();
            //responce.TableHeader = new List<List<string>>();
            //responce.TableBody = new List<List<string>>();

            _connection.Open();
            var command = new SqlCommand(sqlQuery, _connection);

            SqlDataReader reader = command.ExecuteReader();

            int fieldCount = reader.FieldCount;
            object[] fields = new object[fieldCount];

            List<string> rowsHeader = new List<string>();
            for (int i = 0; i < fieldCount; i++)
            {
                rowsHeader.Add(reader.GetName(i));
            }
            responce.TableHeader.Add(rowsHeader);

            List<string> rowsBody = new List<string>();
            while (reader.Read())
            {
                for (int i = 0; i < fieldCount; i++)
                {
                    fields[i] = reader[i];
                    rowsBody.Add(Convert.ToString(fields[i]));
                }
                responce.TableBody.Add(rowsBody);
                rowsBody = new List<string>();
            }

            reader.Close();
            _connection.Close();

            return responce;
        }
    }
}
