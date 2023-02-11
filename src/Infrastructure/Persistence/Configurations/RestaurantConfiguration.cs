using Majorel.RestaurantsCollection.Domain.Constants;
using Majorel.RestaurantsCollection.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Majorel.RestaurantsCollection.Infrastructure.Persistence.Configurations
{
    public class RestaurantConfiguration : IEntityTypeConfiguration<Restaurant>
    {
        public void Configure(EntityTypeBuilder<Restaurant> builder)
        {
            builder
                .Property(b => b.City)
                .IsRequired()
                .HasMaxLength(ValidationConstants.RestaurantNameMaxLength);

            builder
                .Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(ValidationConstants.RestaurantCityMaxLength);

            builder
                .Property(b => b.EstimatedCost)
                .IsRequired();

            builder
                .Property(b => b.Votes)
                .IsRequired();

            builder
                .Property(b => b.AverageRating)
                .IsRequired();
        }
    }
}
