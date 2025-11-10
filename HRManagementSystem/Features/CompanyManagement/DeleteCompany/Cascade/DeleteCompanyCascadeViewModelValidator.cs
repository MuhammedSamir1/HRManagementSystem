using HRManagementSystem.Features.Common.DeleteEntityCascade;

namespace HRManagementSystem.Features.CompanyManagement.DeleteCompany.Cascade;

public sealed class DeleteCompanyCascadeViewModelValidator
        : DeleteEntityCascadeViewModelValidator<Company, int>
{
    public DeleteCompanyCascadeViewModelValidator() : base()
    {
    }
}