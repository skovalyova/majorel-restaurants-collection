using Majorel.RestaurantsCollection.Application.Interfaces;
using MediatR;

namespace Majorel.RestaurantsCollection.Application.Commands.DeleteRestaurant
{
    internal class DeleteRestaurantCommandHandler : IRequestHandler<DeleteRestaurantCommand>
    {
        private readonly IRestaurantRepository _restaurantRepository;

        public DeleteRestaurantCommandHandler(IRestaurantRepository restaurantRepository)
        {
            ArgumentNullException.ThrowIfNull(restaurantRepository);

            _restaurantRepository = restaurantRepository;
        }

        public async Task<Unit> Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
        {
            await _restaurantRepository.DeleteByIdAsync(request.Id, cancellationToken);

            return Unit.Value;
        }
    }
}
