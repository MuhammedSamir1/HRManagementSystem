using FluentValidation;

namespace HRManagementSystem.Features.CityManagement.GetCityById
{
    // ✅ ViewModel واللي بيستقبل Id من الEndpoint
    public record GetCityByIdViewModel(Guid Id);

    public class GetCityByIdViewModelValidator : AbstractValidator<GetCityByIdViewModel>
    {
        public GetCityByIdViewModelValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("City Id is required.")
                .NotEqual(Guid.Empty).WithMessage("City Id must not be empty.");
        }
    }
}
