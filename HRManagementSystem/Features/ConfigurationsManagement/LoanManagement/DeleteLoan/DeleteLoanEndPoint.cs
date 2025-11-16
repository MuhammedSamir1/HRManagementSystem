using HRManagementSystem.Features.ConfigurationsManagement.LoanManagement.DeleteLoan.Commands;

namespace HRManagementSystem.Features.ConfigurationsManagement.LoanManagement.DeleteLoan
{
    [ApiGroup("Configurations Management", "Loan Management")]
    public class DeleteLoanEndPoint : BaseEndPoint<Guid, ResponseViewModel<bool>>
    {
        public DeleteLoanEndPoint(EndPointBaseParameters<Guid> parameters) : base(parameters) { }

        [HttpDelete("{id:int}")]
        public async Task<ResponseViewModel<bool>> DeleteLoan(Guid id, CancellationToken ct)
        {
            var command = new DeleteLoanCommand(id);
            var result = await _mediator.Send(command, ct);

            if (!result.isSuccess)
            {
                return ResponseViewModel<bool>.Failure(result.message, result.errorCode);
            }

            return ResponseViewModel<bool>.Success(true, result.message);
        }
    }
}




