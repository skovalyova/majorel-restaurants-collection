using FluentValidation;

namespace Majorel.RestaurantsCollection.Application.Queries.GetAllRestaurants
{
    public class GetAllRestaurantsQueryValidator : AbstractValidator<GetAllRestaurantsQuery>
    {
        public GetAllRestaurantsQueryValidator()
        {
        }
    }
}
