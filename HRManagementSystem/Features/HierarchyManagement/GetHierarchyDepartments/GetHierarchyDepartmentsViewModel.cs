using FluentValidation;

namespace HRManagementSystem.Features.HierarchyManagement.GetHierarchyDepartments;

public sealed record GetHierarchyDepartmentsViewModel
{
    public Guid BranchId { get; init; }
}

public sealed class GetHierarchyDepartmentsViewModelValidator : AbstractValidator<GetHierarchyDepartmentsViewModel>
{
    public GetHierarchyDepartmentsViewModelValidator()
    {
        RuleFor(x => x.BranchId)
            .NotEmpty()
            .WithMessage("BranchId is required.");
    }
}

