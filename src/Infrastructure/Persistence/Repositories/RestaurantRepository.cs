using Majorel.RestaurantsCollection.Application.Interfaces;
using Majorel.RestaurantsCollection.Domain.Entities;
using Majorel.RestaurantsCollection.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Majorel.RestaurantsCollection.Infrastructure.Persistence.Repositories;

internal class RestaurantRepository : IRestaurantRepository
{
    private readonly ApplicationDbContext _dbContext;

    public RestaurantRepository(ApplicationDbContext dbContext)
    {
        ArgumentNullException.ThrowIfNull(dbContext);

        _dbContext = dbContext;
    }

    public async Task<IReadOnlyCollection<Restaurant>> GetAllAsync(CancellationToken cancellationToken)
    {
        var restaurants = await _dbContext.Restaurants.AsNoTracking().ToListAsync(cancellationToken);

        return restaurants;
    }

    public async Task<IReadOnlyCollection<Restaurant>> GetAllSortedByRatingAsync(CancellationToken cancellationToken)
    {
        var restaurants = await _dbContext.Restaurants.AsNoTracking().OrderBy(r => r.AverageRating).ToListAsync(cancellationToken);

        return restaurants;
    }

    public async Task<IReadOnlyCollection<Restaurant>> GetByCityAsync(string city, CancellationToken cancellationToken)
    {
        var restaurants = await _dbContext.Restaurants.AsNoTracking().Where(r => r.City == city).ToListAsync(cancellationToken);

        return restaurants;
    }

    public async Task<Restaurant> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        var restaurant = await _dbContext.Restaurants.FindAsync(id, cancellationToken);

        if (restaurant is null)
        {
            throw new NotFoundException(nameof(Restaurant), id.ToString());
        }

        return restaurant;
    }

    public async Task<int> CreateAsync(Restaurant restaurant, CancellationToken cancellationToken)
    {
        await _dbContext.Restaurants.AddAsync(restaurant, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return restaurant.Id;
    }

    public async Task DeleteByIdAsync(int id, CancellationToken cancellationToken)
    {
        var exists = _dbContext.Restaurants.Any(r => r.Id == id);

        if (!exists)
        {
            throw new NotFoundException(nameof(Restaurant), id.ToString());
        }

        var restaurant = new Restaurant { Id = id };
        _dbContext.Restaurants.Remove(restaurant);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateRatingAsync(int id, double averageRating, int votes, CancellationToken cancellationToken)
    {
        var restaurant = await GetByIdAsync(id, cancellationToken);

        restaurant.AverageRating = averageRating;
        restaurant.Votes = votes;

        _dbContext.Restaurants.Update(restaurant);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
