using HRManagementSystem.Features.Common.DeleteEntityCascade;

namespace HRManagementSystem.Features.CompanyManagement.DeleteCompany.Cascade;

public sealed class DeleteCompanyCascadeViewModelValidator
        : DeleteEntityCascadeViewModelValidator<Company, Guid>
{
    public DeleteCompanyCascadeViewModelValidator() : base()
    {
    }
}
