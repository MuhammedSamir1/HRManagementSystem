using AutoMapper;
using HRManagementSystem.Data.Models;
using HRManagementSystem.Data.Repositories;
using MediatR;

namespace HRManagementSystem.Common.BaseRequestHandler
{
    public abstract class RequestHandlerBase<TRequest, TResponse, TEntity> :
        IRequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse> where TEntity : BaseModel
    {
        protected readonly IMediator _mediator;
        protected readonly IGeneralRepository<TEntity> _generalRepo;
        protected readonly IMapper _mapper;

        public RequestHandlerBase(RequestHandlerBaseParameters<TEntity> parameters)
        {
            _mediator = parameters.Mediator;
            _generalRepo = parameters.GeneralRepository;
            _mapper = parameters.Mapper;
        }
        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
    }
}
