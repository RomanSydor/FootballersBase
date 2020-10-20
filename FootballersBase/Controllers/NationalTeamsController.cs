using FootballersBase.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FootballersBase.Controllers
{
    public class NationalTeamsController : Controller
    {
        private FootballersDbRepository _defaultDbRepository;
        private FootballersDbRepository _indexedDbRepository;
        private string _alphabeth = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

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

            for (int i = 101; i <= 200; i++)
            {
                _defaultDbRepository.Query("Update NationalTeams" +
                    $"\nset CoachId = {rnd.Next(1001, 2001)}" +
                    $"\nwhere Id = {i};");
                _indexedDbRepository.Query("Update NationalTeams" +
                    $"\nset CoachId = {rnd.Next(1001, 2001)}" +
                    $"\nwhere Id = {i};");
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
