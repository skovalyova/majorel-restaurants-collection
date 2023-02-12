using Majorel.RestaurantsCollection.API.Middlewares;
using Majorel.RestaurantsCollection.Application;
using Majorel.RestaurantsCollection.Infrastructure;
using Majorel.RestaurantsCollection.Infrastructure.Persistence;

namespace Majorel.RestaurantsCollection.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddApplicationServices();
        builder.Services.AddInfrastructureServices();
        builder.Services.AddApiServices();

        var app = builder.Build();

        app.MapControllers();
        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseHttpsRedirection();

        app.UseMiddleware<ExceptionHandlingMiddleware>();

        if (app.Environment.IsDevelopment())
        {
            var logger = app.Services.GetRequiredService<ILogger<Program>>();
            logger.LogInformation("Starting automated database migration.");
            using var scope = app.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            dbContext.Database.EnsureCreated();
            logger.LogInformation("Database is successfully created.");
        }

        app.Run();
    }
}