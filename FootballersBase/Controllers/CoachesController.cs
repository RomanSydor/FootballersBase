using FootballersBase.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FootballersBase.Controllers
{
    public class CoachesController : Controller
    {
        private FootballersDbRepository _defaultDbRepository;
        private FootballersDbRepository _indexedDbRepository;
        private string _alphabeth = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

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
                var firstName = "";
                for (int fn = 0; fn < 13; fn++)
                {
                    firstName += _alphabeth[rnd.Next(0, _alphabeth.Length)];
                }
                var lastName = "";
                for (int ln = 0; ln < 13; ln++)
                {
                    lastName += _alphabeth[rnd.Next(0, _alphabeth.Length)];
                }
                var nationality = "";
                for (int n = 0; n < 15; n++)
                {
                    nationality += _alphabeth[rnd.Next(0, _alphabeth.Length)];
                }


                _defaultDbRepository.Query("Insert into Coaches (FirstName, LastName, Country, ClubId, NationalTeamId)" +
                    $"\nValues ('{firstName}', '{lastName}', '{nationality}', null, null);");
                _indexedDbRepository.Query("Insert into Coaches (FirstName, LastName, Country, ClubId, NationalTeamId)" +
                    $"\nValues ('{firstName}', '{lastName}', '{nationality}', null, null);");
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult InputForeignKeys()
        {
            var rnd = new Random();

            for (int i = 1001; i <= 2000; i++)
            {
                _defaultDbRepository.Query("Update Coaches" +
                    $"\nset ClubId = {rnd.Next(2001, 3001)}, NationalTeamId = {rnd.Next(101, 201)}" +
                    $"\nwhere Id = {i};");
                _indexedDbRepository.Query("Update Coaches" +
                    $"\nset ClubId = {rnd.Next(1001, 2001)}, NationalTeamId = {rnd.Next(101, 201)}" +
                    $"\nwhere Id = {i};");
            }

            return RedirectToAction("Index", "Home");
        }
    }
}