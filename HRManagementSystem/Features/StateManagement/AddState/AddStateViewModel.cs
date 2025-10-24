using FluentValidation;

namespace HRManagementSystem.Features.StateManagement.AddState
{
    public sealed record AddStateViewModel(string Code, string Name, int CountryId);

    public sealed class AddStateViewModelValidator : AbstractValidator<AddStateViewModel>
    {
        public AddStateViewModelValidator()
        {
            RuleFor(x => x.Code)
                .NotEmpty().WithMessage("Code is required.")
                .Length(2, 10).WithMessage("Code must be between 2 and 10 characters.")
                .Matches("^[A-Z][A-Z0-9]*$").WithMessage("Code must contain only uppercase letters and numbers, and start with a letter.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .Length(2, 100).WithMessage("Name must be between 2 and 100 characters.")
                .Matches("^[a-zA-Z\\s\\-\\.\\']+$").WithMessage("Name can only contain letters, spaces, hyphens, dots, and apostrophes.");

            RuleFor(x => x.CountryId)
                .NotEmpty().WithMessage("Country ID is required.")
                .GreaterThan(0).WithMessage("Country ID must be greater than 0.");
        }
    }


}
