using HRManagementSystem.Features.TeamManagement.DeleteTeam.Commands;

namespace HRManagementSystem.Features.TeamManagement.DeleteTeam
{
    public class DeleteTeamEndPoint : BaseEndPoint<DeleteTeamViewModel, ResponseViewModel<bool>>
    {
        public DeleteTeamEndPoint(EndPointBaseParameters<DeleteTeamViewModel> parameters)
            : base(parameters) { }

        [HttpDelete]
        public async Task<ResponseViewModel<bool>> DeleteBranch(DeleteTeamViewModel model, CancellationToken ct)
        {
            var validationResult = ValidateRequest(model);
            if (!validationResult.isSuccess)
                return ResponseViewModel<bool>.Failure(validationResult.errorCode);

            var isDeleted = await _mediator.Send(new DeleteTeamCommand(model.Id));
            if (!isDeleted.isSuccess) return ResponseViewModel<bool>.Failure(isDeleted.message,
                ErrorCode.TeamWasNotDeleted);

            return ResponseViewModel<bool>.Success(isDeleted.isSuccess, "Team Deleted Successfully!");
        }
    }
}
