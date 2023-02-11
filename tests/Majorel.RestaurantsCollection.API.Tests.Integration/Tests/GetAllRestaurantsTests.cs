using FluentAssertions;
using Majorel.RestaurantsCollection.API.Tests.Integration.Extensions;
using System.Net;

namespace Majorel.RestaurantsCollection.API.Tests.Integration.Tests
{
    [Collection(nameof(RestaurantWebApplicationFactory<Program>))]
    public class GetAllRestaurantsTests : BaseTest
    {
        public GetAllRestaurantsTests() : base() { }

        [Fact]
        public async Task GetAllRestaurants_ShouldReturnAllRestaurants_WhenTheyExist()
        {
            // Arrange
            var requestUri = new Uri($"restaurant", UriKind.Relative);

            var expectedResponse = (await File.ReadAllTextAsync("Data/get-all-restaurants-response.json")).Minify();

            // Act
            var httpResponse = await Client.GetAsync(requestUri);

            // Assert
            httpResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var content = await httpResponse.Content.ReadAsStringAsync();
            content.Should().BeEquivalentTo(expectedResponse);
        }
    }
}
