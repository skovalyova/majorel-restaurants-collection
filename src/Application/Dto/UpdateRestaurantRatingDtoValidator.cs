using FluentValidation;
using Majorel.RestaurantsCollection.Application.Validators;

namespace Majorel.RestaurantsCollection.Application.Dto
{
    public class UpdateRestaurantRatingDtoValidator : AbstractValidator<UpdateRestaurantRatingDto>
    {
        public UpdateRestaurantRatingDtoValidator()
        {
            RuleFor(v => v.AverageRating).MustBeValidAverageRating();

            RuleFor(v => v.Votes).MustBeValidVotesCount();
        }
    }
}
