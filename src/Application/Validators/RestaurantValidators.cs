using FluentValidation;
using Majorel.RestaurantsCollection.Domain.Constants;
using System.Text.RegularExpressions;

namespace Majorel.RestaurantsCollection.Application.Validators
{
    internal static class RestaurantValidators
    {
        private const string _averageRatingRegex = @"^\d+\.?\d*$";

        public static IRuleBuilderOptions<T, int> MustBeValidId<T>(this IRuleBuilder<T, int> rule) => rule
            .GreaterThan(0);

        public static IRuleBuilderOptions<T, string> MustBeValidCity<T>(this IRuleBuilder<T, string> rule) => rule
            .NotEmpty()
            .MaximumLength(ValidationConstants.RestaurantCityMaxLength);

        public static IRuleBuilderOptions<T, string> MustBeValidRestaurantName<T>(this IRuleBuilder<T, string> rule) => rule
            .NotEmpty()
            .MaximumLength(ValidationConstants.RestaurantNameMaxLength);

        public static IRuleBuilderOptions<T, int> MustBeValidEstimatedCost<T>(this IRuleBuilder<T, int> rule) => rule
            .GreaterThanOrEqualTo(0);

        public static IRuleBuilderOptions<T, string> MustBeValidAverageRating<T>(this IRuleBuilder<T, string> rule) => rule
            .NotEmpty()
            .Matches(_averageRatingRegex, RegexOptions.Compiled)
            .WithMessage("'Average Rating' must be in numeric format with optional decimal part using dot as a separator. Examples: 3 or 4.8");

        public static IRuleBuilderOptions<T, double> MustBeValidAverageRating<T>(this IRuleBuilder<T, double> rule) => rule
            .GreaterThanOrEqualTo(0);

        public static IRuleBuilderOptions<T, int> MustBeValidVotesCount<T>(this IRuleBuilder<T, int> rule) => rule
            .GreaterThanOrEqualTo(0);
    }
}
