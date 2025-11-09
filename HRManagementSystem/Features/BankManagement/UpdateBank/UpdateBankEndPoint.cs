using HRManagementSystem.Features.BankManagement.UpdateBank.Commands;

namespace HRManagementSystem.Features.BankManagement.UpdateBank
{
    public class UpdateBankEndPoint : BaseEndPoint<UpdateBankRequestViewModel, ResponseViewModel<bool>>
    {
        public UpdateBankEndPoint(EndPointBaseParameters<UpdateBankRequestViewModel> parameters) : base(parameters)
        {
        }

        [HttpPut("update")]
        public async Task<ResponseViewModel<bool>> UpdateBank([FromQuery] UpdateBankRequestViewModel request, CancellationToken ct)
        {
            var validationResult = ValidateRequest(request);
            if (!validationResult.isSuccess)
            {
                return ResponseViewModel<bool>.Failure(validationResult.errorCode);
            }

            var result = await _mediator.Send(new UpdateBankCommand(request.Id, request.Name, request.Code, request.Address), ct);

            if (!result.isSuccess) return ResponseViewModel<bool>.Failure(result.message, result.errorCode);
            return ResponseViewModel<bool>.Success(true, "Bank Updated Successfully!");
        }
    }
}

