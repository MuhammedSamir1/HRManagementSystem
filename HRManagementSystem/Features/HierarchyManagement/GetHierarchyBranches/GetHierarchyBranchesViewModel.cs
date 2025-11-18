using FluentValidation;

namespace HRManagementSystem.Features.HierarchyManagement.GetHierarchyBranches;

public sealed record GetHierarchyBranchesViewModel
{
    public Guid CompanyId { get; init; }
}

public sealed class GetHierarchyBranchesViewModelValidator : AbstractValidator<GetHierarchyBranchesViewModel>
{
    public GetHierarchyBranchesViewModelValidator()
    {
        RuleFor(x => x.CompanyId)
            .NotEmpty()
            .WithMessage("CompanyId is required.");
    }
}

