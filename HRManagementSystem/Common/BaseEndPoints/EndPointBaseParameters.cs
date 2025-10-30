using FluentValidation;

namespace HRManagementSystem.Common.BaseEndPoints
{
    public class EndPointBaseParameters<TRequest>
    {
        private readonly IMediator _mediator;
        private readonly IValidator<TRequest> _validator;
        private readonly IMapper _mapper;

        public IMediator Mediator => _mediator;
        public IMapper Mapper => _mapper;
        public IValidator<TRequest> Validator => _validator;

        public EndPointBaseParameters(IMediator mediator, IValidator<TRequest> validator, IMapper mapper)

        {
            _mediator = mediator;
            _validator = validator;
            _mapper = mapper;
        }
    }
}
