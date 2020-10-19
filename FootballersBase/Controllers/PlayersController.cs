using FootballersBase.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FootballersBase.Controllers
{
    public class PlayersController : Controller
    {

        private FootballersDbRepository _defaultDbRepository;
        private FootballersDbRepository _indexedDbRepository;

        public PlayersController()
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
                _defaultDbRepository.Query("Insert into Players (FirstName, LastName, Age, Nationality, ClubId, NationalTeamId)" +
                    $"\nValues ('FirstName{i}', 'LastName{i}', {rnd.Next(18, 41)}, 'Nationality', null, null);");
            }

            for (int i = 1; i <= 1000; i++)
            {
                _indexedDbRepository.Query("Insert into Players (FirstName, LastName, Age, Nationality, ClubId, NationalTeamId)" +
                    $"\nValues ('FirstName{i}', 'LastName{i}', {rnd.Next(18, 41)}, 'Nationality', null, null);");
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult InputForeignKeys() 
        {
            var rnd = new Random();

            for (int i = 1; i <= 1000; i++)
            {
                _defaultDbRepository.Query("Update Players" +
                    $"\nset ClubId = {rnd.Next(1,1001)}, NationalTeamId = {rnd.Next(1,101)}" +
                    $"\nwhere Id = {i};");
            }

            for (int i = 1; i <= 1000; i++)
            {
                _indexedDbRepository.Query("Update Players" +
                    $"\nset ClubId = {rnd.Next(1, 1001)}, NationalTeamId = {rnd.Next(1, 101)}" +
                    $"\nwhere Id = {i};");
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
