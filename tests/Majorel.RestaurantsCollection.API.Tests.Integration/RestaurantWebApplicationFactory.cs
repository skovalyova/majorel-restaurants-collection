using Majorel.RestaurantsCollection.Infrastructure.Persistence;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Majorel.RestaurantsCollection.API.Tests.Integration
{
    public class RestaurantWebApplicationFactory : WebApplicationFactory<API.Program>
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
                    services.Remove(dbContextDescriptor);
                }

                services.AddDbContext<ApplicationDbContext>(opt => opt.UseInMemoryDatabase("InMemoryRestaurantsCollection"));
            });

            builder.UseEnvironment("Development");
        }
    }
}
