using FluentValidation;
using Majorel.RestaurantsCollection.Application.Validators;

namespace Majorel.RestaurantsCollection.Application.Commands.UpdateRestaurantRating
{
    public class UpdateRestaurantRatingCommandValidator : AbstractValidator<UpdateRestaurantRatingCommand>
    {
        public UpdateRestaurantRatingCommandValidator()
        {
            RuleFor(v => v.Id).MustBeValidId();

            RuleFor(v => v.AverageRating).MustBeValidAverageRating();

            RuleFor(v => v.Votes).MustBeValidVotesCount();
        }
    }
}
