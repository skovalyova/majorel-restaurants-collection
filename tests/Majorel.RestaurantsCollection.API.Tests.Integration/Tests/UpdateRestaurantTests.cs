using Majorel.RestaurantsCollection.API.Tests.Integration.Extensions;
using System.Net;
using System.Text;

namespace Majorel.RestaurantsCollection.API.Tests.Integration.Tests
{
    [Collection(nameof(RestaurantWebApplicationFactory<Program>))]
    public class UpdateRestaurantTests : BaseTest
    {
        public UpdateRestaurantTests() : base() { }

        [Fact]
        public async Task UpdateRestaurant_ReturnsUpdatedRestaurant()
        {
            // Arrange
            const int id = 2;
            var requestUri = new Uri($"restaurant/{id}", UriKind.Relative);

            var requestJson = await File.ReadAllTextAsync("Data/update-restaurant-body.json");
            var requestBody = new StringContent(requestJson, Encoding.UTF8, "application/json");

            var expectedResponse = (await File.ReadAllTextAsync("Data/update-restaurant-response.json")).Minify();

            // Act
            var httpResponse = await Client.PutAsync(requestUri, requestBody);

            // Assert
            httpResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var content = await httpResponse.Content.ReadAsStringAsync();
            content.Should().BeEquivalentTo(expectedResponse);
        }
    }
}
