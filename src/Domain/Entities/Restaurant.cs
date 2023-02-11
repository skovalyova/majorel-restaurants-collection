namespace Majorel.RestaurantsCollection.Domain.Entities
{
    public record Restaurant(int Id, string City, string Name, int EstimatedCost, double AverageRating, int Votes);
}
