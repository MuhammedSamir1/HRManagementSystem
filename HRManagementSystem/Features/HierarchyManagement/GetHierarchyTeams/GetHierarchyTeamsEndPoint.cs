using HRManagementSystem.Features.Common.HierarchyLookup;
using HRManagementSystem.Features.HierarchyManagement.GetHierarchyTeams.Queries;

namespace HRManagementSystem.Features.HierarchyManagement.GetHierarchyTeams;

[ApiGroup("Hierarchy Management")]
public sealed class GetHierarchyTeamsEndPoint : BaseEndPoint<GetHierarchyTeamsViewModel,
    List<HierarchyLookupItem<Guid>>>
{
    public GetHierarchyTeamsEndPoint(EndPointBaseParameters<GetHierarchyTeamsViewModel> parameters)
        : base(parameters) { }

    [HttpGet("/api/hierarchy/departments/{departmentId:guid}/teams")]
    public Task<ResponseViewModel<List<HierarchyLookupItem<Guid>>>> Get(
        [FromRoute] GetHierarchyTeamsViewModel request,
        CancellationToken ct = default)
        => HandleRequestAsync(
            request,
            token => _mediator.Send(new GetHierarchyTeamsQuery(request.DepartmentId), token),
            ct);
}

