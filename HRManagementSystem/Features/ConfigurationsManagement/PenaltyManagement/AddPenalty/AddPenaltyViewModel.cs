using FluentValidation;

namespace HRManagementSystem.Features.ConfigurationsManagement.PenaltyManagement.AddPenalty
{
    public sealed record AddPenaltyViewModel(
        string Title,
        string? Description,
        decimal Amount,
        DateTime PenaltyDate,
        string? Reason,
        PenaltyStatus Status);

    public sealed class AddPenaltyViewModelValidator : AbstractValidator<AddPenaltyViewModel>
    {
        public AddPenaltyViewModelValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MinimumLength(2).WithMessage("Title must be at least 2 chars.")
                .MaximumLength(200).WithMessage("Title must be at most 200 chars.");

            RuleFor(x => x.Description)
                .MaximumLength(1000).WithMessage("Description must be at most 1000 chars.");

            RuleFor(x => x.Amount)
                .GreaterThan(0).WithMessage("Amount must be greater than 0.");

            RuleFor(x => x.PenaltyDate)
                .NotEmpty().WithMessage("Penalty date is required.");

            RuleFor(x => x.Reason)
                .MaximumLength(500).WithMessage("Reason must be at most 500 chars.");
        }
    }
}


