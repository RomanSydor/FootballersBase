using FootballersBase.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FootballersBase.Controllers
{
    public class QueryController : Controller
    {

        private FootballersDbRepository _defaultDbRepository;
        private FootballersDbRepository _indexedDbRepository;

        public QueryController(DefaultFootballersRepository defaultRepo, IndexedFootballersRepository indexedRepo)
        {
            _defaultDbRepository = defaultRepo;
            _indexedDbRepository = indexedRepo;
        }

        public ActionResult QueryResult(string sqlQuery, string db)
        {
            try
            {
                ViewBag.Header = null;
                ViewBag.Body = null;
                ViewBag.Error = null;

                if (db == "Default")
                {
                    var resp = _defaultDbRepository.Query(sqlQuery);
                    ViewBag.Header = resp.TableHeader;
                    ViewBag.Body = resp.TableBody;
                }
                else if (db == "Indexed")
                {
                    var resp = _indexedDbRepository.Query(sqlQuery);
                    ViewBag.Header = resp.TableHeader;
                    ViewBag.Body = resp.TableBody;
                }
                else
                {
                    ViewBag.Error = "Query is empty.";
                }

            }
            catch (Exception ex)
            {
                ViewBag.Error = ex;
            }

            return View();
        }
        
    }
}
