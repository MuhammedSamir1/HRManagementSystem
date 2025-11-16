using FluentValidation;

namespace HRManagementSystem.Features.ConfigurationsManagement.ProbationPeriodManagement.GetProbationPeriodById
{
    public sealed record GetProbationPeriodByIdViewModel(Guid Id);


    public sealed class GetProbationPeriodByIdViewModelValidator : AbstractValidator<GetProbationPeriodByIdViewModel>
    {
        public GetProbationPeriodByIdViewModelValidator()
        {
            RuleFor(d => d.Id)
              .NotEmpty().WithMessage("Id is required.")
              .NotEqual(Guid.Empty).WithMessage("Id must be greater than 0");
        }
    }
}



