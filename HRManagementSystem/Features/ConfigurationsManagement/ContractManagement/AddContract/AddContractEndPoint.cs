using HRManagementSystem.Features.ConfigurationsManagement.ContractManagement.AddContract;
using HRManagementSystem.Features.ConfigurationsManagement.ContractManagement.AddContract.Commands;

namespace HRManagementSystem.Features.Configurations.ContractManagement.AddContract
{
    [ApiGroup("Configurations Management", "Contract Management")]
    public class AddContractEndPoint : BaseEndPoint<AddContractRequestViewModel, ResponseViewModel<bool>>
    {
        public AddContractEndPoint(EndPointBaseParameters<AddContractRequestViewModel> parameters) : base(parameters)
        {
        }

        [HttpPost("add")]
        public async Task<ResponseViewModel<bool>> AddContract([FromQuery] AddContractRequestViewModel request, CancellationToken ct)
        {
            var validationResult = ValidateRequest(request);
            if (!validationResult.isSuccess)
            {
                return ResponseViewModel<bool>.Failure(validationResult.errorCode);
            }

            var result = await _mediator.Send(new AddContractCommand(
                request.ContractNumber,
                request.Title,
                request.Description,
                request.StartDate,
                request.EndDate,
                request.ContractValue,
                request.ContractType,
                request.Status,
                request.Terms), ct);

            if (!result.isSuccess) return ResponseViewModel<bool>.Failure(result.errorCode);
            return ResponseViewModel<bool>.Success(true, "Contract Added Successfully!");
        }
    }
}




