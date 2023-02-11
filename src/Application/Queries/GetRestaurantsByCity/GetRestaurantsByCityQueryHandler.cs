using AutoMapper;
using Majorel.RestaurantsCollection.Application.Dto;
using Majorel.RestaurantsCollection.Application.Interfaces;
using MediatR;

namespace Majorel.RestaurantsCollection.Application.Queries.GetRestaurantsByCity
{
    public class GetRestaurantsByCityQueryHandler : IRequestHandler<GetRestaurantsByCityQuery, IReadOnlyCollection<RestaurantDto>>
    {
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IMapper _mapper;

        public GetRestaurantsByCityQueryHandler(IRestaurantRepository restaurantRepository, IMapper mapper)
        {
            ArgumentNullException.ThrowIfNull(restaurantRepository);
            ArgumentNullException.ThrowIfNull(mapper);

            _restaurantRepository = restaurantRepository;
            _mapper = mapper;
        }

        public async Task<IReadOnlyCollection<RestaurantDto>> Handle(GetRestaurantsByCityQuery request, CancellationToken cancellationToken)
        {
            var restaurants = await _restaurantRepository.GetByCityAsync(request.City, cancellationToken);
            var result = _mapper.Map<IReadOnlyCollection<RestaurantDto>>(restaurants);

            return result;
        }
    }
}
