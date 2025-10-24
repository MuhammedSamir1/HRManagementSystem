using HRManagementSystem.Common.BaseRequestHandler;
using HRManagementSystem.Common.Data.Enums;
using HRManagementSystem.Common.Views.Response;
using HRManagementSystem.Data.Models;
using MediatR;

namespace HRManagementSystem.Features.TeamManagement.AddTeam.Commands
{
    public sealed record AddTeamCommand(string Name, string Code, string? Description, int DepartmentId)
        : IRequest<RequestResult<bool>>;


    public class AddTeamCommandHandler : RequestHandlerBase<AddTeamCommand, RequestResult<bool>, Team, int>
    {
        public AddTeamCommandHandler(RequestHandlerBaseParameters<Team, int> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<bool>> Handle(AddTeamCommand request, CancellationToken ct)
        {
            var team = _mapper.Map<AddTeamCommand, Team>(request);

            var nameExists = await _generalRepo.ExistsByNameAsync<Team>(request.Name);
            if (nameExists)
                return RequestResult<bool>.Failure("Team Name already exists.", ErrorCode.Conflict);

            var isAdded = await _generalRepo.AddAsync(team, ct);

            if (!isAdded) return RequestResult<bool>.Failure("Team wasn't added successfully!", ErrorCode.InternalServerError);
            return RequestResult<bool>.Success(isAdded, "Team added successfully!");
        }
    }
}
