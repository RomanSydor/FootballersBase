using FootballersBase.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;

namespace FootballersBase.Controllers
{
    public class QueryController : Controller
    {

        private FootballersDbRepository _defaultDbRepository;
        private FootballersDbRepository _indexedDbRepository;

        public QueryController()
        {
            _defaultDbRepository = new DefaultFootballersRepository();
            _indexedDbRepository = new IndexedFootballersRepository();
            _defaultDbRepository.CreateConnection();
            _indexedDbRepository.CreateConnection();
        }

        [Route("/Query/Result/{db}")]
        public ActionResult Result(string sqlQuery, [FromRoute]string db) 
        {
            var sw = new Stopwatch();
            try
            {
                ViewBag.Header = null;
                ViewBag.Body = null;
                ViewBag.Error = null;
                ViewBag.Time = null;

                if (db == "Default")
                {
                    sw.Start();
                    var resp = _defaultDbRepository.Query(sqlQuery);
                    sw.Stop();
                    var time = sw.Elapsed;

                    ViewBag.Time = String.Format("{0:00}m {1:00}s {2:00}ms",
                       time.Minutes, time.Seconds,time.Milliseconds);

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
                    ViewBag.Error = "Database wasn't chosen";
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
