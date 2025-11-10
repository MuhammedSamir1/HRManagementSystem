using FluentValidation;

namespace HRManagementSystem.Features.ConfigurationsManagement.SalaryItemManagement.UpdateSalaryItem
{
    public sealed record UpdateSalaryItemViewModel(
        int Id,
        string Name,
        string? Description,
        decimal Amount,
        PayrollItemType ItemType,
        bool IsFixed,
        bool IsRecurring,
        int? EmployeeId);

    public sealed class UpdateSalaryItemViewModelValidator : AbstractValidator<UpdateSalaryItemViewModel>
    {
        public UpdateSalaryItemViewModelValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MinimumLength(2).WithMessage("Name must be at least 2 chars.")
                .MaximumLength(200).WithMessage("Name must be at most 200 chars.");

            RuleFor(x => x.Description)
                .MaximumLength(1000).WithMessage("Description must be at most 1000 chars.");

            RuleFor(x => x.Amount)
                .GreaterThan(0).WithMessage("Amount must be greater than 0.");
        }
    }
}

