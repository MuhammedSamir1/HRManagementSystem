using FluentValidation;

namespace HRManagementSystem.Features.DepartmentManagement.AddDepartment
{
    public record AddDepartmentRequestViewModel(
                               int branchId, string name,
                               string code, string? description);

    public class AddDepartmentRequestViewModelValidator : AbstractValidator<AddDepartmentRequestViewModel>
    {
        public AddDepartmentRequestViewModelValidator()
        {
            // BranchId validation
            RuleFor(x => x.branchId)
                .GreaterThan(0).WithMessage("Organization ID must be greater than zero.");

            // Name validation
            RuleFor(x => x.name)
                .NotEmpty().WithMessage("Name is required.")
                .MinimumLength(2).WithMessage("Name must be at least 2 characters.")
                .MaximumLength(200).WithMessage("Name must be at most 200 characters.")
                .Must(v => v!.Trim().Length <= 200).WithMessage("Name must not contain excessive whitespace.");

            // Code validation
            RuleFor(x => x.code)
                .NotEmpty().WithMessage("Code is required.")
                .Matches(@"^[A-Za-z0-9\-]+$").WithMessage("Code must contain only letters, numbers, or hyphens.")
                .MaximumLength(50).WithMessage("Code must be at most 50 characters.");
        }
    }

}
