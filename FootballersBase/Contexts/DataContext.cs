using FootballersBase.Models;
using Microsoft.EntityFrameworkCore;

namespace FootballersBase.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
          : base(options)
        {
            //Database.EnsureCreated();
            //Database.EnsureDeleted();
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<NationalTeam> NationalTeams { get; set; }
        public DbSet<Coach> Coaches { get; set; }

    }
}
