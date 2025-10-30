using HRManagementSystem.Common.Views.Response;
using MediatR;

namespace HRManagementSystem.Features.TeamManagement.HasAssignedTeams
{
    public sealed record HasAssignedTeamsQuery(int DepartmentId) : IRequest<RequestResult<bool>>;
}
