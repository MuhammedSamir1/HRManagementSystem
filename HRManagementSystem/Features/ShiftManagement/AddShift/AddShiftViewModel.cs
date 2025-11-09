using FluentValidation;

namespace HRManagementSystem.Features.ShiftManagement.AddShift
{
    public sealed record AddShiftViewModel(string Name, TimeSpan StartTime, TimeSpan EndTime);


    public sealed class AddShiftViewModelValidator : AbstractValidator<AddShiftViewModel>
    {
        public AddShiftViewModelValidator()
        {
            RuleFor(x => x.Name)
               .NotEmpty().WithMessage("Name is required.")
               .MinimumLength(2).WithMessage("Name must be at least 2 chars.")
               .MaximumLength(200).WithMessage("Name must be at most 200 chars.")
               .Must(v => v!.Trim().Length <= 200);

            RuleFor(x => x.StartTime)
                .NotEmpty().WithMessage("Start time is required.")
                .LessThan(x => x.EndTime).WithMessage("Start time must be before end time.");

            RuleFor(x => x.EndTime)
                .NotEmpty().WithMessage("End time is required.")
                .GreaterThan(x => x.StartTime).WithMessage("End time must be after start time.");
        }
    }
}

