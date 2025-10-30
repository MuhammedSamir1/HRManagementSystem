using HRManagementSystem.Common.Views;
using HRManagementSystem.Data.Repositories;

namespace HRManagementSystem.Common.BaseRequestHandler
{
    public class RequestHandlerBaseParameters<TEntity, TKey> where TEntity : BaseModel<TKey>
    {
        private readonly IMediator _mediator;
        private readonly UserState _userState;
        private readonly IGeneralRepository<TEntity, TKey> _generalRepo;
        private readonly IMapper _mapper;

        public IMediator Mediator => _mediator;
        public UserState UserState => _userState;
        public IGeneralRepository<TEntity, TKey> GeneralRepository => _generalRepo;
        public IMapper Mapper => _mapper;

        public RequestHandlerBaseParameters(
            IMediator mediator,
            UserState userState,
            IGeneralRepository<TEntity, TKey> generalRepository,
            IMapper mapper)
        {
            _mediator = mediator;
            _userState = userState;
            _generalRepo = generalRepository;
            _mapper = mapper;
        }
    }
}
