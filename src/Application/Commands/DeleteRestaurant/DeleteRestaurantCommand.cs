using MediatR;

namespace Majorel.RestaurantsCollection.Application.Commands.DeleteRestaurant
{
    public record DeleteRestaurantCommand(int Id) : IRequest;
}
