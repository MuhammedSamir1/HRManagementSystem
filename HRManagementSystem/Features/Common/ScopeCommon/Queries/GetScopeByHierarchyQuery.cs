using HRManagementSystem.Data.Models.Scopes;
using Microsoft.EntityFrameworkCore;

namespace HRManagementSystem.Features.Common.ScopeCommon.Queries
{
    public sealed record GetScopeByHierarchyQuery(
        Guid OrganizationId,
        Guid CompanyId,
        Guid? BranchId,
        Guid? DepartmentId,
        Guid? TeamId) : IRequest<RequestResult<Guid>>;

    public sealed class GetScopeByHierarchyQueryHandler
        : RequestHandlerBase<GetScopeByHierarchyQuery, RequestResult<Guid>, Scope, Guid>
    {
        public GetScopeByHierarchyQueryHandler(RequestHandlerBaseParameters<Scope, Guid> parameters)
            : base(parameters)
        {
        }

        public override async Task<RequestResult<Guid>> Handle(GetScopeByHierarchyQuery request, CancellationToken ct)
        {
            var scope = await _generalRepo
                .Get(x =>
                    x.OrganizationId == request.OrganizationId &&
                    x.CompanyId == request.CompanyId &&
                    x.BranchId == request.BranchId &&
                    x.DepartmentId == request.DepartmentId &&
                    x.TeamId == request.TeamId &&
                    !x.IsDeleted,
                    ct)
                .Select(x => new { x.Id })
                .FirstOrDefaultAsync(ct);

            if (scope is null)
            {
                return RequestResult<Guid>.Failure("Scope not found.", ErrorCode.NotFound);
            }

            return RequestResult<Guid>.Success(scope.Id);
        }
    }
}

