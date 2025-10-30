using FluentValidation;

namespace HRManagementSystem.Features.AuthManagement.Login
{
    public record LoginUserRequestViewModel(string Username, string Password);

    public class LoginUserRequestViewModelValidator : AbstractValidator<LoginUserRequestViewModel>
    {
        public LoginUserRequestViewModelValidator()
        {
        }
    }
}
