using FluentValidation;

namespace HRManagementSystem.Features.CountryManagement.ViewModels.DeleteCountry
{
    public sealed record DeleteCountryViewModel(int Id);
    public class DeleteCountryViewModelValidator : AbstractValidator<DeleteCountryViewModel>
    {
        public DeleteCountryViewModelValidator()
        {
            // عشان اتاكد ان ID موجود
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Country ID is required for deletion.")
                .GreaterThan(0).WithMessage("Country ID must be a positive integer.");
        }
    }
}
