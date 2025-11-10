using HRManagementSystem.Features.Common.DeleteEntityCascade.Handler;

namespace HRManagementSystem.Features.OrganizationManagement.DeleteOrganization.Cascade;

public sealed class DeleteOrganizationCascadeCommandHandler
        : DeleteEntityCascadeCommandHandler<Organization, int>
{
    public DeleteOrganizationCascadeCommandHandler(
        RequestHandlerBaseParameters<Organization, int> parameters
    ) : base(parameters)
    {
    }
}