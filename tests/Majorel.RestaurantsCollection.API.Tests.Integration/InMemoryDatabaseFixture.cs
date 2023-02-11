namespace Majorel.RestaurantsCollection.API.Tests.Integration
{
    //public class RestaurantsSeedDataFixture : IDisposable
    //{
    //    public HttpClient Client { get; }

    //    private ApplicationDbContext _context;

    //    public RestaurantsSeedDataFixture()
    //    {
    //        var factory = new RestaurantWebApplicationFactory<Program>();
    //        Client = factory.CreateClient();

    //        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
    //            .UseInMemoryDatabase("TestListDatabase")
    //            .Options;
    //        _context = new ApplicationDbContext(options);

    //        SeedTestDatabase();
    //    }

    //    public void Dispose()
    //    {
    //        _context.Dispose();
    //    }

    //    private void SeedTestDatabase()
    //    {
    //        _context.Database.EnsureDeleted();
    //        var restaurants = new List<Restaurant>
    //            {
    //                new()
    //                {
    //                    City = "Polotsk",
    //                    Name = "Kinza",
    //                    AverageRating = 4.2,
    //                    Votes = 27,
    //                    EstimatedCost = 25
    //                },
    //                new()
    //                {
    //                    City = "Grodno",
    //                    Name = "Burgerking",
    //                    AverageRating = 4.0,
    //                    Votes = 1985,
    //                    EstimatedCost = 15
    //                },
    //                new()
    //                {
    //                    City = "Minsk",
    //                    Name = "JustEat",
    //                    AverageRating = 3.73,
    //                    Votes = 94671,
    //                    EstimatedCost = 8
    //                },
    //            };

    //        foreach (var restaurant in restaurants)
    //        {
    //            _context.Restaurants.Add(restaurant);
    //        }

    //        _context.SaveChanges();
    //    }
    //}

    //    public class InMemoryDatabaseFixture : ICollectionFixture<RestaurantWebApplicationFactory>
    //    {
    //        private readonly IRestaurantRepository _restaurantRepository;

    //        public InMemoryDatabaseFixture()
    //        {
    //            var factory = new RestaurantWebApplicationFactory();
    //            _restaurantRepository = factory.Services.GetRequiredService<IRestaurantRepository>();
    //        }

    //        public async Task InitializeAsync()
    //        {
    //            var restaurant1 = new Restaurant
    //            {
    //                City = "Polotsk",
    //                Name = "Kinza",
    //                AverageRating = 4.2,
    //                Votes = 27,
    //                EstimatedCost = 25
    //            };

    //            await _restaurantRepository.CreateAsync(restaurant1, CancellationToken.None);
    //        }
    //    }

    //    [CollectionDefinition(nameof(InMemoryDatabaseFixture))]
    //    public class InMemoryDatabaseCollectionFixture : ICollectionFixture<InMemoryDatabaseFixture>
    //    {
    //        // This class has no code, and is never created. Its purpose is simply
    //        // to be the place to apply [CollectionDefinition] and all the
    //        // ICollectionFixture<> interfaces.
    //    }
}
