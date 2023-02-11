using Majorel.RestaurantsCollection.API;
using Majorel.RestaurantsCollection.API.Middlewares;
using Majorel.RestaurantsCollection.Application;
using Majorel.RestaurantsCollection.Infrastructure;

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

app.Run();
