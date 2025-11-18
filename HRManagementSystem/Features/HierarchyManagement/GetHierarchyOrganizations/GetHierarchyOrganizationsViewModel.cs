using FluentValidation;

namespace HRManagementSystem.Features.HierarchyManagement.GetHierarchyOrganizations;

public sealed record GetHierarchyOrganizationsViewModel;

public sealed class GetHierarchyOrganizationsViewModelValidator : AbstractValidator<GetHierarchyOrganizationsViewModel>
{
    public GetHierarchyOrganizationsViewModelValidator() { }
}

