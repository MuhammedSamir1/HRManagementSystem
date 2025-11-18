using HRManagementSystem.Features.Common.HierarchyLookup;

namespace HRManagementSystem.Features.HierarchyManagement.GetHierarchyTeams.Queries;

public sealed record GetHierarchyTeamsQuery(Guid DepartmentId) : IHierarchyLookupRequest<Guid>
{
    public Guid? ParentId => DepartmentId;
}

public sealed class GetHierarchyTeamsQueryHandler :
    HierarchyLookupHandlerBase<GetHierarchyTeamsQuery, Department, Team, Guid>
{
    public GetHierarchyTeamsQueryHandler(
        RequestHandlerBaseParameters<Team, Guid> parameters,
        IHierarchyLookupHelper hierarchyLookupHelper)
        : base(parameters, hierarchyLookupHelper) { }
}

