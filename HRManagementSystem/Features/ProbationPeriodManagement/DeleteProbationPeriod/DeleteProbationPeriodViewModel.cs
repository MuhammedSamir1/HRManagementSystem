using FluentValidation;

namespace HRManagementSystem.Features.ProbationPeriodManagement.DeleteProbationPeriod
{
    public sealed record DeleteProbationPeriodViewModel(int Id);



    public sealed class DeleteProbationPeriodViewModelValidator : AbstractValidator<DeleteProbationPeriodViewModel>
    {
        public DeleteProbationPeriodViewModelValidator()
        {
            RuleFor(d => d.Id)
                .NotEmpty().WithMessage("Id is required.")
                .GreaterThan(0).WithMessage("Id must be greater than 0");
        }
    }
}

