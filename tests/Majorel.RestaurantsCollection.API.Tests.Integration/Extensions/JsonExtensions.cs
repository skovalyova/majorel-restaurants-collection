using System.Text.Json;
using static System.Text.Json.JsonSerializer;

namespace Majorel.RestaurantsCollection.API.Tests.Integration.Extensions
{
    public static class JsonExtensions
    {
        public static string Minify(this string json) =>
            Serialize(Deserialize<JsonDocument>(json));
    }
}
