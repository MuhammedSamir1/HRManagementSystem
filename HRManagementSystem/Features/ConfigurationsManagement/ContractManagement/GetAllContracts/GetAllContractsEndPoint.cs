using HRManagementSystem.Features.ConfigurationsManagement.ContractManagement.GetAllContracts.Queries;

namespace HRManagementSystem.Features.ConfigurationsManagement.ContractManagement.GetAllContracts
{
    public class GetAllContractsEndPoint : BaseEndPoint<GetAllContractsRequestViewModel, ResponseViewModel<IEnumerable<GetAllContractsResponseViewModel>>>
    {
        public GetAllContractsEndPoint(EndPointBaseParameters<GetAllContractsRequestViewModel> parameters) : base(parameters)
        {
        }

        [HttpGet("GetAll")]
        public async Task<ResponseViewModel<IEnumerable<GetAllContractsResponseViewModel>>> GetAllContracts([FromQuery] GetAllContractsRequestViewModel request, CancellationToken ct)
        {
            var validationResult = ValidateRequest(request);
            if (!validationResult.isSuccess)
            {
                return ResponseViewModel<IEnumerable<GetAllContractsResponseViewModel>>.Failure(validationResult.errorCode);
            }

            var result = await _mediator.Send(new GetAllContractsQuery(), ct);

            if (!result.isSuccess || result.data == null || !result.data.Any())
                return ResponseViewModel<IEnumerable<GetAllContractsResponseViewModel>>.Failure(ErrorCode.NotFound);

            var responseViewModel = _mapper.Map<IEnumerable<GetAllContractsResponseViewModel>>(result.data);

            return ResponseViewModel<IEnumerable<GetAllContractsResponseViewModel>>.Success(responseViewModel, "Contracts returned successfully!");
        }
    }
}

