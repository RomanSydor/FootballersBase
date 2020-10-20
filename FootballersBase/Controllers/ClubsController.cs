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
        private string _alphabeth = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public ClubsController(DataContext dataContext)
        {
            _defaultDbRepository = new DefaultFootballersRepository();
            _indexedDbRepository = new IndexedFootballersRepository();
            _defaultDbRepository.CreateConnection();
            _indexedDbRepository.CreateConnection();
            _dataContext = dataContext;
        }

        public ActionResult InputIntoTable()
        {
            var rnd = new Random();

            for (int i = 1; i <= 1000; i++)
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

            for (int i = 2001; i <= 3000; i++)
            {
                _defaultDbRepository.Query("Update Clubs" +
                    $"\nset CoachId = {rnd.Next(1001, 2001)}" +
                    $"\nwhere Id = {i};");
            }

            for (int i = 1001; i <= 2000; i++)
            {
                
                _indexedDbRepository.Query("Update Clubs" +
                    $"\nset CoachId = {rnd.Next(1001, 2001)}" +
                    $"\nwhere Id = {i};");
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
