using FluentValidation;

namespace HRManagementSystem.Features.CompanyManagement.AddCompany
{
    public record AddCompanyRequestViewModel(Guid organizationId,
                                            string Name,
                                            string code,
                                            string? Descreption);

    public class AddCompanyRequestViewModelValidator : AbstractValidator<AddCompanyRequestViewModel>
    {
        public AddCompanyRequestViewModelValidator()
        {
            // OrganizationId validation
            RuleFor(x => x.organizationId)
                .NotEqual(Guid.Empty).WithMessage("Organization ID must be greater than zero.");

            // Name validation
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MinimumLength(2).WithMessage("Name must be at least 2 characters.")
                .MaximumLength(200).WithMessage("Name must be at most 200 characters.")
                .Must(v => v!.Trim().Length <= 200).WithMessage("Name must not contain excessive whitespace.");

            // Code validation
            RuleFor(x => x.code)
                .NotEmpty().WithMessage("Code is required.")
                .Matches(@"^[A-Za-z0-9\-]+$").WithMessage("Code must contain only letters, numbers, or hyphens.")
                .MaximumLength(50).WithMessage("Code must be at most 50 characters.");

            // Description validation
            RuleFor(x => x.Descreption)
                .MaximumLength(1000).WithMessage("Description must be at most 1000 characters.");
        }
    }
}


