using FootballersBase.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FootballersBase.Controllers
{
    public class ClubsController : Controller
    {
        private FootballersDbRepository _defaultDbRepository;
        private FootballersDbRepository _indexedDbRepository;

        public ClubsController()
        {
            _defaultDbRepository = new DefaultFootballersRepository();
            _indexedDbRepository = new IndexedFootballersRepository();
            _defaultDbRepository.CreateConnection();
            _indexedDbRepository.CreateConnection();
        }

        public ActionResult InputIntoTable()
        {
            var rnd = new Random();

            for (int i = 1; i <= 1000; i++)
            {
                _defaultDbRepository.Query("Insert into Clubs (Name, Country, Town, CoachId)" +
                    $"\nValues ('Name{i}', 'Country{i}', 'Town{i}', null);");
            }

            for (int i = 1; i <= 1000; i++)
            {
                _indexedDbRepository.Query("Insert into Clubs (Name, Country, Town, CoachId)" +
                    $"\nValues ('Name{i}', 'Country{i}', 'Town{i}', null);");
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult InputForeignKeys()
        {
            var rnd = new Random();

            for (int i = 1; i <= 1000; i++)
            {
                _defaultDbRepository.Query("Update Clubs" +
                    $"\nset CoachId = {rnd.Next(1, 1001)}" +
                    $"\nwhere Id = {i};");
            }

            for (int i = 1; i <= 1000; i++)
            {
                _indexedDbRepository.Query("Update Clubs" +
                    $"\nset CoachId = {rnd.Next(1, 1001)}" +
                    $"\nwhere Id = {i};");
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
