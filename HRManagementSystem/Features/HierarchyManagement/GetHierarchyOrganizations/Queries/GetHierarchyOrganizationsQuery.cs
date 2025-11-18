using HRManagementSystem.Features.Common.HierarchyLookup;

namespace HRManagementSystem.Features.HierarchyManagement.GetHierarchyOrganizations.Queries;

public sealed record GetHierarchyOrganizationsQuery() : IHierarchyLookupRequest<Guid>
{
    public Guid? ParentId => null;
}

public sealed class GetHierarchyOrganizationsQueryHandler :
    HierarchyLookupHandlerBase<GetHierarchyOrganizationsQuery, Organization, Organization, Guid>
{
    public GetHierarchyOrganizationsQueryHandler(
        RequestHandlerBaseParameters<Organization, Guid> parameters,
        IHierarchyLookupHelper hierarchyLookupHelper)
        : base(parameters, hierarchyLookupHelper) { }
}

