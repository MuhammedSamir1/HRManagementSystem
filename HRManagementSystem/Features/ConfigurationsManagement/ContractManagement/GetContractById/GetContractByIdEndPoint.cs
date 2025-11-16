using HRManagementSystem.Features.ConfigurationsManagement.ContractManagement.GetContractById;
using HRManagementSystem.Features.ConfigurationsManagement.ContractManagement.GetContractById.Queries;

namespace HRManagementSystem.Features.Configurations.ContractManagement.GetContractById
{
    [ApiGroup("Configurations Management", "Contract Management")]
    public class GetContractByIdEndPoint : BaseEndPoint<GetContractByIdRequestViewModel, ResponseViewModel<GetContractByIdResponseViewModel>>
    {
        public GetContractByIdEndPoint(EndPointBaseParameters<GetContractByIdRequestViewModel> parameters) : base(parameters)
        {
        }

        [HttpGet("GetById")]
        public async Task<ResponseViewModel<GetContractByIdResponseViewModel>> GetContractById([FromQuery] GetContractByIdRequestViewModel request, CancellationToken ct)
        {
            var validationResult = ValidateRequest(request);
            if (!validationResult.isSuccess)
            {
                return ResponseViewModel<GetContractByIdResponseViewModel>.Failure(validationResult.errorCode);
            }

            var result = await _mediator.Send(new GetContractByIdQuery(request.Id), ct);

            if (!result.isSuccess || result.data == null)
                return ResponseViewModel<GetContractByIdResponseViewModel>.Failure(ErrorCode.NotFound);

            var responseViewModel = _mapper.Map<GetContractByIdResponseViewModel>(result.data);

            return ResponseViewModel<GetContractByIdResponseViewModel>.Success(responseViewModel, "Contract returned successfully!");
        }
    }
}




