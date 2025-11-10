using FluentValidation;

namespace HRManagementSystem.Features.ConfigurationsManagement.ProbationPeriodManagement.GetProbationPeriodById
{
    public sealed record GetProbationPeriodByIdViewModel(int Id);


    public sealed class GetProbationPeriodByIdViewModelValidator : AbstractValidator<GetProbationPeriodByIdViewModel>
    {
        public GetProbationPeriodByIdViewModelValidator()
        {
            RuleFor(d => d.Id)
              .NotEmpty().WithMessage("Id is required.")
              .GreaterThan(0).WithMessage("Id must be greater than 0");
        }
    }
}

