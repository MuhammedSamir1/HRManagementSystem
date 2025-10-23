using FluentValidation;

namespace HRManagementSystem.Features.CityManagement.GetCityById
{
    // ✅ ViewModel واللي بيستقبل Id من الEndpoint
    public record GetCityByIdViewModel(int Id);

    public class GetCityByIdViewModelValidator : AbstractValidator<GetCityByIdViewModel>
    {
        public GetCityByIdViewModelValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("City Id must be greater than 0.");
        }
    }
}
