using Majorel.RestaurantsCollection.Domain.Entities;
using Majorel.RestaurantsCollection.Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Majorel.RestaurantsCollection.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Restaurant> Restaurants => Set<Restaurant>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RestaurantConfiguration).Assembly);
        }
    }
}
