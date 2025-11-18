using HRManagementSystem.Features.Common.HierarchyLookup;

namespace HRManagementSystem.Features.HierarchyManagement.GetHierarchyCompanies.Queries;

public sealed record GetHierarchyCompaniesQuery(Guid OrganizationId) : IHierarchyLookupRequest<Guid>
{
    public Guid? ParentId => OrganizationId;
}

public sealed class GetHierarchyCompaniesQueryHandler :
    HierarchyLookupHandlerBase<GetHierarchyCompaniesQuery, Organization, Company, Guid>
{
    public GetHierarchyCompaniesQueryHandler(
        RequestHandlerBaseParameters<Company, Guid> parameters,
        IHierarchyLookupHelper hierarchyLookupHelper)
        : base(parameters, hierarchyLookupHelper) { }
}

