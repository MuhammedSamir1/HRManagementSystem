using HRManagementSystem.Features.Common.DeleteEntityCascade;

namespace HRManagementSystem.Features.BranchManagement.DeleteBranch.Cascade;

public sealed class DeleteBranchCascadeViewModelValidator
        : DeleteEntityCascadeViewModelValidator<Branch, Guid>
{
    public DeleteBranchCascadeViewModelValidator() : base()
    {
    }
}
