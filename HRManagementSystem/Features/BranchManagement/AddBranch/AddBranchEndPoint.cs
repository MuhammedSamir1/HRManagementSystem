using HRManagementSystem.Features.BranchManagement.AddBranch.Commands;
using HRManagementSystem.Features.Common.AddressManagement.AddAddressDtoAndVms.Dtos;

namespace HRManagementSystem.Features.BranchManagement.AddBranch
{
    public class AddBranchEndPoint : BaseEndPoint<AddBranchViewModel, ResponseViewModel<bool>>
    {
        public AddBranchEndPoint(EndPointBaseParameters<AddBranchViewModel> parameters)
            : base(parameters) { }

        [HttpPost]
        public async Task<ResponseViewModel<bool>> AddBranch([FromQuery] AddBranchViewModel model, CancellationToken ct)
        {
            var validationResult = ValidateRequest(model);
            if (!validationResult.isSuccess)
            {
                return ResponseViewModel<bool>.Failure(validationResult.errorCode);
            }

            var address = _mapper.Map<AddBranchAddressDto>(model.Address);
            var result = await _mediator.Send(new AddBranchCommand(model.Name, model.Description, model.CompanyId,
                model.Code, address), ct);

            if (!result.isSuccess) return ResponseViewModel<bool>.Failure(result.message, result.errorCode);
            return ResponseViewModel<bool>.Success(true, "Branch Added Successfully!");
        }
    }
}
