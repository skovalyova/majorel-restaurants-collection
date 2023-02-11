using Majorel.RestaurantsCollection.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Majorel.RestaurantsCollection.Infrastructure.Persistence
{
    internal class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Restaurant> Restaurants => Set<Restaurant>();
    }
}
