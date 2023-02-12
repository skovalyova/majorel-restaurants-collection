namespace Majorel.RestaurantsCollection.Application.Dto
{
    public record UpdateRestaurantRatingDto
    {
        /// <example>4.7</example>
        public string AverageRating { get; init; } = string.Empty;

        /// <example>1890</example>
        public int Votes { get; init; }
    }
}
