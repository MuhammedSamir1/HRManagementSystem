using FluentValidation;

namespace HRManagementSystem.Features.Configurations.DisabilityType.GetById
{
    public sealed record GetDisabilityTypeByIdViewModel(int Id);

    // Validators/GetDisabilityTypeByIdViewModelValidator.cs
    public sealed class GetDisabilityTypeByIdViewModelValidator
        : AbstractValidator<GetDisabilityTypeByIdViewModel>
    {
        public GetDisabilityTypeByIdViewModelValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("ID is required.")
                .GreaterThan(0).WithMessage("ID must be greater than 0.");
        }
    }
}
