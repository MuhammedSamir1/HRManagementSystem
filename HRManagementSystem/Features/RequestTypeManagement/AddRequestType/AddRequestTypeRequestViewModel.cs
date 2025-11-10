using FluentValidation;

namespace HRManagementSystem.Features.RequestTypeManagement.AddRequestType
{
    public record AddRequestTypeRequestViewModel(string Name, string? Description, bool RequiresAttachments);

    public class AddRequestTypeRequestViewModelValidator : AbstractValidator<AddRequestTypeRequestViewModel>
    {
        public AddRequestTypeRequestViewModelValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MinimumLength(2).WithMessage("Name must be at least 2 chars.")
                .MaximumLength(200).WithMessage("Name must be at most 200 chars.")
                .Must(v => v!.Trim().Length <= 200);

            RuleFor(x => x.Description)
                .MaximumLength(1000).WithMessage("Description must be at most 1000 chars.");
        }
    }
}

