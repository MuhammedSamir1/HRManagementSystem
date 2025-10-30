namespace HRManagementSystem.Features.RoleManagement.AddRole.Commands
{
    public record AddRoleCommand(string Name) : IRequest<RequestResult<bool>>;
}
