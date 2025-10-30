namespace HRManagementSystem.Features.RoleFeatureManagement.AssignFeatureToRole.Commands
{
    public record AssignFeatureToRoleCommand(
        Guid RoleId,
        Feature Feature
        ) : IRequest<RequestResult<bool>>;
}
