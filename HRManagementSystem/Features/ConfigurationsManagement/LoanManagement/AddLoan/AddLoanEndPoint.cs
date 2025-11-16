using HRManagementSystem.Features.ConfigurationsManagement.LoanManagement.AddLoan.Commands;

namespace HRManagementSystem.Features.ConfigurationsManagement.LoanManagement.AddLoan
{
    [ApiGroup("Configurations Management", "Loan Management")]
    public class AddLoanEndPoint : BaseEndPoint<AddLoanViewModel, ResponseViewModel<Guid>>
    {
        public AddLoanEndPoint(EndPointBaseParameters<AddLoanViewModel> parameters) : base(parameters) { }

        [HttpPost]
        public async Task<ResponseViewModel<Guid>> AddLoan([FromBody] AddLoanViewModel model, CancellationToken ct)
        {
            var command = _mapper.Map<AddLoanCommand>(model);
            var result = await _mediator.Send(command, ct);

            if (!result.isSuccess)
            {
                return ResponseViewModel<Guid>.Failure(result.message, result.errorCode);
            }

            return ResponseViewModel<Guid>.Success(result.data, result.message);
        }
    }
}




