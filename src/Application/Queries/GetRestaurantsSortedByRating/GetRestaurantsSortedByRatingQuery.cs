using Majorel.RestaurantsCollection.Application.Dto;
using MediatR;

namespace Majorel.RestaurantsCollection.Application.Queries.GetRestaurantsSortedByRating
{
    public record GetRestaurantsSortedByRatingQuery() : IRequest<IReadOnlyCollection<RestaurantDto>>;
}
