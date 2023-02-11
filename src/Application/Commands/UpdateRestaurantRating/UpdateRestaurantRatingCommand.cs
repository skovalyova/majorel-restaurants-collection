namespace Majorel.RestaurantsCollection.Application.Commands.UpdateRestaurantRating;

public record UpdateRestaurantRatingCommand(int Id, string AverageRating, int Votes);
