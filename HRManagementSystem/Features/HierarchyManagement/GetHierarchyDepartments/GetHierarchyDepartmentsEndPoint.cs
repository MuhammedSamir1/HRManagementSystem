using HRManagementSystem.Features.Common.HierarchyLookup;
using HRManagementSystem.Features.HierarchyManagement.GetHierarchyDepartments.Queries;

namespace HRManagementSystem.Features.HierarchyManagement.GetHierarchyDepartments;

[ApiGroup("Hierarchy Management")]
public sealed class GetHierarchyDepartmentsEndPoint : BaseEndPoint<GetHierarchyDepartmentsViewModel,
    List<HierarchyLookupItem<Guid>>>
{
    public GetHierarchyDepartmentsEndPoint(EndPointBaseParameters<GetHierarchyDepartmentsViewModel> parameters)
        : base(parameters) { }

    [HttpGet("/api/hierarchy/branches/{branchId:guid}/departments")]
    public Task<ResponseViewModel<List<HierarchyLookupItem<Guid>>>> Get(
        [FromRoute] GetHierarchyDepartmentsViewModel request,
        CancellationToken ct = default)
        => HandleRequestAsync(
            request,
            token => _mediator.Send(new GetHierarchyDepartmentsQuery(request.BranchId), token),
            ct);
}

