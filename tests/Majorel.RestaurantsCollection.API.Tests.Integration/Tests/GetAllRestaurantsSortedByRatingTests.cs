using Majorel.RestaurantsCollection.API.Tests.Integration.Extensions;
using System.Net;

namespace Majorel.RestaurantsCollection.API.Tests.Integration.Tests
{
    [Collection(nameof(RestaurantWebApplicationFactory<Program>))]
    public class GetAllRestaurantsSortedByRatingTests : BaseTest
    {
        public GetAllRestaurantsSortedByRatingTests() : base() { }

        [Fact]
        public async Task GetAllSortedRestaurants_ReturnsAllRestaurantsSortedByAverageRating()
        {
            // Arrange
            var requestUri = new Uri($"restaurant/sort", UriKind.Relative);

            var expectedResponse = (await File.ReadAllTextAsync("Data/get-all-restaurants-sorted-by-rating-response.json")).Minify();

            // Act
            var httpResponse = await Client.GetAsync(requestUri);

            // Assert
            httpResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var content = await httpResponse.Content.ReadAsStringAsync();
            content.Should().BeEquivalentTo(expectedResponse);
        }
    }
}
