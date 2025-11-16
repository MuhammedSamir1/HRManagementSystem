using FluentValidation;

namespace HRManagementSystem.Features.ConfigurationsManagement.BonusManagement.UpdateBonus
{
    public sealed record UpdateBonusViewModel(
        Guid Id,
        string Title,
        string? Description,
        decimal Amount,
        BonusType BonusType,
        DateTime BonusDate,
        DateTime? PaymentDate,
        bool IsPaid);

    public sealed class UpdateBonusViewModelValidator : AbstractValidator<UpdateBonusViewModel>
    {
        public UpdateBonusViewModelValidator()
        {
            RuleFor(x => x.Id)
                .NotEqual(Guid.Empty).WithMessage("Id must be greater than 0.");

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MinimumLength(2).WithMessage("Title must be at least 2 chars.")
                .MaximumLength(200).WithMessage("Title must be at most 200 chars.");

            RuleFor(x => x.Description)
                .MaximumLength(1000).WithMessage("Description must be at most 1000 chars.");

            RuleFor(x => x.Amount)
                .GreaterThan(0).WithMessage("Amount must be greater than 0.");

            RuleFor(x => x.BonusDate)
                .NotEmpty().WithMessage("Bonus date is required.");
        }
    }
}



