using AutoMapper;
using Majorel.RestaurantsCollection.Application.Commands.CreateRestaurant;
using Majorel.RestaurantsCollection.Application.Commands.UpdateRestaurantRating;
using Majorel.RestaurantsCollection.Application.Dto;
using Majorel.RestaurantsCollection.Domain.Entities;
using System.Globalization;

namespace Majorel.RestaurantsCollection.Application.Mappings
{
    public class RestaurantProfile : Profile
    {
        public RestaurantProfile()
        {
            CreateMap<Restaurant, RestaurantDto>()
                .ForCtorParam(nameof(RestaurantDto.AverageRating), m => m.MapFrom(s => s.AverageRating.ToString(CultureInfo.InvariantCulture)))
                .ReverseMap();

            CreateMap<CreateRestaurantDto, CreateRestaurantCommand>()
                .ForCtorParam(nameof(CreateRestaurantCommand.AverageRating), m => m.MapFrom(s => double.Parse(s.AverageRating, CultureInfo.InvariantCulture)));

            CreateMap<UpdateRestaurantRatingDto, UpdateRestaurantRatingCommand>()
                .ForCtorParam(nameof(UpdateRestaurantRatingCommand.Id), m => m.MapFrom(s => default(int)))
                .ForCtorParam(nameof(UpdateRestaurantRatingCommand.AverageRating), m => m.MapFrom(s => double.Parse(s.AverageRating, CultureInfo.InvariantCulture)))
                .ForCtorParam(nameof(Restaurant.Votes), m => m.MapFrom(s => s.Votes));

            CreateMap<CreateRestaurantCommand, Restaurant>();
        }
    }
}
