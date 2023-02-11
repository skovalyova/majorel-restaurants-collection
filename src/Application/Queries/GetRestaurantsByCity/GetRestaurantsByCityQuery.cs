using Majorel.RestaurantsCollection.Application.Dto;
using MediatR;

namespace Majorel.RestaurantsCollection.Application.Queries.GetRestaurantsByCity
{
    public record GetRestaurantsByCityQuery(string City) : IRequest<IReadOnlyCollection<RestaurantDto>>;
}
