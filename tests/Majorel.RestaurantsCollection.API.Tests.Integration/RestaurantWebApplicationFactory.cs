using Majorel.RestaurantsCollection.Infrastructure.Persistence;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Majorel.RestaurantsCollection.API.Tests.Integration
{
    public class RestaurantWebApplicationFactory<T> : WebApplicationFactory<Program>
    {
        public RestaurantWebApplicationFactory()
        {
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var dbContextDescriptor = services.SingleOrDefault(
                    d => d.ServiceType ==
                        typeof(DbContextOptions<ApplicationDbContext>));

                if (dbContextDescriptor is not null)
                {
                    // Get rid of the connection to the real database which is configured in Program.cs
                    services.Remove(dbContextDescriptor);
                }

                var serviceProvider = services
                    .AddEntityFrameworkInMemoryDatabase()
                    .BuildServiceProvider();

                services.AddDbContext<ApplicationDbContext>(options =>
                {
                    options.UseInMemoryDatabase($"RestaurantsCollectionDb");
                    options.UseInternalServiceProvider(serviceProvider);
                });
            });

            builder.UseEnvironment("Development");
        }
    }
}
