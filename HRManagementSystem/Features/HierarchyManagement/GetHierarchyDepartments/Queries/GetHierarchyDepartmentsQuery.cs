using HRManagementSystem.Features.Common.HierarchyLookup;

namespace HRManagementSystem.Features.HierarchyManagement.GetHierarchyDepartments.Queries;

public sealed record GetHierarchyDepartmentsQuery(Guid BranchId) : IHierarchyLookupRequest<Guid>
{
    public Guid? ParentId => BranchId;
}

public sealed class GetHierarchyDepartmentsQueryHandler :
    HierarchyLookupHandlerBase<GetHierarchyDepartmentsQuery, Branch, Department, Guid>
{
    public GetHierarchyDepartmentsQueryHandler(
        RequestHandlerBaseParameters<Department, Guid> parameters,
        IHierarchyLookupHelper hierarchyLookupHelper)
        : base(parameters, hierarchyLookupHelper) { }
}

