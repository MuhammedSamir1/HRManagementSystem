using HRManagementSystem.Features.ConfigurationsManagement.LoanManagement.DeleteLoan.Commands;

namespace HRManagementSystem.Features.ConfigurationsManagement.LoanManagement.DeleteLoan
{
    public class DeleteLoanEndPoint : EndPointBase<DeleteLoanViewModel, DeleteLoanCommand, RequestResult<string>>
    {
        private readonly IMediator _mediator;

        public DeleteLoanEndPoint(EndPointBaseParameters parameters, IMediator mediator) : base(parameters)
        {
            _mediator = mediator;
        }

        [HttpDelete("api/Loan/Delete")]
        public override async Task<ActionResult<ResponseViewModel<RequestResult<string>>>> HandleAsync([FromQuery] DeleteLoanViewModel viewModel, CancellationToken ct)
        {
            var command = _mapper.Map<DeleteLoanViewModel, DeleteLoanCommand>(viewModel);
            var result = await _mediator.Send(command, ct);
            return result.ToActionResult(_mapper);
        }
    }
}
