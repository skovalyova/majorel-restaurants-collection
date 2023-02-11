using FluentAssertions;
using Majorel.RestaurantsCollection.API.Tests.Integration.Extensions;
using System.Net;
using System.Text;

namespace Majorel.RestaurantsCollection.API.Tests.Integration
{
    public sealed class CreateRestaurantTests : IClassFixture<RestaurantWebApplicationFactory>, IDisposable
    {
        private readonly HttpClient _client;
        private readonly RestaurantWebApplicationFactory _factory;

        public CreateRestaurantTests(RestaurantWebApplicationFactory factory)
        {
            _client = factory.CreateClient();
            _factory = factory;
        }

        [Fact]
        public async Task CreateRestaurant_ShouldReturnNewlyCreatedRestaurant_WhenValidRequest()
        {
            // Arrange
            var requestUri = new Uri($"restaurant", UriKind.Relative);

            var requestJson = await File.ReadAllTextAsync("Data/create-restaurant-body.json");
            var requestBody = new StringContent(requestJson, Encoding.UTF8, "application/json");

            var expectedResponse = (await File.ReadAllTextAsync("Data/create-restaurant-response.json")).Minify();

            // Act
            var httpResponse = await _client.PostAsync(requestUri, requestBody);

            // Assert
            httpResponse.StatusCode.Should().Be(HttpStatusCode.Created);
            httpResponse.Headers.Location.Should().NotBeNull();

            var content = await httpResponse.Content.ReadAsStringAsync();
            content.Should().BeEquivalentTo(expectedResponse);
        }

        public void Dispose()
        {
            _client.Dispose();

            GC.SuppressFinalize(this);
        }
    }
}
