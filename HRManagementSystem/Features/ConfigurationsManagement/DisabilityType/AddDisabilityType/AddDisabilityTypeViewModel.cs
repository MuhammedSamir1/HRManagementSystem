using FluentValidation;

namespace HRManagementSystem.Features.ConfigurationsManagement.DisabilityType.AddDisabilityType
{
    // DTOs/AddDisabilityTypeViewModel.cs
    public sealed record AddDisabilityTypeViewModel(string Code, string Name, string? Description = null);

    // Validators/AddDisabilityTypeViewModelValidator.cs
    public sealed class AddDisabilityTypeViewModelValidator : AbstractValidator<AddDisabilityTypeViewModel>
    {
        public AddDisabilityTypeViewModelValidator()
        {
            RuleFor(x => x.Code)
                .NotEmpty().WithMessage("Code is required.")
                .Length(2, 10).WithMessage("Code must be between 2 and 10 characters.")
                .Matches("^[A-Z][A-Z0-9]*$").WithMessage("Code must contain only uppercase letters and numbers, and start with a letter.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .Length(2, 100).WithMessage("Name must be between 2 and 100 characters.")
                .Matches("^[a-zA-Z\\s\\-\\.\\']+$").WithMessage("Name can only contain letters, spaces, hyphens, dots, and apostrophes.");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.")
                .When(x => !string.IsNullOrEmpty(x.Description));
        }
    }
}
