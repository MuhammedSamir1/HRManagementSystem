using HRManagementSystem.Features.BankManagement.GetAllBanks.Queries;

namespace HRManagementSystem.Features.BankManagement.GetAllBanks
{
    public class GetAllBanksEndPoint : BaseEndPoint<GetAllBanksRequestViewModel, ResponseViewModel<IEnumerable<GetAllBanksResponseViewModel>>>
    {
        public GetAllBanksEndPoint(EndPointBaseParameters<GetAllBanksRequestViewModel> parameters) : base(parameters)
        {
        }

        [HttpGet("GetAll")]
        public async Task<ResponseViewModel<IEnumerable<GetAllBanksResponseViewModel>>> GetAllBanks([FromQuery] GetAllBanksRequestViewModel request, CancellationToken ct)
        {
            var validationResult = ValidateRequest(request);
            if (!validationResult.isSuccess)
            {
                return ResponseViewModel<IEnumerable<GetAllBanksResponseViewModel>>.Failure(validationResult.errorCode);
            }

            var result = await _mediator.Send(new GetAllBanksQuery(), ct);

            if (!result.isSuccess || result.data == null || !result.data.Any())
                return ResponseViewModel<IEnumerable<GetAllBanksResponseViewModel>>.Failure(ErrorCode.NotFound);

            var responseViewModel = _mapper.Map<IEnumerable<GetAllBanksResponseViewModel>>(result.data);

            return ResponseViewModel<IEnumerable<GetAllBanksResponseViewModel>>.Success(responseViewModel, "Banks returned successfully!");
        }
    }
}

