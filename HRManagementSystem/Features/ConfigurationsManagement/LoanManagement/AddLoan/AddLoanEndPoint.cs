using HRManagementSystem.Features.ConfigurationsManagement.LoanManagement.AddLoan.Commands;

namespace HRManagementSystem.Features.ConfigurationsManagement.LoanManagement.AddLoan
{
    public class AddLoanEndPoint : EndPointBase<AddLoanViewModel, AddLoanCommand, RequestResult<CreatedIdDto>>
    {
        private readonly IMediator _mediator;

        public AddLoanEndPoint(EndPointBaseParameters parameters, IMediator mediator) : base(parameters)
        {
            _mediator = mediator;
        }

        [HttpPost("api/Loan/Add")]
        public override async Task<ActionResult<ResponseViewModel<RequestResult<CreatedIdDto>>>> HandleAsync([FromBody] AddLoanViewModel viewModel, CancellationToken ct)
        {
            var command = _mapper.Map<AddLoanViewModel, AddLoanCommand>(viewModel);
            var result = await _mediator.Send(command, ct);
            return result.ToActionResult(_mapper);
        }
    }
}
