using HRManagementSystem.Features.ConfigurationsManagement.LoanManagement.AddLoan.Commands;

namespace HRManagementSystem.Features.ConfigurationsManagement.LoanManagement.AddLoan
{
    public class AddLoanEndPoint : BaseEndPoint<AddLoanViewModel, ResponseViewModel<int>>
    {
        public AddLoanEndPoint(EndPointBaseParameters<AddLoanViewModel> parameters) : base(parameters) { }

        [HttpPost]
        public async Task<ResponseViewModel<int>> AddLoan([FromBody] AddLoanViewModel model, CancellationToken ct)
        {
            var command = _mapper.Map<AddLoanCommand>(model);
            var result = await _mediator.Send(command, ct);

            if (!result.isSuccess)
            {
                return ResponseViewModel<int>.Failure(result.message, result.errorCode);
            }

            return ResponseViewModel<int>.Success(result.data, result.message);
        }
    }
}
