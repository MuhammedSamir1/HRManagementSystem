using FluentValidation;

namespace HRManagementSystem.Features.HierarchyManagement.GetHierarchyTeams;

public sealed record GetHierarchyTeamsViewModel
{
    public Guid DepartmentId { get; init; }
}

public sealed class GetHierarchyTeamsViewModelValidator : AbstractValidator<GetHierarchyTeamsViewModel>
{
    public GetHierarchyTeamsViewModelValidator()
    {
        RuleFor(x => x.DepartmentId)
            .NotEmpty()
            .WithMessage("DepartmentId is required.");
    }
}

