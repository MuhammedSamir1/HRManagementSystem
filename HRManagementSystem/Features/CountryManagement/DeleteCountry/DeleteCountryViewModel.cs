using FluentValidation;

namespace HRManagementSystem.Features.CountryManagement.DeleteCountry
{
    public sealed record DeleteCountryViewModel(Guid Id);
    public class DeleteCountryViewModelValidator : AbstractValidator<DeleteCountryViewModel>
    {
        public DeleteCountryViewModelValidator()
        {
            // ???? ????? ?? ID ?????
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Country ID is required for deletion.")
                .NotEqual(Guid.Empty).WithMessage("Country ID must be a positive integer.");
        }
    }
}


