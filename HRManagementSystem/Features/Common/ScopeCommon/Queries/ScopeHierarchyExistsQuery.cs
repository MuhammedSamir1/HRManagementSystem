using HRManagementSystem.Data.Models.Scopes;

namespace HRManagementSystem.Features.Common.ScopeCommon.Queries
{
    public sealed record ScopeHierarchyExistsQuery(
        Guid OrganizationId,
        Guid CompanyId,
        Guid? BranchId,
        Guid? DepartmentId,
        Guid? TeamId,
        Guid? ExcludedScopeId = null) : IRequest<RequestResult<bool>>;

    public sealed class ScopeHierarchyExistsQueryHandler
        : RequestHandlerBase<ScopeHierarchyExistsQuery, RequestResult<bool>, Scope, Guid>
    {
        public ScopeHierarchyExistsQueryHandler(RequestHandlerBaseParameters<Scope, Guid> parameters)
            : base(parameters)
        {
        }

        public override async Task<RequestResult<bool>> Handle(ScopeHierarchyExistsQuery request, CancellationToken ct)
        {
            var exists = await _generalRepo.CheckAnyAsync(
                x =>
                    (!request.ExcludedScopeId.HasValue || x.Id != request.ExcludedScopeId) &&
                    x.OrganizationId == request.OrganizationId &&
                    x.CompanyId == request.CompanyId &&
                    x.BranchId == request.BranchId &&
                    x.DepartmentId == request.DepartmentId &&
                    x.TeamId == request.TeamId &&
                    !x.IsDeleted,
                ct);

            return RequestResult<bool>.Success(exists);
        }
    }
}

