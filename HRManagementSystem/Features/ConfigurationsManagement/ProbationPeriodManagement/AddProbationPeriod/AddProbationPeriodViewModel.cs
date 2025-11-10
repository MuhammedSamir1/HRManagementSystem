using FluentValidation;

namespace HRManagementSystem.Features.ConfigurationsManagement.ProbationPeriodManagement.AddProbationPeriod
{
    public sealed record AddProbationPeriodViewModel(DateTime StartDate, DateTime EndDate, int DurationInDays,
        bool IsApproved, DateTime? ApprovalDate, ProbationPeriodStatus Status);


    public sealed class AddProbationPeriodViewModelValidator : AbstractValidator<AddProbationPeriodViewModel>
    {
        public AddProbationPeriodViewModelValidator()
        {
            RuleFor(x => x.StartDate)
                .NotEmpty().WithMessage("Start date is required.")
                .LessThan(x => x.EndDate).WithMessage("Start date must be before end date.");

            RuleFor(x => x.EndDate)
                .NotEmpty().WithMessage("End date is required.")
                .GreaterThan(x => x.StartDate).WithMessage("End date must be after start date.");

            RuleFor(x => x.DurationInDays)
                .NotEmpty().WithMessage("Duration in days is required.")
                .GreaterThan(0).WithMessage("Duration must be greater than 0.");

            RuleFor(x => x.Status)
                .IsInEnum().WithMessage("Invalid probation period status.");

            RuleFor(x => x.ApprovalDate)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Approval date cannot be in the future.")
                .When(x => x.ApprovalDate.HasValue);
        }
    }
}

