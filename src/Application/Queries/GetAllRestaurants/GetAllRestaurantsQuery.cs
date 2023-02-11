using Majorel.RestaurantsCollection.Application.Dto;
using MediatR;

namespace Majorel.RestaurantsCollection.Application.Queries.GetAllRestaurants;

public record GetAllRestaurantsQuery() : IRequest<IReadOnlyCollection<RestaurantDto>>;
