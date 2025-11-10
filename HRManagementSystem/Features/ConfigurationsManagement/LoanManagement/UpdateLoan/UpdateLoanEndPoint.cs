using HRManagementSystem.Features.ConfigurationsManagement.LoanManagement.UpdateLoan.Commands;

namespace HRManagementSystem.Features.ConfigurationsManagement.LoanManagement.UpdateLoan
{
    public class UpdateLoanEndPoint : BaseEndPoint<UpdateLoanViewModel, ResponseViewModel<bool>>
    {
        public UpdateLoanEndPoint(EndPointBaseParameters<UpdateLoanViewModel> parameters) : base(parameters) { }

        [HttpPut]
        public async Task<ResponseViewModel<bool>> UpdateLoan([FromBody] UpdateLoanViewModel model, CancellationToken ct)
        {
            var command = _mapper.Map<UpdateLoanCommand>(model);
            var result = await _mediator.Send(command, ct);

            if (!result.isSuccess)
            {
                return ResponseViewModel<bool>.Failure(result.message, result.errorCode);
            }

            return ResponseViewModel<bool>.Success(true, result.message);
        }
    }
}
