using FluentValidation;

namespace HRManagementSystem.Features.ConfigurationsManagement.EndOfServiceManagement.UpdateEndOfService
{
    public sealed record UpdateEndOfServiceViewModel(
        int Id,
        string Title,
        string? Description,
        decimal Amount,
        DateTime ServiceStartDate,
        DateTime ServiceEndDate,
        int TotalServiceYears,
        int TotalServiceMonths,
        int TotalServiceDays,
        DateTime? PaymentDate,
        int? EmployeeId);

    public sealed class UpdateEndOfServiceViewModelValidator : AbstractValidator<UpdateEndOfServiceViewModel>
    {
        public UpdateEndOfServiceViewModelValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MinimumLength(2).WithMessage("Title must be at least 2 chars.")
                .MaximumLength(200).WithMessage("Title must be at most 200 chars.");

            RuleFor(x => x.Description)
                .MaximumLength(1000).WithMessage("Description must be at most 1000 chars.");

            RuleFor(x => x.Amount)
                .GreaterThan(0).WithMessage("Amount must be greater than 0.");

            RuleFor(x => x.ServiceStartDate)
                .NotEmpty().WithMessage("Service start date is required.");

            RuleFor(x => x.ServiceEndDate)
                .NotEmpty().WithMessage("Service end date is required.")
                .GreaterThan(x => x.ServiceStartDate).WithMessage("Service end date must be after start date.");
        }
    }
}

