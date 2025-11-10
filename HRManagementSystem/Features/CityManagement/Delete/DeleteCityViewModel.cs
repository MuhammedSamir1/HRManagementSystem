using FluentValidation;

namespace HRManagementSystem.Features.CityManagement.Delete
{
    public record DeleteCityViewModel(int Id);

    public class DeleteCityViewModelValidator : AbstractValidator<DeleteCityViewModel>
    {
        public DeleteCityViewModelValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("City Id must be greater than 0.");
        }
    }
}
