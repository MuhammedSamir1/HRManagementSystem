using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace HRManagementSystem.Features.CountryManagement.ViewModels.UpdateCountry
{
    public sealed record UpdateCountryViewModel(int Id, [Required] string Iso2, [Required] string Iso3, [Required] string Name);

    public class UpdateCountryViewModelValidator : AbstractValidator<UpdateCountryViewModel>
    {
        public UpdateCountryViewModelValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Country ID is required.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Country name is required.")
                .MaximumLength(100).WithMessage("Name must be at most 100 chars.");

            RuleFor(x => x.Iso2).Length(2).WithMessage("ISO2 code must be 2 characters.");
            RuleFor(x => x.Iso3).Length(3).WithMessage("ISO3 code must be 3 characters.");
        }
    }
}
