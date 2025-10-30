using FluentValidation;

namespace HRManagementSystem.Features.AuthManagement.Register
{
    public record RegisterUserRequestViewModel
        (
        string Name,
        string Email,
        string UserName,
        string Password,
        Guid RoleId
        );


    public class RegisterRequestViewModelValidator : AbstractValidator<RegisterUserRequestViewModel>
    {
        public RegisterRequestViewModelValidator()
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
