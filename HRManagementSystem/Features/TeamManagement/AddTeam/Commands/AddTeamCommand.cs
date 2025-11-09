using HRManagementSystem.Features.Common.Dtos;

namespace HRManagementSystem.Features.TeamManagement.AddTeam.Commands
{
    public sealed record AddTeamCommand(string Name, string Code, string? Description, int DepartmentId)
        : IRequest<RequestResult<CreatedIdDto>>;


    public class AddTeamCommandHandler : RequestHandlerBase<AddTeamCommand, RequestResult<CreatedIdDto>, Team, int>
    {
        public AddTeamCommandHandler(RequestHandlerBaseParameters<Team, int> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<CreatedIdDto>> Handle(AddTeamCommand request, CancellationToken ct)
        {
            var team = _mapper.Map<AddTeamCommand, Team>(request);

            var nameExists = await _generalRepo.ExistsByNameAsync<Team>(request.Name);
            if (nameExists)
                return RequestResult<CreatedIdDto>.Failure("Team Name already exists.", ErrorCode.Conflict);

            var isAdded = await _generalRepo.AddAsync(team, ct);

            if (!isAdded) return RequestResult<CreatedIdDto>.Failure("Team wasn't added successfully!", ErrorCode.InternalServerError);

            var mapped = _mapper.Map<CreatedIdDto>(team);
            return RequestResult<CreatedIdDto>.Success(mapped, "Team added successfully!");
        }
    }
}
