using HRManagementSystem.Features.Common.DeleteEntityCascade;

namespace HRManagementSystem.Features.DepartmentManagement.DeleteDepartment.Cascade;

public sealed class DeleteDepartmentCascadeViewModelValidator
        : DeleteEntityCascadeViewModelValidator<Department, int>
{
    public DeleteDepartmentCascadeViewModelValidator() : base()
    {
    }
}