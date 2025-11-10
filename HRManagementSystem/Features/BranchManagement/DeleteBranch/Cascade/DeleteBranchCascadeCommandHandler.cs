using HRManagementSystem.Features.Common.DeleteEntityCascade.Handler;

namespace HRManagementSystem.Features.BranchManagement.DeleteBranch.Cascade;

public sealed class DeleteBranchCascadeCommandHandler
        : DeleteEntityCascadeCommandHandler<Branch, int>
{
    public DeleteBranchCascadeCommandHandler(
        RequestHandlerBaseParameters<Branch, int> parameters
    ) : base(parameters)
    {
    }
}
