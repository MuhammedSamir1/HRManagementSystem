using HRManagementSystem.Features.Common.HierarchyLookup;
using HRManagementSystem.Features.HierarchyManagement.GetHierarchyBranches.Queries;

namespace HRManagementSystem.Features.HierarchyManagement.GetHierarchyBranches;

[ApiGroup("Hierarchy Management")]
public sealed class GetHierarchyBranchesEndPoint : BaseEndPoint<GetHierarchyBranchesViewModel,
    List<HierarchyLookupItem<Guid>>>
{
    public GetHierarchyBranchesEndPoint(EndPointBaseParameters<GetHierarchyBranchesViewModel> parameters)
        : base(parameters) { }

    [HttpGet("/api/hierarchy/companies/{companyId:guid}/branches")]
    public Task<ResponseViewModel<List<HierarchyLookupItem<Guid>>>> Get(
        [FromRoute] GetHierarchyBranchesViewModel request,
        CancellationToken ct = default)
        => HandleRequestAsync(
            request,
            token => _mediator.Send(new GetHierarchyBranchesQuery(request.CompanyId), token),
            ct);
}

