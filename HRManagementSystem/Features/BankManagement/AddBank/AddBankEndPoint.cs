using HRManagementSystem.Features.BankManagement.AddBank.Commands;

namespace HRManagementSystem.Features.BankManagement.AddBank
{
    public class AddBankEndPoint : BaseEndPoint<AddBankRequestViewModel, ResponseViewModel<bool>>
    {
        public AddBankEndPoint(EndPointBaseParameters<AddBankRequestViewModel> parameters) : base(parameters)
        {
        }

        [HttpPost("add")]
        public async Task<ResponseViewModel<bool>> AddBank([FromQuery] AddBankRequestViewModel request, CancellationToken ct)
        {
            var validationResult = ValidateRequest(request);
            if (!validationResult.isSuccess)
            {
                return ResponseViewModel<bool>.Failure(validationResult.errorCode);
            }

            var result = await _mediator.Send(new AddBankCommand(request.Name, request.Code, request.Address), ct);

            if (!result.isSuccess) return ResponseViewModel<bool>.Failure(result.errorCode);
            return ResponseViewModel<bool>.Success(true, "Bank Added Successfully!");
        }
    }
}

