namespace HRManagementSystem.Features.TeamManagement.HasAssignedTeams
{
    public sealed record HasAssignedTeamsQuery(Guid DepartmentId) : IRequest<RequestResult<bool>>;
}

