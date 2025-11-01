using HRManagementSystem.Features.Common.DeleteEntityCascade;

namespace HRManagementSystem.Features.OrganizationManagement.DeleteOrganization.Cascade;

public sealed class DeleteOrganizationCascadeViewModelValidator
        : DeleteEntityCascadeViewModelValidator<Organization, int>
{
    public DeleteOrganizationCascadeViewModelValidator() : base()
    {
    }
}