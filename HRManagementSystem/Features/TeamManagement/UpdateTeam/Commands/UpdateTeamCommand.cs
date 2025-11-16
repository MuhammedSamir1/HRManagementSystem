namespace HRManagementSystem.Features.TeamManagement.UpdateTeam.Commands
{
    public sealed record UpdateTeamCommand(Guid Id, string Name, string? Description, string Code, Guid DepartmentId)
        : IRequest<RequestResult<bool>>;

    public class UpdateTeamCommandHandler : RequestHandlerBase<UpdateTeamCommand, RequestResult<bool>, Team, Guid>
    {
        public UpdateTeamCommandHandler(RequestHandlerBaseParameters<Team, Guid> parameters) : base(parameters)
        {
        }

        public override async Task<RequestResult<bool>> Handle(UpdateTeamCommand request, CancellationToken ct)
        {
            //var isExist = await _mediator.Send(new IsTeamExistQuery(request.Id));
            //if (!isExist.isSuccess) return RequestResult<bool>.Failure("Branch not found.", ErrorCode.OrganizationNotFound);

            var nameExists = await _generalRepo.ExistsByNameAsync<Team>(request.Name);
            if (nameExists)
                return RequestResult<bool>.Failure("Team Name already exists.", ErrorCode.Conflict);

            var team = _mapper.Map<UpdateTeamCommand, Team>(request);
            var isUpdated = await _generalRepo.UpdatePartialAsync(team, null, ct);

            if (!isUpdated) return RequestResult<bool>.Failure("Team wasn't Updated successfully!", ErrorCode.InternalServerError);
            return RequestResult<bool>.Success(isUpdated, "Team Updated successfully!");
        }

    }
}

