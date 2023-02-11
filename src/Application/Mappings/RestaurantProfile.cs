using AutoMapper;
using Majorel.RestaurantsCollection.Application.Commands.CreateRestaurant;
using Majorel.RestaurantsCollection.Application.Dto;
using Majorel.RestaurantsCollection.Domain.Entities;

namespace Majorel.RestaurantsCollection.Application.Mappings
{
    public class RestaurantProfile : Profile
    {
        public RestaurantProfile()
        {
            CreateMap<Restaurant, RestaurantDto>()
                .ReverseMap();

            CreateMap<CreateRestaurantCommand, Restaurant>()
                .ForCtorParam(nameof(Restaurant.Id), m => m.MapFrom(s => default(int)))
                .ForCtorParam(nameof(Restaurant.City), m => m.MapFrom(s => s.City))
                .ForCtorParam(nameof(Restaurant.Name), m => m.MapFrom(s => s.Name))
                .ForCtorParam(nameof(Restaurant.AverageRating), m => m.MapFrom(s => double.Parse(s.AverageRating)))
                .ForCtorParam(nameof(Restaurant.EstimatedCost), m => m.MapFrom(s => s.EstimatedCost))
                .ForCtorParam(nameof(Restaurant.Votes), m => m.MapFrom(s => s.Votes));
        }
    }
}
