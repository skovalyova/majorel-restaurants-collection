using Majorel.RestaurantsCollection.Application.Dto;
using MediatR;

namespace Majorel.RestaurantsCollection.Application.Commands.CreateRestaurant
{
    public record CreateRestaurantCommand(string City, string Name, int EstimatedCost, string AverageRating, int Votes) : IRequest<RestaurantDto>;

    //public record CreateRestaurantCommand : IRequest<RestaurantDto>
    //{
    //    public string City { get; init; }
    //    public string Name { get; init; }
    //    public int EstimatedCost { get; init; }
    //    public string AverageRating { get; init; }
    //    public int Votes { get; init; }
    //}
}
