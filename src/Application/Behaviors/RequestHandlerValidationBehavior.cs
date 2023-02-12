using FluentValidation;
using MediatR;

namespace Majorel.RestaurantsCollection.Application.Behaviors
{
    public class RequestHandlerValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IValidator<TRequest> _validator;

        public RequestHandlerValidationBehavior(IValidator<TRequest> validator)
        {
            _validator = validator;
        }

        public Task<TResponse> Handle(
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken
        )
        {
            _validator.ValidateAndThrow(request);
            return next();
        }
    }
}
