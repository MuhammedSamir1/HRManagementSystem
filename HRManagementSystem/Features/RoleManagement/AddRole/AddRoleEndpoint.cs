using HRManagementSystem.Features.RoleManagement.AddRole.Commands;

namespace HRManagementSystem.Features.RoleManagement.AddRole
{
    [ApiGroup("Role Management")]
    public class AddRoleEndpoint : BaseEndPoint<AddRoleRequestViewModel, ResponseViewModel<bool>>
    {
        public AddRoleEndpoint(EndPointBaseParameters<AddRoleRequestViewModel> parameters) : base(parameters)
        {
        }

        [HttpPost("AddRole")]
        public async Task<ResponseViewModel<bool>> AddRole([FromQuery] AddRoleRequestViewModel model, CancellationToken ct)
        {
            var validationResult = ValidateRequest(model);
            if (!validationResult.isSuccess)
            {
                return ResponseViewModel<bool>.Failure(validationResult.errorCode);
            }

            var result = await _mediator.Send(new AddRoleCommand(model.Name), ct);

            if (!result.isSuccess) return ResponseViewModel<bool>.Failure(result.errorCode);
            return ResponseViewModel<bool>.Success(true, "Role Added Successfully!");
        }
    }
}

