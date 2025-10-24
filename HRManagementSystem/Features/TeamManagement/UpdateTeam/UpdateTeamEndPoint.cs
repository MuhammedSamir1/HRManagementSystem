using HRManagementSystem.Common.BaseEndPoints;
using HRManagementSystem.Common.Views.Response;
using HRManagementSystem.Features.TeamManagement.UpdateTeam.Commands;
using Microsoft.AspNetCore.Mvc;

namespace HRManagementSystem.Features.TeamManagement.UpdateTeam
{
    public class UpdateTeamEndPoint : BaseEndPoint<UpdateTeamViewModel, RequestResult<bool>>
    {
        public UpdateTeamEndPoint(EndPointBaseParameters<UpdateTeamViewModel> parameters) : base(parameters) { }

        [HttpPut("update")]
        public async Task<ResponseViewModel<bool>> UpdateBranch([FromQuery] UpdateTeamViewModel model, CancellationToken ct)
        {
            var validationResult = ValidateRequest(model);
            if (!validationResult.isSuccess)
            {
                return ResponseViewModel<bool>.Failure(validationResult.errorCode);
            }

            var result = await _mediator.Send(new UpdateTeamCommand(model.Id, model.Name, model.Description,
                 model.Code, model.DepartmentId), ct);

            if (!result.isSuccess) return ResponseViewModel<bool>.Failure(result.message, result.errorCode);
            return ResponseViewModel<bool>.Success(result.isSuccess, "Team Updated Successfully!");
        }
    }
}
