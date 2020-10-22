using FootballersBase.Contexts;
using FootballersBase.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace FootballersBase.Controllers
{
    public class NationalTeamsController : Controller
    {
        private FootballersDbRepository _defaultDbRepository;
        private FootballersDbRepository _indexedDbRepository;
        private DataContext _dataContext;
        private DataContextIndexedDb _dataContextIndexedDb;

        private string _alphabeth = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public NationalTeamsController(DataContext dataContext, DataContextIndexedDb indexedDb)
        {
            _defaultDbRepository = new DefaultFootballersRepository();
            _indexedDbRepository = new IndexedFootballersRepository();
            _defaultDbRepository.CreateConnection();
            _indexedDbRepository.CreateConnection();
            _dataContext = dataContext;
            _dataContextIndexedDb = indexedDb;
        }

        public ActionResult InputIntoTable()
        {
            var rnd = new Random();

            for (int i = 1; i <= 100; i++)
            {
                var country = "";
                for (int n = 0; n < 15; n++)
                {
                    country += _alphabeth[rnd.Next(0, _alphabeth.Length)];
                }

                _defaultDbRepository.Query("Insert into NationalTeams (Country, CoachId)" +
                    $"\nValues ('{country}', null);");
                _indexedDbRepository.Query("Insert into NationalTeams (Country, CoachId)" +
                    $"\nValues ('{country}', null);");
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult InputForeignKeys()
        {
            var rnd = new Random();

            var firstNationalTeamsIdDefault = _dataContext.NationalTeams.Select(x => x.Id).First();
            var lastNationalTeamsIdDefault = _dataContext.NationalTeams.Select(x => x.Id).Last();
            var firstCoachesIdDefault = _dataContext.Coaches.Select(x => x.Id).First();
            var lastCoachesIdDefault = _dataContext.Coaches.Select(x => x.Id).Last();

            for (int i = firstNationalTeamsIdDefault; i <= lastNationalTeamsIdDefault; i++)
            {
                _defaultDbRepository.Query("Update NationalTeams" +
                    $"\nset CoachId = {rnd.Next(firstCoachesIdDefault, firstCoachesIdDefault + 1)}" +
                    $"\nwhere Id = {i};");
            }

            var firstNationalTeamsIdIndexed = _dataContextIndexedDb.NationalTeamsIndexedDb.Select(x => x.Id).First();
            var lastNationalTeamsIdIndexed = _dataContextIndexedDb.NationalTeamsIndexedDb.Select(x => x.Id).Last();
            var firstCoachesIdIndexed = _dataContextIndexedDb.CoachesIndexedDb.Select(x => x.Id).First();
            var lastCoachesIdIndexed = _dataContextIndexedDb.CoachesIndexedDb.Select(x => x.Id).Last();

            for (int i = firstNationalTeamsIdIndexed; i <= lastNationalTeamsIdIndexed; i++) 
            {
                _indexedDbRepository.Query("Update NationalTeams" + 
                    $"\nset CoachId = {rnd.Next(firstCoachesIdIndexed, lastCoachesIdIndexed + 1)}" + 
                    $"\nwhere Id = {i};");
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
