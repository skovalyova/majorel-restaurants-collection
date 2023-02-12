using FluentValidation;

namespace Majorel.RestaurantsCollection.Application.Queries.GetRestaurantsSortedByRating
{
    public class GetRestaurantsSortedByRatingQueryValidator : AbstractValidator<GetRestaurantsSortedByRatingQuery>
    {
        public GetRestaurantsSortedByRatingQueryValidator()
        {
        }
    }
}
