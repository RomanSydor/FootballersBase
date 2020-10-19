using FootballersBase.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FootballersBase.Controllers
{
    public class NationalTeamsController : Controller
    {
        private FootballersDbRepository _defaultDbRepository;
        private FootballersDbRepository _indexedDbRepository;

        public NationalTeamsController()
        {
            _defaultDbRepository = new DefaultFootballersRepository();
            _indexedDbRepository = new IndexedFootballersRepository();
            _defaultDbRepository.CreateConnection();
            _indexedDbRepository.CreateConnection();
        }

        public ActionResult InputIntoTable()
        {
            var rnd = new Random();

            for (int i = 1; i <= 100; i++)
            {
                _defaultDbRepository.Query("Insert into NationalTeams (Country, CoachId)" +
                    $"\nValues ('Country{i}', null);");
            }

            for (int i = 1; i <= 100; i++)
            {
                _indexedDbRepository.Query("Insert into NationalTeams (Country, CoachId)" +
                    $"\nValues ('Country{i}', null);");
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult InputForeignKeys()
        {
            var rnd = new Random();

            for (int i = 1; i <= 100; i++)
            {
                _defaultDbRepository.Query("Update NationalTeams" +
                    $"\nset CoachId = {rnd.Next(1, 1001)}" +
                    $"\nwhere Id = {i};");
            }

            for (int i = 1; i <= 100; i++)
            {
                _indexedDbRepository.Query("Update NationalTeams" +
                    $"\nset CoachId = {rnd.Next(1, 1001)}" +
                    $"\nwhere Id = {i};");
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
