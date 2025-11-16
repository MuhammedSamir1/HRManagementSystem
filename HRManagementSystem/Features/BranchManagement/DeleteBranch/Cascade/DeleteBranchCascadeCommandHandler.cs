using HRManagementSystem.Features.Common.DeleteEntityCascade.Handler;

namespace HRManagementSystem.Features.BranchManagement.DeleteBranch.Cascade;

public sealed class DeleteBranchCascadeCommandHandler
        : DeleteEntityCascadeCommandHandler<Branch, Guid>
{
    public DeleteBranchCascadeCommandHandler(
        RequestHandlerBaseParameters<Branch, Guid> parameters
    ) : base(parameters)
    {
    }
}

