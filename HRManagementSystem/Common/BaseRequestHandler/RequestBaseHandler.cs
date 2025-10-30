using HRManagementSystem.Common.Views;
using HRManagementSystem.Data.Repositories;

namespace HRManagementSystem.Common.BaseRequestHandler
{
    public abstract class RequestHandlerBase<TRequest, TResponse, TEntity, TKey> :
        IRequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse> where TEntity : BaseModel<TKey>
    {
        protected readonly IMediator _mediator;
        protected readonly UserState _userState;
        protected readonly IGeneralRepository<TEntity, TKey> _generalRepo;
        protected readonly IMapper _mapper;

        public RequestHandlerBase(RequestHandlerBaseParameters<TEntity, TKey> parameters)
        {
            _mediator = parameters.Mediator;
            _userState = parameters.UserState;
            _generalRepo = parameters.GeneralRepository;
            _mapper = parameters.Mapper;
        }
        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
    }
}
