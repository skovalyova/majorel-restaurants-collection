using Majorel.RestaurantsCollection.Application.Dto;
using MediatR;

namespace Majorel.RestaurantsCollection.Application.Queries.GetRestaurantById;

public record GetRestaurantByIdQuery(int Id) : IRequest<RestaurantDto>;
