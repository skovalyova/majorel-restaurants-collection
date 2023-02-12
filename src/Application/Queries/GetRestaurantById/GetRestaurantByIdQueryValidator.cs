using FluentValidation;
using Majorel.RestaurantsCollection.Application.Validators;

namespace Majorel.RestaurantsCollection.Application.Queries.GetRestaurantById
{
    public class GetRestaurantByIdQueryValidator : AbstractValidator<GetRestaurantByIdQuery>
    {
        public GetRestaurantByIdQueryValidator()
        {
            RuleFor(v => v.Id).MustBeValidId();
        }
    }
}
