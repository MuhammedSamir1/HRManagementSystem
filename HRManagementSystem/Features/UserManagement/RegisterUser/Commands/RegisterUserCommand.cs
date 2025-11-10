namespace HRManagementSystem.Features.UserManagement.RegisterUser.Commands
{
    public record RegisterUserCommand(
        string Name,
        string Email,
        string UserName,
        string Password,
        Guid RoleId
    ) : IRequest<RequestResult<bool>>;
}
