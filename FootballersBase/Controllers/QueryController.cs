using FootballersBase.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace FootballersBase.Controllers
{
    public class QueryController : Controller
    {
        private static List<List<string>> TableHeader = new List<List<string>>();
        private static List<List<string>> TableBody = new List<List<string>>();

        private IQueryRepository _queryRepository;
        private IQueryRepository _queryWithIndexRepository;

        public QueryController(QueryRepository repo, QueryWithIndexRepository indexedRepo)
        {
            _queryRepository = repo;
            _queryWithIndexRepository = indexedRepo;
        }

        public ActionResult Query(string query, string db)
        {
            try
            {
                ViewBag.Header = null;
                ViewBag.Body = null;
                ViewBag.Error = null;
                TableHeader = new List<List<string>>();
                TableBody = new List<List<string>>();

                SqlConnection connection;

                if (db == "Default")
                {
                    connection = _queryRepository.CreateConnection();
                    connection.Open();
                }
                else if (db == "Indexed")
                {
                    connection = _queryRepository.CreateConnection();
                    connection.Open();
                }
                else
                {
                    connection = null;
                }
                
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                int fieldCount = reader.FieldCount;
                object[] fields = new object[fieldCount];

                List<string> rowsHeader = new List<string>();

                for (int i = 0; i < fieldCount; i++)
                {
                    rowsHeader.Add(reader.GetName(i));
                }
                TableHeader.Add(rowsHeader);

                ViewBag.Header = TableHeader;

                List<string> rowsBody = new List<string>();

                while (reader.Read())
                {
                    for (int i = 0; i < fieldCount; i++)
                    {
                        fields[i] = reader[i];
                        rowsBody.Add(Convert.ToString(fields[i]));
                    }
                    TableBody.Add(rowsBody);
                    rowsBody = new List<string>();
                }

                ViewBag.Body = TableBody;
                reader.Close();

                connection.Close();
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex;
            }

            return View();
        }
        
    }
}
