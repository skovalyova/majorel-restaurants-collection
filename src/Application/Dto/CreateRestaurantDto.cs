namespace Majorel.RestaurantsCollection.Application.Dto
{
    public record CreateRestaurantDto
    {
        /// <example>Miamy</example>
        public string City { get; init; } = string.Empty;

        /// <example>The surf club restaurant</example>
        public string Name { get; init; } = string.Empty;

        /// <example>53</example>
        public int EstimatedCost { get; init; }

        /// <example>4.9</example>
        public string AverageRating { get; init; } = string.Empty;

        /// 1853
        public int Votes { get; init; }
    }
}
