using AutoMapper;
using Majorel.RestaurantsCollection.Application.Dto;
using Majorel.RestaurantsCollection.Application.Interfaces;
using MediatR;

namespace Majorel.RestaurantsCollection.Application.Queries.GetAllRestaurants;

public class GetAllRestaurantsQueryHandler : IRequestHandler<GetAllRestaurantsQuery, IReadOnlyCollection<RestaurantDto>>
{
    private readonly IRestaurantRepository _restaurantRepository;
    private readonly IMapper _mapper;

    public GetAllRestaurantsQueryHandler(IRestaurantRepository restaurantRepository, IMapper mapper)
    {
        ArgumentNullException.ThrowIfNull(restaurantRepository);
        ArgumentNullException.ThrowIfNull(mapper);

        _restaurantRepository = restaurantRepository;
        _mapper = mapper;
    }

    public async Task<IReadOnlyCollection<RestaurantDto>> Handle(GetAllRestaurantsQuery request, CancellationToken cancellationToken)
    {
        var restaurants = await _restaurantRepository.GetAllAsync(cancellationToken);
        var result = _mapper.Map<IReadOnlyCollection<RestaurantDto>>(restaurants);

        return result;
    }
}