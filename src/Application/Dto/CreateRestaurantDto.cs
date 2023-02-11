namespace Majorel.RestaurantsCollection.Application.Dto
{
    public record CreateRestaurantDto(string City, string Name, int EstimatedCost, string AverageRating, int Votes);
}
