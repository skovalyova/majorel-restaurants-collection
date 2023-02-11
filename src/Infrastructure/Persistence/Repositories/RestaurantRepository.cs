﻿using Majorel.RestaurantsCollection.Application.Interfaces;
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
        var restaurants = await _dbContext.Restaurants.OrderBy(r => r.AverageRating).AsNoTracking().ToListAsync(cancellationToken);

        return restaurants;
    }

    public async Task<IReadOnlyCollection<Restaurant>> GetByCityAsync(string city, CancellationToken cancellationToken)
    {
        var restaurants = await _dbContext.Restaurants.Where(r => r.City == city).ToListAsync(cancellationToken);

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

    public async Task<Restaurant?> GetByIdOrDefaultAsync(int id, CancellationToken cancellationToken)
    {
        var restaurant = await _dbContext.Restaurants.FindAsync(id, cancellationToken);

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
        var restaurant = await GetByIdAsync(id, cancellationToken);

        _dbContext.Restaurants.Remove(restaurant);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateRatingAsync(int id, double averageRating, int votes, CancellationToken cancellationToken)
    {
        var restaurant = await GetByIdAsync(id, cancellationToken);

        var updated = restaurant with { AverageRating = averageRating, Votes = votes };

        _dbContext.Restaurants.Update(updated);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}