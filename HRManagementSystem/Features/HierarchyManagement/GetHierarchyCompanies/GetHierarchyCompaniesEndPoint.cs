using HRManagementSystem.Features.Common.HierarchyLookup;
using HRManagementSystem.Features.HierarchyManagement.GetHierarchyCompanies.Queries;

namespace HRManagementSystem.Features.HierarchyManagement.GetHierarchyCompanies;

[ApiGroup("Hierarchy Management")]
public sealed class GetHierarchyCompaniesEndPoint : BaseEndPoint<GetHierarchyCompaniesViewModel,
    List<HierarchyLookupItem<Guid>>>
{
    public GetHierarchyCompaniesEndPoint(EndPointBaseParameters<GetHierarchyCompaniesViewModel> parameters)
        : base(parameters) { }

    [HttpGet("/api/hierarchy/organizations/{organizationId:guid}/companies")]
    public Task<ResponseViewModel<List<HierarchyLookupItem<Guid>>>> Get(
        [FromRoute] GetHierarchyCompaniesViewModel request,
        CancellationToken ct = default)
        => HandleRequestAsync(
            request,
            token => _mediator.Send(new GetHierarchyCompaniesQuery(request.OrganizationId), token),
            ct);
}

