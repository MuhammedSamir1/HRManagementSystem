using HRManagementSystem.Features.BranchManagement.UpdateBranch.Commands;
using HRManagementSystem.Features.Common.AddressManagement.UpdateAddressDtosAndVms.Dtos;

namespace HRManagementSystem.Features.BranchManagement.UpdateBranch
{
    public class UpdateBranchEndPoint : BaseEndPoint<UpdateBranchViewModel, RequestResult<bool>>
    {
        public UpdateBranchEndPoint(EndPointBaseParameters<UpdateBranchViewModel> parameters) : base(parameters) { }

        [HttpPut("update")]
        public async Task<ResponseViewModel<bool>> UpdateBranch([FromQuery] UpdateBranchViewModel model, CancellationToken ct)
        {
            var validationResult = ValidateRequest(model);
            if (!validationResult.isSuccess)
            {
                return ResponseViewModel<bool>.Failure(validationResult.errorCode);
            }

            var address = _mapper.Map<UpdateBranchAddressDto>(model.Address);
            var result = await _mediator.Send(new UpdateBranchCommand(model.Id, model.Name, model.Description,
                 model.Code, address));

            if (!result.isSuccess) return ResponseViewModel<bool>.Failure(result.message, result.errorCode);
            return ResponseViewModel<bool>.Success(result.isSuccess, "Branch Updated Successfully!");
        }
    }
}
