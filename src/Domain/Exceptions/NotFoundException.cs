namespace Majorel.RestaurantsCollection.Domain.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string entityName, string entityId) : base($"Entity {entityName} with ID {entityId} is not found.") { }
    }
}
