using MediatR;

namespace HRManagementSystem.Common.Views.RequestHandler
{
    public abstract class RequestHandlerBase<TRequest, TResponse> : IRequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        protected readonly IMediator _mediator;

        public RequestHandlerBase(RequestHandlerBaseParameters parameters)
        {
            _mediator = parameters.Mediator;
        }
        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
    }
}
