using HRManagementSystem.Features.ConfigurationsManagement.LoanManagement.UpdateLoan.Commands;

namespace HRManagementSystem.Features.ConfigurationsManagement.LoanManagement.UpdateLoan
{
    public class UpdateLoanEndPoint : EndPointBase<UpdateLoanViewModel, UpdateLoanCommand, RequestResult<string>>
    {
        private readonly IMediator _mediator;

        public UpdateLoanEndPoint(EndPointBaseParameters parameters, IMediator mediator) : base(parameters)
        {
            _mediator = mediator;
        }

        [HttpPut("api/Loan/Update")]
        public override async Task<ActionResult<ResponseViewModel<RequestResult<string>>>> HandleAsync([FromBody] UpdateLoanViewModel viewModel, CancellationToken ct)
        {
            var command = _mapper.Map<UpdateLoanViewModel, UpdateLoanCommand>(viewModel);
            var result = await _mediator.Send(command, ct);
            return result.ToActionResult(_mapper);
        }
    }
}
