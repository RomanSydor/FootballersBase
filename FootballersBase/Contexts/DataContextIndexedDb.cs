using FootballersBase.Models;
using Microsoft.EntityFrameworkCore;

namespace FootballersBase.Contexts
{
    public class DataContextIndexedDb : DbContext
    {
        public DataContextIndexedDb(DbContextOptions<DataContextIndexedDb> options)
          : base(options)
        {
            //Database.EnsureCreated();
            //Database.EnsureDeleted();
        }

        public DbSet<Player> PlayersIndexedDb { get; set; }
        public DbSet<Club> ClubsIndexedDb { get; set; }
        public DbSet<NationalTeam> NationalTeamsIndexedDb { get; set; }
        public DbSet<Coach> CoachesIndexedDb { get; set; }
    }
}
