using FootballersBase.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FootballersBase.Controllers
{
    public class CoachesController : Controller
    {
        private FootballersDbRepository _defaultDbRepository;
        private FootballersDbRepository _indexedDbRepository;

        public CoachesController()
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
                _defaultDbRepository.Query("Insert into Coaches (FirstName, LastName, Country, ClubId, NationalTeamId)" +
                    $"\nValues ('FirstName{i}', 'LastName{i}', 'Country', null, null);");
            }

            for (int i = 1; i <= 1000; i++)
            {
                _indexedDbRepository.Query("Insert into Coaches (FirstName, LastName, Country, ClubId, NationalTeamId)" +
                    $"\nValues ('FirstName{i}', 'LastName{i}', 'Country', null, null);");
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult InputForeignKeys()
        {
            var rnd = new Random();

            for (int i = 1; i <= 1000; i++)
            {
                _defaultDbRepository.Query("Update Coaches" +
                    $"\nset ClubId = {rnd.Next(1, 1001)}, NationalTeamId = {rnd.Next(1, 101)}" +
                    $"\nwhere Id = {i};");
            }

            for (int i = 1; i <= 1000; i++)
            {
                _indexedDbRepository.Query("Update Coaches" +
                    $"\nset ClubId = {rnd.Next(1, 1001)}, NationalTeamId = {rnd.Next(1, 101)}" +
                    $"\nwhere Id = {i};");
            }

            return RedirectToAction("Index", "Home");
        }
    }
}