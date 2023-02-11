using FluentAssertions;
using Majorel.RestaurantsCollection.API.Tests.Integration.Extensions;
using System.Net;
using System.Text;

namespace Majorel.RestaurantsCollection.API.Tests.Integration.Tests
{
    [Collection(nameof(RestaurantWebApplicationFactory<Program>))]
    public class CreateRestaurantTests : BaseTest
    {
        public CreateRestaurantTests() : base() { }

        [Fact]
        public async Task CreateRestaurant_ShouldReturnNewlyCreatedRestaurant_WhenValidRequest()
        {
            // Arrange
            var requestUri = new Uri($"restaurant", UriKind.Relative);

            var requestJson = await File.ReadAllTextAsync("Data/create-restaurant-body.json");
            var requestBody = new StringContent(requestJson, Encoding.UTF8, "application/json");

            var expectedResponse = (await File.ReadAllTextAsync("Data/create-restaurant-response.json")).Minify();

            // Act
            var httpResponse = await Client.PostAsync(requestUri, requestBody);

            // Assert
            httpResponse.StatusCode.Should().Be(HttpStatusCode.Created);
            httpResponse.Headers.Location.Should().NotBeNull();

            var content = await httpResponse.Content.ReadAsStringAsync();
            content.Should().BeEquivalentTo(expectedResponse);
        }
    }
}
