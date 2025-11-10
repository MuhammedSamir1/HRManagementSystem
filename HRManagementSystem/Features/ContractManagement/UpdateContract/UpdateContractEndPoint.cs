using HRManagementSystem.Features.ContractManagement.UpdateContract.Commands;

namespace HRManagementSystem.Features.ContractManagement.UpdateContract
{
    public class UpdateContractEndPoint : BaseEndPoint<UpdateContractRequestViewModel, ResponseViewModel<bool>>
    {
        public UpdateContractEndPoint(EndPointBaseParameters<UpdateContractRequestViewModel> parameters) : base(parameters)
        {
        }

        [HttpPut("update")]
        public async Task<ResponseViewModel<bool>> UpdateContract([FromQuery] UpdateContractRequestViewModel request, CancellationToken ct)
        {
            var validationResult = ValidateRequest(request);
            if (!validationResult.isSuccess)
            {
                return ResponseViewModel<bool>.Failure(validationResult.errorCode);
            }

            var result = await _mediator.Send(new UpdateContractCommand(
                request.Id,
                request.ContractNumber,
                request.Title,
                request.Description,
                request.StartDate,
                request.EndDate,
                request.ContractValue,
                request.ContractType,
                request.Status,
                request.EmployeeId,
                request.Terms), ct);

            if (!result.isSuccess) return ResponseViewModel<bool>.Failure(result.message, result.errorCode);
            return ResponseViewModel<bool>.Success(true, "Contract Updated Successfully!");
        }
    }
}

