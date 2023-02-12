namespace Majorel.RestaurantsCollection.Application.Dto
{
    public record CreateRestaurantDto
    {
        /// <summary>City in which the restaurants are located. Required, max length = 200 chars</summary>
        /// <example>Miamy</example>
        public string City { get; init; } = string.Empty;

        /// <summary>Name of the restaurant. Required, max length = 200 chars</summary>
        /// <example>The surf club restaurant</example>
        public string Name { get; init; } = string.Empty;

        /// <summary>The estimated cost for 2 people at the restaurant. Required, non-negative number</summary>
        /// <example>53</example>
        public int EstimatedCost { get; init; }

        /// <summary>Average rating of the restaurant represented as a string. Required, non-negative number with optional decimal part and dot as a separator</summary>
        /// <example>4.9</example>
        public string AverageRating { get; init; } = string.Empty;

        /// <summary>Total reviews. Required, non-negative number</summary>
        /// <example>1853</example>
        public int Votes { get; init; }
    }
}
