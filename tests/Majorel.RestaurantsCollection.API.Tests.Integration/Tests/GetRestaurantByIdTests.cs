using FluentAssertions;
using Majorel.RestaurantsCollection.API.Tests.Integration.Extensions;
using System.Net;

namespace Majorel.RestaurantsCollection.API.Tests.Integration.Tests
{
    [Collection(nameof(RestaurantWebApplicationFactory<Program>))]
    public class GetRestaurantByIdTests : BaseTest
    {
        public GetRestaurantByIdTests() : base() { }

        [Fact]
        public async Task GetRestaurantById_ShouldReturnRestaurant_WhenItExists()
        {
            // Arrange
            const int id = 1;
            var requestUri = new Uri($"restaurant/{id}", UriKind.Relative);

            var expectedResponse = (await File.ReadAllTextAsync("Data/get-restaurant-1-response.json")).Minify();

            // Act
            var httpResponse = await Client.GetAsync(requestUri);

            // Assert
            httpResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var content = await httpResponse.Content.ReadAsStringAsync();
            content.Should().BeEquivalentTo(expectedResponse);
        }
    }
}
