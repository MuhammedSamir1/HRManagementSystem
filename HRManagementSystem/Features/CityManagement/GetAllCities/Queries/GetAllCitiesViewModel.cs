using FluentValidation;

namespace HRManagementSystem.Features.CityManagement.GetAllCities.ViewModels
{
    // ViewModel اللي بيرجع من الـ Endpoint
    public record GetAllCitiesViewModel(int Id, string Name, int StateId);

    // Validator (مش ضروري هنا، لكن نضيفه لو في pagination أو filters)
    public class GetAllCitiesViewModelValidator : AbstractValidator<GetAllCitiesViewModel>
    {
        public GetAllCitiesViewModelValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThanOrEqualTo(0).WithMessage("Invalid city id.");

            RuleFor(x => x.Name)
                .MaximumLength(200).WithMessage("City name must not exceed 200 characters.");
        }
    }
}
