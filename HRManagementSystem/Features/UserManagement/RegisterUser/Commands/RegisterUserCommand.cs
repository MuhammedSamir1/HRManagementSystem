namespace HRManagementSystem.Features.AuthManagement.Register.Commands
{
    public record RegisterUserCommand(
        string Name,
        string Email,
        string UserName,
        string Password,
        Guid RoleId
    ) : IRequest<RequestResult<bool>>;
}
