using FluentValidation;

namespace HRManagementSystem.Features.ConfigurationsManagement.ShiftManagement.UpdateShift
{
    public sealed record UpdateShiftViewModel(Guid Id, string Name, TimeSpan StartTime, TimeSpan EndTime);


    public sealed class UpdateShiftViewModelValidator : AbstractValidator<UpdateShiftViewModel>
    {
        public UpdateShiftViewModelValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id is required.")
                .NotEqual(Guid.Empty).WithMessage("Id must be greater than 0.");

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



