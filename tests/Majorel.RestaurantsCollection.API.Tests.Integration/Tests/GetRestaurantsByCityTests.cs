using Majorel.RestaurantsCollection.API.Tests.Integration.Extensions;
using System.Net;

namespace Majorel.RestaurantsCollection.API.Tests.Integration.Tests
{
    [Collection(nameof(RestaurantWebApplicationFactory<Program>))]
    public class GetRestaurantsByCityTests : BaseTest
    {
        public GetRestaurantsByCityTests() : base() { }

        [Fact]
        public async Task GetRestaurantsByCity_ReturnsAllRestaurantsInSpecifiedCity()
        {
            // Arrange
            const string city = "Minsk";
            var requestUri = new Uri($"restaurant/query?city={city}", UriKind.Relative);

            var expectedResponse = (await File.ReadAllTextAsync("Data/get-restaurants-by-city-response.json")).Minify();

            // Act
            var httpResponse = await Client.GetAsync(requestUri);

            // Assert
            httpResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var content = await httpResponse.Content.ReadAsStringAsync();
            content.Should().BeEquivalentTo(expectedResponse);
        }
    }
}
