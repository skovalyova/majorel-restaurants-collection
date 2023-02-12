using Majorel.RestaurantsCollection.API.Controllers;
using Majorel.RestaurantsCollection.Application.Dto;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Majorel.RestaurantsCollection.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Restaurants Collection API"
                });

                var assemblies = new List<Assembly>
                {
                    Assembly.GetAssembly(typeof(RestaurantController))!,
                    Assembly.GetAssembly(typeof(RestaurantDto))!
                };

                var xmlFiles = Directory.GetFiles(AppContext.BaseDirectory, "*.xml", SearchOption.TopDirectoryOnly).ToList();
                xmlFiles.ForEach(xmlFile => options.IncludeXmlComments(xmlFile));
            });

            return services;
        }
    }
}
