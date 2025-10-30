using FluentValidation;

namespace HRManagementSystem.Features.RoleManagement.AddRole
{
    public record AddRoleRequestViewModel(string Name);

    public class AddRoleRequestViewModelValidator : AbstractValidator<AddRoleRequestViewModel>
    {
        public AddRoleRequestViewModelValidator()
        {
            // Name validation
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MinimumLength(2).WithMessage("Name must be at least 2 characters.")
                .MaximumLength(200).WithMessage("Name must be at most 200 characters.")
                .Must(v => v!.Trim().Length <= 200).WithMessage("Name must not contain excessive whitespace.");
        }
    }
}
