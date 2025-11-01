using HRManagementSystem.Features.BranchManagement.DeleteBranch.Commands;
using HRManagementSystem.Features.Common.IsAnyChildAssignedGeneric;

namespace HRManagementSystem.Features.BranchManagement.DeleteBranch.Orchestrators;

public sealed class DeleteBranchOrchestratorHandler : RequestHandlerBase<DeleteBranchOrchestrator,
        RequestResult<bool>, Branch, int>
{
    public DeleteBranchOrchestratorHandler(RequestHandlerBaseParameters<Branch, int> parameters)
        : base(parameters) { }

    public override async Task<RequestResult<bool>> Handle(DeleteBranchOrchestrator request, CancellationToken ct)
    {
        // Check if any Departments assigned to this Branch 

        var hasDepartments = await _mediator.Send(new IsAnyChildAssignedQuery<Branch, Department, int>(request.Id), ct);
        if (hasDepartments.data)
        {
            return RequestResult<bool>.Failure("Cannot delete branch. There are departments assigned to this branch.");
        }

        var isDeleted = await _mediator.Send(new DeleteBranchCommand(request.Id), ct);
        if (!isDeleted.isSuccess) return RequestResult<bool>.Failure(isDeleted.message, isDeleted.errorCode);
        return RequestResult<bool>.Success(isDeleted.isSuccess, isDeleted.message);
    }
}