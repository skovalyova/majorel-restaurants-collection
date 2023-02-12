using AutoMapper;
using Majorel.RestaurantsCollection.Application.Dto;
using Majorel.RestaurantsCollection.Application.Interfaces;
using Majorel.RestaurantsCollection.Domain.Entities;
using MediatR;

namespace Majorel.RestaurantsCollection.Application.Commands.CreateRestaurant;

public class CreateRestaurantCommandHandler : IRequestHandler<CreateRestaurantCommand, RestaurantDto>
{
    private readonly IRestaurantRepository _restaurantRepository;
    private readonly IMapper _mapper;

    public CreateRestaurantCommandHandler(IRestaurantRepository restaurantRepository, IMapper mapper)
    {
        ArgumentNullException.ThrowIfNull(restaurantRepository);
        ArgumentNullException.ThrowIfNull(mapper);

        _restaurantRepository = restaurantRepository;
        _mapper = mapper;
    }

    public async Task<RestaurantDto> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
    {

        var restaurantToCreate = _mapper.Map<Restaurant>(request);
        var restaurantId = await _restaurantRepository.CreateAsync(restaurantToCreate, cancellationToken);

        var createdRestaurant = await _restaurantRepository.GetByIdAsync(restaurantId, cancellationToken);
        var result = _mapper.Map<RestaurantDto>(createdRestaurant);

        return result;
    }
}
