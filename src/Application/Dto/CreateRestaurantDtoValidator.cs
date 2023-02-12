using FluentValidation;
using Majorel.RestaurantsCollection.Application.Validators;

namespace Majorel.RestaurantsCollection.Application.Dto
{
    public class CreateRestaurantDtoValidator : AbstractValidator<CreateRestaurantDto>
    {
        public CreateRestaurantDtoValidator()
        {
            RuleFor(v => v.City).MustBeValidCity();

            RuleFor(v => v.Name).MustBeValidRestaurantName();

            RuleFor(v => v.EstimatedCost).MustBeValidEstimatedCost();

            RuleFor(v => v.AverageRating).MustBeValidAverageRating();

            RuleFor(v => v.Votes).MustBeValidVotesCount();
        }
    }
}
