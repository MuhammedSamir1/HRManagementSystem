using HRManagementSystem.Common.BaseRequestHandler;
using HRManagementSystem.Common.Data.Enums;
using HRManagementSystem.Common.Views.Response;
using HRManagementSystem.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HRManagementSystem.Features.TeamManagement.HasAssignedTeams
{
    public sealed class HasAssignedTeamsQueryHandler : RequestHandlerBase<HasAssignedTeamsQuery, RequestResult<bool>, Team, int>
    {
        public HasAssignedTeamsQueryHandler(RequestHandlerBaseParameters<Team, int> parameters) : base(parameters) { }

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
