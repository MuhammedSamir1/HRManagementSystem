using HRManagementSystem.Features.TeamManagement.GetTeamById.Queries;

namespace HRManagementSystem.Features.TeamManagement.GetTeamById
{
    public class GetTeamByIdEndPoint : BaseEndPoint<GetTeamByIdViewModel,
       ResponseViewModel<ViewTeamByIdViewModel>>
    {
        public GetTeamByIdEndPoint(EndPointBaseParameters<GetTeamByIdViewModel> parameters)
            : base(parameters) { }

        [HttpGet("id")]
        public async Task<ResponseViewModel<ViewTeamByIdViewModel>> GetById([FromQuery] GetTeamByIdViewModel model)
        {
            var validationResult = ValidateRequest(model);
            if (!validationResult.isSuccess)
            {
                return ResponseViewModel<ViewTeamByIdViewModel>.Failure(validationResult.errorCode);
            }

            var team = await _mediator.Send(new GetTeamByIdQuery(model.Id));

            if (team is null) return ResponseViewModel<ViewTeamByIdViewModel>.Failure(team.message,
                ErrorCode.TeamNotFound);

            var vm = _mapper.Map<ViewTeamByIdViewModel>(team.data);
            return ResponseViewModel<ViewTeamByIdViewModel>.Success(vm);
        }
    }
}
