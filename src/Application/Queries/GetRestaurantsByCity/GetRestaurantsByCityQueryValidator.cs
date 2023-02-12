using FluentValidation;
using Majorel.RestaurantsCollection.Application.Validators;

namespace Majorel.RestaurantsCollection.Application.Queries.GetRestaurantsByCity
{
    public class GetRestaurantsByCityQueryValidator : AbstractValidator<GetRestaurantsByCityQuery>
    {
        public GetRestaurantsByCityQueryValidator()
        {
            RuleFor(v => v.City).MustBeValidCity();
        }
    }
}
