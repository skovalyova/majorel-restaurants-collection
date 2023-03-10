using FluentValidation;
using FluentValidation.AspNetCore;
using Majorel.RestaurantsCollection.Application.Behaviors;
using Majorel.RestaurantsCollection.Application.Mappings;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Majorel.RestaurantsCollection.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetAssembly(typeof(RestaurantProfile)));

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddFluentValidationAutoValidation();

            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestHandlerValidationBehavior<,>));

            return services;
        }
    }
}
