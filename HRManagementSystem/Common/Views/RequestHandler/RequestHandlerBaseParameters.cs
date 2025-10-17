using MediatR;

namespace HRManagementSystem.Common.Views.RequestHandler
{
    public class RequestHandlerBaseParameters
    {
        private readonly IMediator _mediator;

        public IMediator Mediator => _mediator;
        public RequestHandlerBaseParameters(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
