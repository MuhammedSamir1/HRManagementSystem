using HRManagementSystem.Features.TeamManagement.AddTeam.Commands;

namespace HRManagementSystem.Features.TeamManagement.AddTeam
{
    public class AddTeamEndPoint : BaseEndPoint<AddTeamViewModel, ResponseViewModel<bool>>
    {
        public AddTeamEndPoint(EndPointBaseParameters<AddTeamViewModel> parameters)
            : base(parameters) { }

        [HttpPost]
        public async Task<ResponseViewModel<bool>> AddTeam([FromQuery] AddTeamViewModel model, CancellationToken ct)
        {
            var validationResult = ValidateRequest(model);
            if (!validationResult.isSuccess)
            {
                return ResponseViewModel<bool>.Failure(validationResult.errorCode);
            }

            var result = await _mediator.Send(new AddTeamCommand(model.Name, model.Code, model.Description,
                model.DepartmentId), ct);


            if (!result.isSuccess) return ResponseViewModel<bool>.Failure(result.message, result.errorCode);
            return ResponseViewModel<bool>.Success(true, "Team Added Successfully!");
        }
    }
}
