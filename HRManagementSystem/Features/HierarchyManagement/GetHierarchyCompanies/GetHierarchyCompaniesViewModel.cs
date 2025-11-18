using FluentValidation;

namespace HRManagementSystem.Features.HierarchyManagement.GetHierarchyCompanies;

public sealed record GetHierarchyCompaniesViewModel
{
    public Guid OrganizationId { get; init; }
}

public sealed class GetHierarchyCompaniesViewModelValidator : AbstractValidator<GetHierarchyCompaniesViewModel>
{
    public GetHierarchyCompaniesViewModelValidator()
    {
        RuleFor(x => x.OrganizationId)
            .NotEmpty()
            .WithMessage("OrganizationId is required.");
    }
}

