using AutoMapper;
using Majorel.RestaurantsCollection.Application.Dto;
using Majorel.RestaurantsCollection.Application.Interfaces;
using MediatR;

namespace Majorel.RestaurantsCollection.Application.Commands.UpdateRestaurantRating
{
    public class UpdateRestaurantRatingCommandHandler : IRequestHandler<UpdateRestaurantRatingCommand, RestaurantDto>
    {
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IMapper _mapper;

        public UpdateRestaurantRatingCommandHandler(IRestaurantRepository restaurantRepository, IMapper mapper)
        {
            ArgumentNullException.ThrowIfNull(restaurantRepository);
            ArgumentNullException.ThrowIfNull(mapper);

            _restaurantRepository = restaurantRepository;
            _mapper = mapper;
        }

        public async Task<RestaurantDto> Handle(UpdateRestaurantRatingCommand request, CancellationToken cancellationToken)
        {
            await _restaurantRepository.UpdateRatingAsync(request.Id, request.AverageRating, request.Votes, cancellationToken);

            var updatedRestaurant = await _restaurantRepository.GetByIdAsync(request.Id, cancellationToken);
            var result = _mapper.Map<RestaurantDto>(updatedRestaurant);

            return result;
        }
    }
}
