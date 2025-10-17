using AutoMapper;
using HRManagementSystem.Data.Models;
using HRManagementSystem.Data.Repositories;
using MediatR;

namespace HRManagementSystem.Common.BaseRequestHandler
{
    public class RequestHandlerBaseParameters<TEntity, TKey> where TEntity : BaseModel<TKey>
    {
        private readonly IMediator _mediator;
        private readonly IGeneralRepository<TEntity, TKey> _generalRepo;
        private readonly IMapper _mapper;

        public IMediator Mediator => _mediator;
        public IGeneralRepository<TEntity, TKey> GeneralRepository => _generalRepo;
        public IMapper Mapper => _mapper;

        public RequestHandlerBaseParameters(IMediator mediator, IGeneralRepository<TEntity, TKey> generalRepository,
            IMapper mapper)
        {
            _mediator = mediator;
            _generalRepo = generalRepository;
            _mapper = mapper;
        }
    }
}
