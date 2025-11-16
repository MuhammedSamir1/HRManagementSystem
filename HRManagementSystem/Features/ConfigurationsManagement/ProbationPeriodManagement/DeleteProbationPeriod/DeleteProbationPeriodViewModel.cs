using FluentValidation;

namespace HRManagementSystem.Features.ConfigurationsManagement.ProbationPeriodManagement.DeleteProbationPeriod
{
    public sealed record DeleteProbationPeriodViewModel(Guid Id);



    public sealed class DeleteProbationPeriodViewModelValidator : AbstractValidator<DeleteProbationPeriodViewModel>
    {
        public DeleteProbationPeriodViewModelValidator()
        {
            RuleFor(d => d.Id)
                .NotEmpty().WithMessage("Id is required.")
                .NotEqual(Guid.Empty).WithMessage("Id must be greater than 0");
        }
    }
}



