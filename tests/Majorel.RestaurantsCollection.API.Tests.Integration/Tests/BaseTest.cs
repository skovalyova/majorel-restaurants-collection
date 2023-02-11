using Majorel.RestaurantsCollection.Domain.Entities;
using Majorel.RestaurantsCollection.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace Majorel.RestaurantsCollection.API.Tests.Integration.Tests
{
    public class BaseTest : IClassFixture<RestaurantWebApplicationFactory<Program>>, IDisposable
    {
        protected HttpClient Client { get; }

        public BaseTest()
        {
            var factory = new RestaurantWebApplicationFactory<Program>();
            Client = factory.CreateClient();

            var serviceProvider = factory.Services;
            using var scope = serviceProvider.CreateScope();
            using var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            SeedTestDatabase(context);
        }

        public void Dispose()
        {
            Client.Dispose();

            GC.SuppressFinalize(this);
        }

        private void SeedTestDatabase(ApplicationDbContext context)
        {
            var restaurants = new List<Restaurant>
            {
                new()
                {
                    City = "Polotsk",
                    Name = "Kinza",
                    AverageRating = 4.2,
                    Votes = 27,
                    EstimatedCost = 25
                },
                new()
                {
                    City = "Grodno",
                    Name = "Burgerking",
                    AverageRating = 4.0,
                    Votes = 1985,
                    EstimatedCost = 15
                },
                new()
                {
                    City = "Minsk",
                    Name = "JustEat",
                    AverageRating = 3.73,
                    Votes = 94671,
                    EstimatedCost = 8
                },
            };

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            foreach (var restaurant in restaurants)
            {
                context.Restaurants.Add(restaurant);
            }

            context.SaveChanges();
        }
    }
}
