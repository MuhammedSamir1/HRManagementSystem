using HRManagementSystem.Features.CurrencyManagement.GetAllCurrency.Queries;

namespace HRManagementSystem.Features.CurrencyManagement.GetAllCurrency
{
    public class GetAllCurrencyEndPoint : BaseEndPoint<GetAllCurrencyRequestViewModel, ResponseViewModel<IEnumerable<GetAllCurrencyResponseViewModel>>>
    {
        public GetAllCurrencyEndPoint(EndPointBaseParameters<GetAllCurrencyRequestViewModel> parameters) : base(parameters)
        {
        }

        [HttpGet("GetAll")]
        public async Task<ResponseViewModel<IEnumerable<GetAllCurrencyResponseViewModel>>> GetAllCurrency([FromQuery] GetAllCurrencyRequestViewModel request, CancellationToken ct)
        {
            var validationResult = ValidateRequest(request);
            if (!validationResult.isSuccess)
            {
                return ResponseViewModel<IEnumerable<GetAllCurrencyResponseViewModel>>.Failure(validationResult.errorCode);
            }

            var result = await _mediator.Send(new GetAllCurrencyQuery(), ct);

            if (!result.isSuccess || result.data == null || !result.data.Any())
                return ResponseViewModel<IEnumerable<GetAllCurrencyResponseViewModel>>.Failure(ErrorCode.NotFound);

            var responseViewModel = _mapper.Map<IEnumerable<GetAllCurrencyResponseViewModel>>(result.data);

            return ResponseViewModel<IEnumerable<GetAllCurrencyResponseViewModel>>.Success(responseViewModel, "Companies returned successfully!");
        }

    }
}
