using AutoMapper;
using HRManagementSystem.Data.Models;
using HRManagementSystem.Data.Repositories;
using MediatR;

namespace HRManagementSystem.Common.BaseRequestHandler
{
    public class RequestHandlerBaseParameters<TEntity> where TEntity : BaseModel
    {
        private readonly IMediator _mediator;
        private readonly IGeneralRepository<TEntity> _generalRepo;
        private readonly IMapper _mapper;

        public IMediator Mediator => _mediator;
        public IGeneralRepository<TEntity> GeneralRepository => _generalRepo;
        public IMapper Mapper => _mapper;

        public RequestHandlerBaseParameters(IMediator mediator, IGeneralRepository<TEntity> generalRepository, IMapper mapper)
        {
            _mediator = mediator;
            _generalRepo = generalRepository;
            _mapper = mapper;
        }
    }
}
