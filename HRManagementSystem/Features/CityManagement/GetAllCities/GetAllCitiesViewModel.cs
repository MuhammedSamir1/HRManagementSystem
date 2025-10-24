using FluentValidation;

namespace HRManagementSystem.Features.CityManagement.GetAllCities
{
    // ViewModel اللي بيرجع من الـ Endpoint
    public record GetAllCitiesViewModel();

    // Validator (مش ضروري هنا، لكن نضيفه لو في pagination أو filters)
    public class GetAllCitiesViewModelValidator : AbstractValidator<GetAllCitiesViewModel>
    {
        public GetAllCitiesViewModelValidator()
        {

        }
    }
}
