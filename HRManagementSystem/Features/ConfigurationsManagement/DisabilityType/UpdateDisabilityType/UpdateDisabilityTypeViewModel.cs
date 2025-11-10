using FluentValidation;

namespace HRManagementSystem.Features.ConfigurationsManagement.DisabilityType.UpdateDisabilityType
{
    // ViewModels/UpdateDisabilityTypeViewModel.cs
    public sealed record UpdateDisabilityTypeViewModel(int Id, string Code, string Name, string? Description = null);

    // Validators/UpdateDisabilityTypeViewModelValidator.cs
    public sealed class UpdateDisabilityTypeViewModelValidator : AbstractValidator<UpdateDisabilityTypeViewModel>
    {
        public UpdateDisabilityTypeViewModelValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("ID is required.")
                .GreaterThan(0).WithMessage("ID must be greater than 0.");

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
