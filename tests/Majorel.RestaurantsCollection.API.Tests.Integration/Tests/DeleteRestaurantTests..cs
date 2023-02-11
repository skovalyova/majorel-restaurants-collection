using System.Net;

namespace Majorel.RestaurantsCollection.API.Tests.Integration.Tests
{
    [Collection(nameof(RestaurantWebApplicationFactory<Program>))]
    public class DeleteRestaurantTests : BaseTest
    {
        public DeleteRestaurantTests() : base() { }

        [Fact]
        public async Task DeleteRestaurant_DeletesRestaurantFromCollection()
        {
            // Arrange
            const int id = 2;
            var requestUri = new Uri($"restaurant/{id}", UriKind.Relative);

            // Act
            var httpResponse = await Client.DeleteAsync(requestUri);

            // Assert
            httpResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var getByIdHttpResponse = await Client.GetAsync(requestUri);
            getByIdHttpResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}
