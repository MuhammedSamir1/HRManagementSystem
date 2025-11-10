using FluentValidation;

namespace HRManagementSystem.Features.UserManagement.LoginUser
{
    public record LoginUserRequestViewModel(string Username, string Password);

    public class LoginUserRequestViewModelValidator : AbstractValidator<LoginUserRequestViewModel>
    {
        public LoginUserRequestViewModelValidator()
        {
        }
    }
}
