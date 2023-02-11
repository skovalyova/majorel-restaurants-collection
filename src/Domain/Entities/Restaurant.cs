namespace Majorel.RestaurantsCollection.Domain.Entities
{
    public class Restaurant
    {
        public int Id { get; set; }

        public string City { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public int EstimatedCost { get; set; }

        public double AverageRating { get; set; }

        public int Votes { get; set; }
    }
}
