using Majorel.RestaurantsCollection.Application.Dto;
using MediatR;

namespace Majorel.RestaurantsCollection.Application.Commands.CreateRestaurant
{
    public record CreateRestaurantCommand(string City, string Name, int EstimatedCost, double AverageRating, int Votes) : IRequest<RestaurantDto>;
}
