using HRManagementSystem.Features.Common.DeleteEntityCascade.Handler;

namespace HRManagementSystem.Features.OrganizationManagement.DeleteOrganization.Cascade;

public sealed class DeleteOrganizationCascadeCommandHandler
        : DeleteEntityCascadeCommandHandler<Organization, Guid>
{
    public DeleteOrganizationCascadeCommandHandler(
        RequestHandlerBaseParameters<Organization, Guid> parameters
    ) : base(parameters)
    {
    }
}
