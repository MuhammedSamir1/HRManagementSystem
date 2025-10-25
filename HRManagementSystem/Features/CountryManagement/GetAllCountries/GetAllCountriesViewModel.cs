using FluentValidation;

namespace HRManagementSystem.Features.CountryManagement.GetAllCountries
{
    public sealed record GetAllCountriesViewModel();




    public class GetAllCountriesViewModelValidator : AbstractValidator<GetAllCountriesViewModel>
    {
        public GetAllCountriesViewModelValidator()
        {

        }
    }
}
