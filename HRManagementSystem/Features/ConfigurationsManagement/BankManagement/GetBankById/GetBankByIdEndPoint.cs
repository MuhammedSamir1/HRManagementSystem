using HRManagementSystem.Features.BankManagement.GetBankById.Queries;

namespace HRManagementSystem.Features.BankManagement.GetBankById
{
    [ApiGroup("Configurations Management", "Bank Management")]
    public class GetBankByIdEndPoint : BaseEndPoint<GetBankByIdRequestViewModel, ResponseViewModel<GetBankByIdResponseViewModel>>
    {
        public GetBankByIdEndPoint(EndPointBaseParameters<GetBankByIdRequestViewModel> parameters) : base(parameters)
        {
        }

        [HttpGet("GetById")]
        public async Task<ResponseViewModel<GetBankByIdResponseViewModel>> GetBankById([FromQuery] GetBankByIdRequestViewModel request, CancellationToken ct)
        {
            var validationResult = ValidateRequest(request);
            if (!validationResult.isSuccess)
            {
                return ResponseViewModel<GetBankByIdResponseViewModel>.Failure(validationResult.errorCode);
            }

            var result = await _mediator.Send(new GetBankByIdQuery(request.Id), ct);

            if (!result.isSuccess || result.data == null)
                return ResponseViewModel<GetBankByIdResponseViewModel>.Failure(ErrorCode.NotFound);

            var responseViewModel = _mapper.Map<GetBankByIdResponseViewModel>(result.data);

            return ResponseViewModel<GetBankByIdResponseViewModel>.Success(responseViewModel, "Bank returned successfully!");
        }
    }
}

