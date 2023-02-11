using Majorel.RestaurantsCollection.Application.Interfaces;
using Majorel.RestaurantsCollection.Infrastructure.Persistence;
using Majorel.RestaurantsCollection.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Majorel.RestaurantsCollection.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer("name=ConnectionStrings:RestaurantsDatabase"));

            services.AddScoped<IRestaurantRepository, RestaurantRepository>();

            return services;
        }
    }
}
