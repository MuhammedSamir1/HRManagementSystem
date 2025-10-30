using HRManagementSystem.Features.TeamManagement.GetAllTeams.Queries;

namespace HRManagementSystem.Features.TeamManagement.GetAllTeams
{
    public class GetAllTeamsEndPoint : BaseEndPoint<GetAllTeamsViewModel,
       ResponseViewModel<ViewTeamViewModel>>
    {
        public GetAllTeamsEndPoint(EndPointBaseParameters<GetAllTeamsViewModel> parameters)
            : base(parameters) { }

        [HttpGet("id")]
        public async Task<ResponseViewModel<List<ViewTeamViewModel>>> GetById([FromQuery] GetAllTeamsViewModel model)
        {
            var validationResult = ValidateRequest(model);
            if (!validationResult.isSuccess)
            {
                return ResponseViewModel<List<ViewTeamViewModel>>.Failure(validationResult.errorCode);
            }

            var team = await _mediator.Send(new GetAllTeamsQuery());

            if (team is null) return ResponseViewModel<List<ViewTeamViewModel>>.Failure(team.message,
                ErrorCode.TeamNotFound);

            var vm = _mapper.Map<List<ViewTeamViewModel>>(team.data);
            return ResponseViewModel<List<ViewTeamViewModel>>.Success(vm);
        }
    }
}
