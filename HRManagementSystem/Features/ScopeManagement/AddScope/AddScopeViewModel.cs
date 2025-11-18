using FluentValidation;

namespace HRManagementSystem.Features.ScopeManagement.AddScope
{
    public sealed record AddScopeViewModel(
        Guid OrganizationId,
        Guid CompanyId,
        Guid BranchId,
        Guid DepartmentId,
        Guid TeamId);

    public sealed class AddScopeViewModelValidator : AbstractValidator<AddScopeViewModel>
    {
        public AddScopeViewModelValidator()
        {
            RuleFor(x => x.OrganizationId)
                .NotEqual(Guid.Empty).WithMessage("OrganizationId is required.");

            RuleFor(x => x.CompanyId)
                .NotEqual(Guid.Empty).WithMessage("CompanyId is required.");

            RuleFor(x => x.BranchId)
                .NotEqual(Guid.Empty).WithMessage("BranchId is required.");

            RuleFor(x => x.DepartmentId)
                .NotEqual(Guid.Empty).WithMessage("DepartmentId is required.");

            RuleFor(x => x.TeamId)
                .NotEqual(Guid.Empty).WithMessage("TeamId is required.");
        }
    }
}

