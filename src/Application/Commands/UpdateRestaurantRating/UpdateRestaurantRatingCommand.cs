using Majorel.RestaurantsCollection.Application.Dto;
using MediatR;

namespace Majorel.RestaurantsCollection.Application.Commands.UpdateRestaurantRating;

public record UpdateRestaurantRatingCommand(int Id, double AverageRating, int Votes) : IRequest<RestaurantDto>;
