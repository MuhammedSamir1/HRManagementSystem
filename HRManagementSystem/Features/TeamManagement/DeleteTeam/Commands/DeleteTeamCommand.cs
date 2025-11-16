namespace HRManagementSystem.Features.TeamManagement.DeleteTeam.Commands
{
    public sealed record DeleteTeamCommand(Guid Id) : IRequest<RequestResult<bool>>;


    public sealed class DeleteTeamCommandHandler : RequestHandlerBase<DeleteTeamCommand,
        RequestResult<bool>, Team, Guid>
    {
        public DeleteTeamCommandHandler(RequestHandlerBaseParameters<Team, Guid> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<bool>> Handle(DeleteTeamCommand request, CancellationToken cancellationToken)
        {
            var isDeleted = await _generalRepo.SoftDeleteAsync(request.Id, cancellationToken);
            if (!isDeleted) return RequestResult<bool>.Failure(ErrorCode.TeamNotFound);
            return RequestResult<bool>.Success(isDeleted);
        }
    }
}

