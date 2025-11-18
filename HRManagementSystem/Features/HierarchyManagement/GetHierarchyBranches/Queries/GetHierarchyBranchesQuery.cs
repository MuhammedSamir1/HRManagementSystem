using HRManagementSystem.Features.Common.HierarchyLookup;

namespace HRManagementSystem.Features.HierarchyManagement.GetHierarchyBranches.Queries;

public sealed record GetHierarchyBranchesQuery(Guid CompanyId) : IHierarchyLookupRequest<Guid>
{
    public Guid? ParentId => CompanyId;
}

public sealed class GetHierarchyBranchesQueryHandler :
    HierarchyLookupHandlerBase<GetHierarchyBranchesQuery, Company, Branch, Guid>
{
    public GetHierarchyBranchesQueryHandler(
        RequestHandlerBaseParameters<Branch, Guid> parameters,
        IHierarchyLookupHelper hierarchyLookupHelper)
        : base(parameters, hierarchyLookupHelper) { }
}

