using Breweries.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Breweries.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {

        }

        public DbSet<Brewery> Breweries { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<State> States { get; set; }

        public DbSet<BreweryType> BreweryTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=Breweries;Integrated Security=true;");

            base.OnConfiguring(optionsBuilder);
        }
    }
}
