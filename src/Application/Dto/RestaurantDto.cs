namespace Majorel.RestaurantsCollection.Application.Dto
{
    public record RestaurantDto(int Id, string City, string Name, int EstimatedCost, string AverageRating, int Votes);
}
