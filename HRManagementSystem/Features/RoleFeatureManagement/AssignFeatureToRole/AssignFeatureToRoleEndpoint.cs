using HRManagementSystem.Features.RoleFeatureManagement.AssignFeatureToRole.Commands;

namespace HRManagementSystem.Features.RoleFeatureManagement.AssignFeatureToRole
{
    [ApiGroup("Role Feature Management")]
    public class AssignFeatureToRoleEndpoint : BaseEndPoint<AssignFeatureToRoleRequestViewModel, ResponseViewModel<bool>>
    {
        public AssignFeatureToRoleEndpoint(EndPointBaseParameters<AssignFeatureToRoleRequestViewModel> parameters) : base(parameters)
        {
        }

        [HttpPost("AssignFeatureToRole")]
        public async Task<ResponseViewModel<bool>> AssignFeatureToRole([FromQuery] AssignFeatureToRoleRequestViewModel model, CancellationToken ct)
        {
            var validationResult = ValidateRequest(model);
            if (!validationResult.isSuccess)
            {
                return ResponseViewModel<bool>.Failure(validationResult.errorCode);
            }

            var result = await _mediator.Send(new AssignFeatureToRoleCommand(model.RoleId, model.Feature), ct);

            if (!result.isSuccess) return ResponseViewModel<bool>.Failure(result.errorCode);
            return ResponseViewModel<bool>.Success(true, "Added Successfully!");
        }
    }
}

