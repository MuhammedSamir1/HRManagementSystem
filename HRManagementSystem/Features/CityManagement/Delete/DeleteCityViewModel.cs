using FluentValidation;

namespace HRManagementSystem.Features.CityManagement.Delete
{
    public record DeleteCityViewModel(Guid Id);

    public class DeleteCityViewModelValidator : AbstractValidator<DeleteCityViewModel>
    {
        public DeleteCityViewModelValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("City Id is required.")
                .NotEqual(Guid.Empty).WithMessage("City Id must be provided.");
        }
    }
}

