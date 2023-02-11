using AutoMapper;
using Majorel.RestaurantsCollection.Application.Dto;
using Majorel.RestaurantsCollection.Application.Interfaces;
using MediatR;

namespace Majorel.RestaurantsCollection.Application.Queries.GetRestaurantById;

public class GetRestaurantByIdQueryHandler : IRequestHandler<GetRestaurantByIdQuery, RestaurantDto>
{
    private readonly IRestaurantRepository _restaurantRepository;
    private readonly IMapper _mapper;

    public GetRestaurantByIdQueryHandler(IRestaurantRepository restaurantRepository, IMapper mapper)
    {
        ArgumentNullException.ThrowIfNull(restaurantRepository);
        ArgumentNullException.ThrowIfNull(mapper);

        _restaurantRepository = restaurantRepository;
        _mapper = mapper;
    }

    public async Task<RestaurantDto> Handle(GetRestaurantByIdQuery request, CancellationToken cancellationToken)
    {
        var restaurant = await _restaurantRepository.GetByIdAsync(request.Id, cancellationToken);
        var result = _mapper.Map<RestaurantDto>(restaurant);

        return result;
    }
}