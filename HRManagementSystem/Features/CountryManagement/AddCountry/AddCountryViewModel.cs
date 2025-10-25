using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace HRManagementSystem.Features.CountryManagement.AddCountry
{
    public sealed record AddCountryViewModel([Required] string Iso2, [Required] string Iso3, [Required] string Name);
    public class AddCountryViewModelValidator : AbstractValidator<AddCountryViewModel>
    {
        public AddCountryViewModelValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Country name is required.")
                .MaximumLength(100).WithMessage("Name must be at most 100 chars.");

            RuleFor(x => x.Iso2)
                .NotEmpty().WithMessage("ISO2 code is required.")
                .Length(2).WithMessage("ISO2 code must be 2 characters.");

            RuleFor(x => x.Iso3)
                .NotEmpty().WithMessage("ISO3 code is required.")
                .Length(3).WithMessage("ISO3 code must be 3 characters.");
        }
    }

}
