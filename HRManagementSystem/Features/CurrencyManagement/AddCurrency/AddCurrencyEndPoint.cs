using HRManagementSystem.Features.CurrencyManagement.AddCurrency.Commands;

namespace HRManagementSystem.Features.CurrencyManagement.AddCurrency
{
    public class AddCurrencyEndPoint : BaseEndPoint<AddCurrencyRequestViewModel, ResponseViewModel<bool>>
    {
        public AddCurrencyEndPoint(EndPointBaseParameters<AddCurrencyRequestViewModel> parameters) : base(parameters)
        {
        }

        [HttpPost("add")]
        public async Task<ResponseViewModel<bool>> AddCurrency([FromQuery] AddCurrencyRequestViewModel request, CancellationToken ct)
        {
            var validationResult = ValidateRequest(request);
            if (!validationResult.isSuccess)
            {
                return ResponseViewModel<bool>.Failure(validationResult.errorCode);
            }

            var result = await _mediator.Send(new AddCurrencyCommand(request.Code, request.NumericCode, request.Name, request.Symbol), ct);

            if (!result.isSuccess) return ResponseViewModel<bool>.Failure(result.errorCode);
            return ResponseViewModel<bool>.Success(true, "Currency Added Successfully!");
        }
    }
}
