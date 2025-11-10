using HRManagementSystem.Features.Common.IsAnyChildAssignedGeneric;
using HRManagementSystem.Features.OrganizationManagement.DeleteOrganization.Commands;

namespace HRManagementSystem.Features.OrganizationManagement.DeleteOrganization.Orchestrators;

public sealed class DeleteOrganizationOrchestratorHandler : RequestHandlerBase<DeleteOrganizationOrchestrator,
       RequestResult<bool>, Organization, int>
{
    public DeleteOrganizationOrchestratorHandler(RequestHandlerBaseParameters<Organization, int> parameters)
        : base(parameters) { }

    public override async Task<RequestResult<bool>> Handle(DeleteOrganizationOrchestrator request, CancellationToken ct)
    {
        var hasBranches = await _mediator.Send(new IsAnyChildAssignedQuery<Organization, Company, int>(request.Id), ct);
        if (hasBranches.data)
        {
            return RequestResult<bool>.Failure("Cannot delete Organization. There are Companies assigned to this Organization.");
        }
        var isDeleted = await _mediator.Send(new DeleteOrganizationCommand(request.Id));
        if (!isDeleted.isSuccess) return RequestResult<bool>.Failure(isDeleted.message, isDeleted.errorCode);
        return RequestResult<bool>.Success(isDeleted.isSuccess, isDeleted.message);
    }
}
