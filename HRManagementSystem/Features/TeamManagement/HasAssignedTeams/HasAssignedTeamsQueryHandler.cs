using Microsoft.EntityFrameworkCore;

namespace HRManagementSystem.Features.TeamManagement.HasAssignedTeams
{
    public sealed class HasAssignedTeamsQueryHandler : RequestHandlerBase<HasAssignedTeamsQuery, RequestResult<bool>, Team, Guid>
    {
        public HasAssignedTeamsQueryHandler(RequestHandlerBaseParameters<Team, Guid> parameters) : base(parameters) { }

        public override async Task<RequestResult<bool>> Handle(HasAssignedTeamsQuery request, CancellationToken ct)
        {

            var hasTeams = await _generalRepo
                .Get(t => t.DepartmentId == request.DepartmentId, ct)
                .AnyAsync(ct);

            if (hasTeams)
            {

                return RequestResult<bool>.Failure("Cannot delete department: It has active assigned teams.", ErrorCode.Conflict);
            }
            return RequestResult<bool>.Success(true);
        }
    }
}

