using FluentValidation;
using Majorel.RestaurantsCollection.Application.Validators;

namespace Majorel.RestaurantsCollection.Application.Commands.CreateRestaurant
{
    public class CreateRestaurantCommandValidatorValidator : AbstractValidator<CreateRestaurantCommand>
    {
        public CreateRestaurantCommandValidatorValidator()
        {
            RuleFor(v => v.City).MustBeValidCity();

            RuleFor(v => v.Name).MustBeValidRestaurantName();

            RuleFor(v => v.EstimatedCost).MustBeValidEstimatedCost();

            RuleFor(v => v.AverageRating).MustBeValidAverageRating();

            RuleFor(v => v.Votes).MustBeValidVotesCount();
        }
    }
}
