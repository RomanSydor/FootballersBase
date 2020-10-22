using FootballersBase.Contexts;
using FootballersBase.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace FootballersBase.Controllers
{
    public class ClubsController : Controller
    {
        private FootballersDbRepository _defaultDbRepository;
        private FootballersDbRepository _indexedDbRepository;
        private DataContext _dataContext;
        private DataContextIndexedDb _dataContextIndexedDb;

        private string _alphabeth = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public ClubsController(DataContext dataContext , DataContextIndexedDb indexedDb)
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
                var name = "";
                for (int n = 0; n < 15; n++)
                {
                    name += _alphabeth[rnd.Next(0, _alphabeth.Length)];
                }
                var country = "";
                for (int c = 0; c < 11; c++)
                {
                    country += _alphabeth[rnd.Next(0, _alphabeth.Length)];
                }
                var town = "";
                for (int t = 0; t < 11; t++)
                {
                    town += _alphabeth[rnd.Next(0, _alphabeth.Length)];
                }

                _defaultDbRepository.Query("Insert into Clubs (Name, Country, Town, CoachId)" +
                    $"\nValues ('{name}', '{country}', '{town}', null);");
                _indexedDbRepository.Query("Insert into Clubs (Name, Country, Town, CoachId)" +
                    $"\nValues ('{name}', '{country}', '{town}', null);");
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult InputForeignKeys()
        {
            var rnd = new Random();

            var firstClubsIdDefault = _dataContext.Clubs.Select(x => x.Id).First();
            var lastClubsIdDefault = _dataContext.Clubs.Select(x => x.Id).Last();
            var firstCoachesIdDefault = _dataContext.Coaches.Select(x => x.Id).First();
            var lastCoachesIdDefault = _dataContext.Coaches.Select(x => x.Id).Last();

            for (int i = firstClubsIdDefault; i <= lastClubsIdDefault; i++)
            {
                _defaultDbRepository.Query("Update Clubs" +
                    $"\nset CoachId = {rnd.Next(firstCoachesIdDefault, lastCoachesIdDefault + 1)}" +
                    $"\nwhere Id = {i};");
            }

            var firstClubsIdIndexed = _dataContextIndexedDb.ClubsIndexedDb.Select(x => x.Id).First();
            var lastClubsIdIndexed = _dataContextIndexedDb.ClubsIndexedDb.Select(x => x.Id).Last();
            var firstCoachesIdIndexed = _dataContextIndexedDb.CoachesIndexedDb.Select(x => x.Id).First();
            var lastCoachesIdIndexed = _dataContextIndexedDb.CoachesIndexedDb.Select(x => x.Id).Last();

            for (int i = firstClubsIdIndexed; i <= lastClubsIdIndexed; i++)
            {
                _indexedDbRepository.Query("Update Clubs" +
                    $"\nset CoachId = {rnd.Next(firstCoachesIdIndexed, lastCoachesIdIndexed + 1)}" + 
                    $"\nwhere Id = {i};");
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
