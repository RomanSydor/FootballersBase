using FootballersBase.Contexts;
using FootballersBase.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace FootballersBase.Controllers
{
    public class CoachesController : Controller
    {
        private FootballersDbRepository _defaultDbRepository;
        private FootballersDbRepository _indexedDbRepository;
        private DataContext _dataContext;
        private DataContextIndexedDb _dataContextIndexedDb;

        private string _alphabeth = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public CoachesController(DataContext dataContext, DataContextIndexedDb indexedDb)
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

            var firstCoachesIdDefault = _dataContext.Coaches.Select(x => x.Id).First();
            var lastCoachesIdDefault = _dataContext.Coaches.Select(x => x.Id).Last();
            var firstClubsIdDefault = _dataContext.Clubs.Select(x => x.Id).First();
            var lastClubsIdDefault = _dataContext.Clubs.Select(x => x.Id).Last();
            var firstNationalTeamsIdDefault = _dataContext.NationalTeams.Select(x => x.Id).First();
            var lastNationalTeamsIdDefault = _dataContext.NationalTeams.Select(x => x.Id).Last();

            for (int i = firstCoachesIdDefault; i <= lastCoachesIdDefault; i++)
            {
                _defaultDbRepository.Query("Update Coaches" +
                    $"\nset ClubId = {rnd.Next(firstClubsIdDefault, lastClubsIdDefault + 1)}, NationalTeamId = {rnd.Next(firstNationalTeamsIdDefault, lastNationalTeamsIdDefault + 1)}" +
                    $"\nwhere Id = {i};");
            }

            var firstCoachesIdIndexed = _dataContextIndexedDb.CoachesIndexedDb.Select(x => x.Id).First();
            var lastCoachesIdIndexed = _dataContextIndexedDb.CoachesIndexedDb.Select(x => x.Id).Last();
            var firstClubsIdIndexed = _dataContextIndexedDb.ClubsIndexedDb.Select(x => x.Id).First();
            var lastClubsIdIndexed = _dataContextIndexedDb.ClubsIndexedDb.Select(x => x.Id).Last();
            var firstNationalTeamsIdIndexed = _dataContextIndexedDb.NationalTeamsIndexedDb.Select(x => x.Id).First();
            var lastNationalTeamsIdIndexed = _dataContextIndexedDb.NationalTeamsIndexedDb.Select(x => x.Id).Last();

            for (int i = firstCoachesIdIndexed; i <= lastCoachesIdIndexed; i++)
            {
                _indexedDbRepository.Query("Update Coaches" +
                   $"\nset ClubId = {rnd.Next(firstClubsIdIndexed, lastClubsIdIndexed + 1)}, NationalTeamId = {rnd.Next(firstNationalTeamsIdIndexed, lastNationalTeamsIdIndexed + 1)}" + 
                   $"\nwhere Id = {i};");
            }

                return RedirectToAction("Index", "Home");
        }
    }
}