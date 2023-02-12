using Majorel.RestaurantsCollection.Domain.Entities;

namespace Majorel.RestaurantsCollection.Application.Interfaces
{
    public interface IRestaurantRepository
    {
        public Task<IReadOnlyCollection<Restaurant>> GetAllAsync(CancellationToken cancellationToken);

        public Task<IReadOnlyCollection<Restaurant>> GetAllSortedByRatingAsync(CancellationToken cancellationToken);

        public Task<IReadOnlyCollection<Restaurant>> GetByCityAsync(string city, CancellationToken cancellationToken);

        /// <summary>
        /// Find a restaurant by ID.
        /// </summary>
        /// <param name="id">Restaurant ID</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Existing restaurant found</returns>
        /// <exception cref="Domain.Exceptions.NotFoundException"></exception>
        public Task<Restaurant> GetByIdAsync(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Create a new restaurant.
        /// </summary>
        /// <param name="restaurant">Details of the restaurant</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Created restaurant ID</returns>
        public Task<int> CreateAsync(Restaurant restaurant, CancellationToken cancellationToken);

        /// <summary>
        /// Update average rating and votes of a restaurant by ID.
        /// </summary>
        /// <param name="id">Restaurant ID</param>
        /// <param name="averageRating">Average rating of the restaurant</param>
        /// <param name="votes">Total reviews of the restaurant</param>
        /// <param name="cancellationToken"></param>
        /// <exception cref="Domain.Exceptions.NotFoundException"></exception>
        public Task UpdateRatingAsync(int id, double averageRating, int votes, CancellationToken cancellationToken);

        /// <summary>
        /// Delete a restaurant by ID.
        /// </summary>
        /// <param name="id">Restaurant ID</param>
        /// <param name="cancellationToken"></param>
        /// <exception cref="Domain.Exceptions.NotFoundException"></exception>
        public Task DeleteByIdAsync(int id, CancellationToken cancellationToken);
    }
}
