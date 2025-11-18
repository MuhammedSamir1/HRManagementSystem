using HRManagementSystem.Features.Common.HierarchyLookup;
using HRManagementSystem.Features.HierarchyManagement.GetHierarchyOrganizations.Queries;

namespace HRManagementSystem.Features.HierarchyManagement.GetHierarchyOrganizations;

[ApiGroup("Hierarchy Management")]
public sealed class GetHierarchyOrganizationsEndPoint : BaseEndPoint<GetHierarchyOrganizationsViewModel,
    List<HierarchyLookupItem<Guid>>>
{
    public GetHierarchyOrganizationsEndPoint(EndPointBaseParameters<GetHierarchyOrganizationsViewModel> parameters)
        : base(parameters) { }

    [HttpGet("/api/hierarchy/organizations")]
    public Task<ResponseViewModel<List<HierarchyLookupItem<Guid>>>> Get(CancellationToken ct = default)
        => HandleRequestAsync(
            token => _mediator.Send(new GetHierarchyOrganizationsQuery(), token),
            ct);
}

